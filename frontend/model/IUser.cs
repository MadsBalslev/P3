public interface IUser
{
    int? id { get; set; }
    string firstName { get; set; }
    string lastName { get; set; }
    string email { get; set; }
    string phoneNumber { get; set; }
    string password { get; set; }
    int? role { get; set; }
    string RoleAsString { get; }
    string name { get; set; }
    Institution institution { get; set; }
}
