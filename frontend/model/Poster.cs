class Poster : IManageable
{
    public string Name { get; set; }
    public string Creator { get; set; }
    public string Institution { get; set; }

    public Poster(string name, string creator, string institution)
    {
        Name = name;
        Creator = creator;
        Institution = institution;
    }
}