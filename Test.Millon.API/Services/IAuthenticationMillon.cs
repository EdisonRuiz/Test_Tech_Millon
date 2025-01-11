namespace Test.Millon.API.Services
{
    public interface IAuthenticationMillon
    {
        string LoginAsync(string user, string password);
    }
}
