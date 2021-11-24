class CurrentUserService : ICurrentUserService
{
    public string Authorization { get; set; }
    public User User { get; set; }
}