using System.Net.Http;

class UserInformation : IUserInformation
{
    public User User { get; set; }

    public string AuthenticationString { get; set; }
}