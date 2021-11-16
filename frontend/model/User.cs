[APIAttribute("/Users")]
public class User : IManageable
{
    [ManagerMetadata("ID", AccessLevel.SysAdmin, AccessLevel.None)]
    public int id { get; set; } = -1;

    public int Id { get => id; }

    public string name { get; set; } = "nil";

    [ManagerMetadata("Last name", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public string firstName { get; set; }

    [ManagerMetadata("First name", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public string lastName { get; set; }

    [ManagerMetadata("Email", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public string email { get; set; }

    [ManagerMetadata("Phone number", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public int? phoneNumber { get; set; }

    [ManagerMetadata("Institution", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public string InstitutionName { get => institution.name; }

    public int role { get; set; }

    public Institution institution { get; set; }

    public AccessLevel accessLevel { get; set; } = AccessLevel.User;

    [ManagerMetadata("Role", AccessLevel.InstAdmin, AccessLevel.InstAdmin)]
    public string RoleString
    {
        get
        {
            switch (role)
            {
                case 1:
                    return "Normal user";
                case 2:
                    return "Institution admin";
                case 3:
                    return "System admin";
                default:
                    return "";
            }
        }
        set
        {
            switch (value)
            {
                case "Normal user":
                    role = 1;
                    break;
                case "Institution admin":
                    role = 2;
                    break;
                case "System admin":
                    role = 3;
                    break;
                default:
                    role = 1;
                    break;
            }
        }
    }

    public int InstitutionId { get; set; }

    public string ToJSON()
    {
        throw new System.NotImplementedException();
    }
}