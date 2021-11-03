using System;
using System.Collections.Generic;

[APIAttribute("/Posters")]
public class Poster
{
    [ManagerMetadata(AccessLevel.SysAdmin, "ID")]
    public int posterId { get; set; } = -1;

    [ManagerMetadata(AccessLevel.User, "Name")]
    public string name { get; set; } = "nil";

    [ManagerMetadata(AccessLevel.User, "Start date")]
    public DateTimeOffset startDate { get; set; } = new DateTimeOffset();

    [ManagerMetadata(AccessLevel.User, "End date")]
    public DateTimeOffset endDate { get; set; } = new DateTimeOffset();

    [ManagerMetadata(AccessLevel.InstAdmin, "Created by")]
    public string Creator { get => createdBy.name; }

    [ManagerMetadata(AccessLevel.SysAdmin, "Institution")]
    public string  Institution { get => institution.name; }

    [ManagerMetadata(AccessLevel.User, "Image url")]
    public string image { get; set; } = "https://via.placeholder.com/1080x1920";

    public User createdBy { get; set; } = new User();

    public Institution institution { get; set; } = new Institution();
}