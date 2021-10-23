using System.Collections.Generic;
using System.Reflection;

public interface IManageable
{
    public List<string> TableHeader { get; }
    public List<string> MudTableDataNames { get; }

    public object this[string propertyName]
    {
        get
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            return property.GetValue(this, null);
        }
    }
}