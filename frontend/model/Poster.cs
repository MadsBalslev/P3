using System;
using System.Text.Json;

public class Poster : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public string image { get; set; }

    public Institution institution { get; set; }

    public void InitializeAggregateObjects()
    {
        institution = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                name = this.name,
                institution = this.institution.id,
                imageUrl = this.image
            }
        );
    }
}