using UnityEngine;

namespace Dracau
{
    /// <summary>
    /// Makes field read-only in the inspector. Combine with SerializeField to display private properties.
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {
        
    }
}