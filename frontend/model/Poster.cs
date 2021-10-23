using System;
using System.Collections;

class Poster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Creator { get; set; }
    public string Institution { get; set; }
    public string imageUrl { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }

    public Poster(string name, string creator, string institution)
    {
        Name = name;
        Creator = creator;
        Institution = institution;
    }
}