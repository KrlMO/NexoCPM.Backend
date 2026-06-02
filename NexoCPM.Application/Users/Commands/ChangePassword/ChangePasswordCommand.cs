using MediatR;

namespace NexoCPM.Application.Users.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword, int UserId)
    : IRequest<ChangePasswordResponse>;
