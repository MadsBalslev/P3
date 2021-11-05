using System;
using System.Collections.Generic;
using System.Text.Json;

[APIAttribute("/Posters")]
public class Poster : IManageable
{
    [ManagerMetadata("ID", AccessLevel.SysAdmin, AccessLevel.None, FormRepresentation.None)]
    public int posterId { get; set; } = -1;

    [ManagerMetadata("Name", AccessLevel.User, AccessLevel.User, FormRepresentation.TextField)]
    public string name { get; set; } = "";

    [ManagerMetadata("Start date", AccessLevel.User, AccessLevel.User, FormRepresentation.DatePicker)]
    public DateTimeOffset startDate { get; set; } = new DateTimeOffset();

    [ManagerMetadata("End date", AccessLevel.User, AccessLevel.User, FormRepresentation.DatePicker)]
    public DateTimeOffset endDate { get; set; } = new DateTimeOffset();

    [ManagerMetadata("Creator", AccessLevel.InstAdmin, AccessLevel.None, FormRepresentation.None)]
    public string Creator { get => createdBy.name; }

    [ManagerMetadata("Institution", AccessLevel.SysAdmin, AccessLevel.None, FormRepresentation.None)]
    public string Institution { get => institution.name; }

    [ManagerMetadata("Image url", AccessLevel.User, AccessLevel.User, FormRepresentation.PictureUpload)]
    public string image { get; set; } = "https://via.placeholder.com/1080x1920";

    public User createdBy { get; set; } = new User();

    public Institution institution { get; set; } = new Institution();

    public string ToJSON()
    {
        return JsonSerializer.Serialize<object>
        (
            new
            {
                name = this.name,
                startDate = this.startDate,
                endDate = this.endDate,
                imageUrl = this.image
            }
        );
    }
}