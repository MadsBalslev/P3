using System.Text.Json;

public class Institution : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public User admin { get; set; }

    public void InitializeAggregateObjects()
    {
        admin = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                name = this.name,
                admin = this.admin.id,
            }
        );
    }
}