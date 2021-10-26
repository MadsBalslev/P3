using System;

[AttributeUsage(AttributeTargets.Property)]
public class AccessLevelAttribute : Attribute
{
    public AccessLevel AccessLevel { get; set; } = AccessLevel.User;

    public AccessLevelAttribute(AccessLevel accessLevel)
    {
        AccessLevel = accessLevel;
    }
}