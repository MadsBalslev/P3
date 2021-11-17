using System;
using Microsoft.Extensions.Configuration;

[AttributeUsage(AttributeTargets.Class)]
public class APIAttribute : Attribute
{
    public string ApiPath = "";

    public APIAttribute(string apiPath)
    {
        ApiPath = apiPath;
    }
}