namespace frontend.Shared
{
    public partial class Manager<TManageable> where TManageable : IManageable
    {
        string _test { get; set; } = "test";
    }
}