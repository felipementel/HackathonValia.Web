using System;
using System.Diagnostics;

namespace POCAttribute.Models.ElementAttribute
{
    [DebuggerDisplay("Order = {Order}", Name = "BaseProperty")]
    [AttributeUsage(AttributeTargets.Property,
                    AllowMultiple = false,
                    Inherited = true)]
    [Serializable]
    public abstract class BaseAttribute : Attribute
    {
        public int InitialPosition { get; private set; }
        public int Length { get; private set; }
        public bool Required { get; private set; }

        public BaseAttribute(int initialPosition, int length, bool required)
        {
            this.InitialPosition = initialPosition;
            this.Length = length;
            this.Required = required;
        }
    }
}
