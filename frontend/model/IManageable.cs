public interface IManageable
{
    public string ToJSON();
    public int? id { get; }

    public void InitializeAggregateObjects();
}