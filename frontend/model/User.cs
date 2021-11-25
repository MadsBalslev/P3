using System.Text.Json;

public class User : IManageable
{
    public User()
    {
    }

    public User(int? id,
                string firstName,
                string lastName,
                string email,
                string phoneNumber,
                string password,
                AccessLevel accessLevel,
                Institution institution)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.name = $"{firstName} {lastName}";
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.password = password;
        AccessLevel = accessLevel;
        this.institution = institution;
    }

    public int? id { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

    public string name { get; set; }

    public string email { get; set; }

    public string phoneNumber { get; set; }

    public string password { get; set; }

    public int? role { get; set; }

    public string RoleAsString
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
    }

    public AccessLevel AccessLevel
    {
        get
        {
            switch (role)
            {
                case 1:
                    return AccessLevel.User;
                case 2:
                    return AccessLevel.InstAdmin;
                case 3:
                    return AccessLevel.SysAdmin;
                default:
                    return AccessLevel.User;
            }
        }
        set
        {
            switch (value)
            {
                case AccessLevel.User:
                    role = 1;
                    break;
                case AccessLevel.InstAdmin:
                    role = 2;
                    break;
                case AccessLevel.SysAdmin:
                    role = 3;
                    break;
                default:
                    role = 1;
                    break;
            }
        }
    }


    public Institution institution { get; set; }

    public void InitializeAggregateObjects()
    {
        institution = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                firstName = this.firstName,
                lastName = this.lastName,
                email = this.email,
                phoneNumber = this.phoneNumber,
                institution = this.institution.id,
                role = this.role,
                password = this.password,
            }
        );
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} ({RoleAsString}) - {institution.name}";
    }
}