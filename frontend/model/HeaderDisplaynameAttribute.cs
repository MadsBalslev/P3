using System;

[AttributeUsage(AttributeTargets.Property)]
public class HeaderDisplaynameAttribute : Attribute
{
    public string HeaderDisplayname { get; set; } = "NIL";

    public HeaderDisplaynameAttribute(string headerDisplayname)
    {
        HeaderDisplayname = headerDisplayname;
    }
}