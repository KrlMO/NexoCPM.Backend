using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Exceptions;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Auth.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserCodeGenerator _userCodeGenerator;
        private readonly IEmailService _emailService;
        private readonly IEmailVerificationTokenService _emailVerificationTokenService;
        private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;

        public RegisterHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUserCodeGenerator userCodeGenerator,
            IEmailService emailService,
            IEmailVerificationTokenService emailVerificationTokenService,
            IEmailVerificationTokenRepository emailVerificationTokenRepository
            )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userCodeGenerator = userCodeGenerator;
            _emailService = emailService;
            _emailVerificationTokenService = emailVerificationTokenService;
            _emailVerificationTokenRepository = emailVerificationTokenRepository;
        }
        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByEmailAsync(request.Email) is not null)
                return new RegisterResult { EmailSent = false, Message = "Email ya está registrado" };

            if (await _userRepository.GetByUserNameAsync(request.UserName) is not null)
                return new RegisterResult { EmailSent = false, Message = "Nombre de usuario ya está en uso" };

            var passwordHash = _passwordHasher.Hash(request.Password);

            for (int i = 0; i < 3; i++)
            {
                var code = await _userCodeGenerator.GenerateAsync(
                    request.FirstName,
                    request.LastName
                );

                var user = new User(
                    request.FirstName,
                    request.LastName,
                    request.UserName,
                    request.Email,
                    passwordHash,
                    code
                );

                try
                {
                    await _userRepository.AddAsync(user);

                    var (token, tokenHash) = await _emailVerificationTokenService.GenerateAsync();

                    var emailToken = new EmailVerificationToken(
                        user.Id,
                        tokenHash,
                        DateTime.UtcNow.AddHours(24)
                    );

                    await _emailVerificationTokenRepository.AddAsync(emailToken);

                    await _emailService.SendVerificationEmailAsync(user.Email, token);
                    return new RegisterResult
                    {
                        EmailSent = true,
                        Email = user.Email,
                        Message = "Usuario Registrado. Por favor, verifica tu correo electrónico."
                    };
                }
                catch (UniqueConstraintException)
                {
                    // retry
                }
            }

            throw new Exception("No se pudo generar un código único");
        }
    }
}
