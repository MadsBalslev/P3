using System.Text.Json;

public class User : IManageable
{
    public int? id { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

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
    }

    public string name { get; set; }

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