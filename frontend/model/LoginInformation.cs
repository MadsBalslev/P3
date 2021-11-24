
using System.Text.Json;

class LoginInformation : IToJSON

{
    public string email { get; set; }
    public string password { get; set; }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                email = this.email,
                password = this.password,
            }
        );
    }
}