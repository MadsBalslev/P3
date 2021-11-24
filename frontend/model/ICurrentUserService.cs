public interface ICurrentUserService
{
    string Authorization { get; set;}
    User User { get; set; }
}