using System;

[APIAttribute("/Posters")]
public class Poster
{
    private DateTime _startDate = new DateTime(1, 1, 1);

    private DateTime _endDate = new DateTime(1, 1, 1);

    private int _id = 0;

    private string ImageUrl { get; set; } = "nil";

    [ManagerMetadata(AccessLevel.SysAdmin, "ID")]
    public string Id
    {
        get { return _id.ToString(); }
        set { _id = Int32.Parse(value); }
    }

    [ManagerMetadata(AccessLevel.User, "Name")]
    public string Name { get; set; } = "nil";

    [ManagerMetadata(AccessLevel.InstAdmin, "Creator")]
    public string Creator { get; set; } = "nil";

    [ManagerMetadata(AccessLevel.SysAdmin, "Institution")]
    public string Institution { get; set; } = "nil";

    [ManagerMetadata(AccessLevel.User, "Start date")]
    public string StartDate
    {
        get { return _startDate.ToString(); }
        set { _startDate = DateTime.Parse(value); }
    }

    [ManagerMetadata(AccessLevel.User, "End date")]
    public string EndDate
    {
        get { return _endDate.ToString(); }
        set { _endDate = DateTime.Parse(value); }
    }

    public Poster(int id, string name, string creator, string institution, DateTime startDate, DateTime endDate)
    {
        _id = id;
        Name = name;
        Creator = creator;
        Institution = institution;
        _startDate = startDate;
        _endDate = endDate;
    }

    public void ChangeUrl(string url)
    {
        ImageUrl = url;
    }
}