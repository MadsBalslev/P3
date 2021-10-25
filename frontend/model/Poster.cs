using System;
using System.Collections.Generic;

public class Poster
{
    [AccessLevelAttribute(AccessLevel.User)]
    public string Name { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    public string Creator { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    public string Institution { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.User)]
    public string StartDate { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.User)]
    public string EndDate { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    public string Id { get; set; } = "nil";
    
    private string ImageUrl { get; set; } = "nil";

    public Poster(string name, string creator, string institution)
    {
        Name = name;
        Creator = creator;
        Institution = institution;
    }
}