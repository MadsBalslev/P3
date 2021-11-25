public interface ICurrentUserService
{
    bool isLoggedIn { get; }
    string Authorization { get; set; }
    User User { get; set; }
    void Logout();
}