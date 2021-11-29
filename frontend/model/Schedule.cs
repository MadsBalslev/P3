using System;
using System.Text.Json;

public class Schedule : IManageable
{
    public int? id { get; set; }
    public string name { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }

    public Zone zone { get; set; }
    public Poster poster { get; set; }

    public void InitializeAggregateObjects()
    {
        zone = new();
        poster = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                // id = this.id,
                posterId = this.poster.id,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                zone = this.zone.id,
            }
        );
    }
}