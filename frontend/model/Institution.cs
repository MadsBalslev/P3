public class Institution : IManageable
{
    public int? id { get; set; }

    public string name { get; set; }

    public User admin { get; set; }

    public string ToJSON()
    {
        throw new System.NotImplementedException();
    }
}