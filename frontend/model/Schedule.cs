using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }
    public Schedule Poster { get; set; }
    public int? posterId { get; set; }
    public string name { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }

    public Zone zone { get; set; }

    public void InitializeAggregateObjects()
    {
        Poster = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                // id = this.id,
                posterId = this.Poster.id,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                zone = this.zone.id,
            }
        );
    }
}