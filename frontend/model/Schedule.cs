using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }
    public int? posterId { get; set; }
    public string name { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
    public int daily { get; set; }
    public string dailyToString
    {
        get
        {
            if (daily == 0)
            {
                return "No";
            }
            if (daily == 1)
            {
                return "Yes";
            }
            return "Error";
        }
    }
    public string weekday { get; set; }

    public void InitializeAggregateObjects()
    {
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                // id = this.id,
                posterId = this.posterId,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                // daily = this.dailyToString,
                // weekday = this.weekday,
            }
        );
    }
}