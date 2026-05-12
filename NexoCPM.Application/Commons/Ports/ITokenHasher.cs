namespace NexoCPM.Application.Commons.Ports;

public interface ITokenHasher
{
    string Hash(string token);
}
