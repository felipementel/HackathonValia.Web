using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace POCAttribute.Models.ElementAttribute
{
    [DebuggerDisplay("Order = {Order}", Name = "EmpregadoProperty")]
    [AttributeUsage(AttributeTargets.Property,
                    AllowMultiple = false,
                    Inherited = true)]
    [Serializable]
    public class EmpregadoAttribute : BaseAttribute
    {
        public EmpregadoAttribute(int initialPosition, int length, bool required) 
            : base(initialPosition, length, required)
        {
        }
    }
}
