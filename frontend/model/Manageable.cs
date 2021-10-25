public abstract class Manageable
{
    public object this[string key]
    {
        get
        {
            var prop = typeof(Manageable).GetProperty(key);
            if (prop != null)
            {
                return prop.GetValue(this, null);
            }
            return null;
        }

    }
}