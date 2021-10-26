using System;

[AttributeUsage(AttributeTargets.Class)]
public class APIAttribute : Attribute
{
    public string APIPath = "/";

    public APIAttribute(string apiPath)
    {
        APIPath = apiPath;
    }
}