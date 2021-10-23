using System.Collections.Generic;

class Poster : IManageable
{

    public string Name { get; set; }
    public string Creator { get; set; }
    public string Institution { get; set; }

    public List<string> HeaderContent
    {
        get
        {
            return new List<string>() { "Name", "Creator", "Institution" };
        }
    }

    public List<string> TableHeader => new List<string>() {"Name", "Creator", "Institution"};

    public List<string> MudTableDataNames => new List<string>() {"Name", "Creator", "Institution"};

    public Poster(string name, string creator, string institution)
    {
        Name = name;
        Creator = creator;
        Institution = institution;
    }
}