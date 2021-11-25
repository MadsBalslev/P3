class CurrentUserService : ICurrentUserService
{
    public string Authorization { get; set; }
    public User User { get; set; } = new User(0, "", "", "", "", "", AccessLevel.User, new Institution());

    public void Clear()
    {
        Authorization = null;
        User = new User(0, "", "", "", "", "", AccessLevel.User, new Institution());
    }
}