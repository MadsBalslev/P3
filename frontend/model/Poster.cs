using System;
using System.Text.Json;

public class Poster : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public string image { get; set; }

    public User createdBy { get; set; }

    public Institution institution { get; set; }

    public void InitializeAggregateObjects()
    {
        createdBy = new();
        institution = new();
    }

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                createdBy = this.createdBy.id,
                name = this.name,
                imageUrl = this.image
            }
        );
    }
}