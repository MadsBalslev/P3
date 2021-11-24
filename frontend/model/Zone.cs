using System.Text.Json;

public class Zone : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }
    public void InitializeAggregateObjects()
    {
    }
    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                name = this.name
            }
        );
    }
}