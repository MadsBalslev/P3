using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }
    public int posterId { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public int daily { get; set; }
    public string? weekday { get; set; }
}


public string ToJSON()
{
    return JsonSerializer.Serialize<object>
    {
        new
        {
            posterId = this.posterId;

        }
    }


}