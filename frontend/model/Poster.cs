using System;
using System.Text.Json;

public class Poster : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public string image { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }

    public User createdBy { get; set; } = new User();

    public Institution institution { get; set; } = new Institution();

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                createdBy = this.createdBy.id,
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                imageUrl = this.image
            }
        );
    }
}