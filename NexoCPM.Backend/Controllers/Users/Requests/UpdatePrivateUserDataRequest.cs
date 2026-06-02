namespace NexoCPM.Api.Controllers.Users.Requests
{
    public class UpdatePrivateUserDataRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? phoneNumber { get; set; }
    }
}
