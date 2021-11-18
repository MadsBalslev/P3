using System.Text.Json;

public class User : IManageable
{
    // TODO
    public int? id { get; set; } = 1;

    public string firstName { get; set; }

    public string lastName { get; set; }

    public string email { get; set; }

    public int? phoneNumber { get; set; }

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

    public string name { get; set; }

    public Institution institution { get; set; } = new();

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
            }
        );
    }
}