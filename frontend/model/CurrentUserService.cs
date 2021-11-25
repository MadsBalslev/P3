using frontend.Shared;

class CurrentUserService : ICurrentUserService
{
    public bool isLoggedIn { get => Authorization == null; }
    public string Authorization { get; set; }

    public User User { get;  set; } = new User(0, "", "", "", "", "", AccessLevel.User, new Institution());

    public void Logout()
    {
        Authorization = null;
        User = new User(0, "", "", "", "", "", AccessLevel.User, new Institution());
    }
}