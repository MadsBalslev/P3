using frontend.Shared;

public interface IManageable : IToJSON
{
    public int? id { get; }

    public void InitializeAggregateObjects();
}