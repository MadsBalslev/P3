using System.Text.Json;

public class Metadata : IManageable
{
    public int? id { get; set; }

    public int? timerValue { get; set; }

    public void InitializeAggregateObjects()
    {

    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                timerValue = this.timerValue
            }
        );
    }
}