using System;
using System.Collections.Generic;

public class Poster
{
    [AccessLevelAttribute(AccessLevel.User)]
    [HeaderDisplaynameAttribute("Name")]
    public string Name { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    [HeaderDisplaynameAttribute("Creator")]
    public string Creator { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    [HeaderDisplaynameAttribute("Institution")]
    public string Institution { get; set; } = "nil";

    [AccessLevelAttribute(AccessLevel.User)]
    [HeaderDisplaynameAttribute("Start date")]
    public string StartDate 
    { 
        get { return _startDate.ToString(); } 
        set { _startDate = DateTime.Parse(value);} 
    }

    private DateTime _startDate = new DateTime(0, 0, 0);

    [AccessLevelAttribute(AccessLevel.User)]
    [HeaderDisplaynameAttribute("End date")]
    public string EndDate 
    { 
        get { return _endDate.ToString(); } 
        set { _endDate = DateTime.Parse(value); } 
    }

    private DateTime _endDate = new DateTime(0, 0, 0);

    [AccessLevelAttribute(AccessLevel.InstAdmin)]
    [HeaderDisplaynameAttribute("ID")]
    public string Id { get; set; } = "nil";

    private string ImageUrl { get; set; } = "nil";

    public Poster(string name, string creator, string institution, string startDate)
    {
        Name = name;
        Creator = creator;
        Institution = institution;
    }
}