using System;

[AttributeUsage(AttributeTargets.Property)]
public class ManagerMetadataAttribute : Attribute
{
    public string HeaderDisplayname { get; set; } = "NIL";
    public AccessLevel AccessLevel { get; set; } = AccessLevel.User;

    public ManagerMetadataAttribute(AccessLevel accessLevel, string headerDisplayname)
    {
        HeaderDisplayname = headerDisplayname;
        AccessLevel = accessLevel;
    }
}