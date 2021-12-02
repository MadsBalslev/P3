using System;

// https://docs.microsoft.com/en-us/dotnet/core/testing/order-unit-tests?pivots=xunit
namespace tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        public int Priority { get; private set; }

        public TestPriorityAttribute(int priority) => Priority = priority;
    }
}
