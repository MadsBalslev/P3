using System;

[AttributeUsage(AttributeTargets.Class)]
public class APIAttribute : Attribute
{
    private static readonly string _basePath = "http://localhost:5000";
    public string APIPath = _basePath;

    public APIAttribute(string apiPath)
    {
        APIPath = _basePath + apiPath;
    }
}