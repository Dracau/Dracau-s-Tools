using UnityEngine;
using System;

namespace Dracau
{
    /// <summary>
    /// Only shows field if value is true, use bool name as a string. Combine with SerializeField if the field is private.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class ConditionalFieldAttribute : PropertyAttribute
    {
        public string testValue = "";
 
        public ConditionalFieldAttribute(string testValue)
        {
            this.testValue = testValue;
        }
    }
}
