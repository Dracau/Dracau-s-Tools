#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Dracau
{
    [CustomPropertyDrawer(typeof(ConditionalFieldAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ConditionalFieldAttribute conditionFieldAttribute = (ConditionalFieldAttribute)attribute;
            if (GetConditionalHideAttributeResult(conditionFieldAttribute, property))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
     
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalFieldAttribute conditionFieldAttribute = (ConditionalFieldAttribute)attribute;
            bool enabled = GetConditionalHideAttributeResult(conditionFieldAttribute, property);
     
            if (enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }
            else
            {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }
     
        private bool GetConditionalHideAttributeResult(ConditionalFieldAttribute conditionalFieldAttribute, SerializedProperty property)
        {
            bool enabled = true;
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name, conditionalFieldAttribute.testValue);
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);
     
            if (sourcePropertyValue != null)
            {
                enabled = sourcePropertyValue.boolValue;
            }
            else
            {
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + conditionalFieldAttribute.testValue);
            }
            return enabled;
        }
    }
}
#endif