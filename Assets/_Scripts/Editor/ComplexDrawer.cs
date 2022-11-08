using UnityEditor;
using UnityEngine;
using Utils;

namespace Editor
{
    [CustomPropertyDrawer(typeof(Complex))]
    public class ComplexDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var reProperty = property.FindPropertyRelative("re");
            var imProperty = property.FindPropertyRelative("im");
            
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;


            var reLabelWidth = 20f;
            var imLabelWidth = 20f;
            var spaceBetweenSubProperty = 5f;
            var subPropertyWidth = (position.width - reLabelWidth - imLabelWidth -1 * spaceBetweenSubProperty) / 2;

            var reLabelRect = new Rect(position.x, position.y, reLabelWidth, position.height);
            var rePropertyRect = new Rect(reLabelRect.position.x + reLabelWidth, position.y, subPropertyWidth, position.height);
            
            var imLabelRect = new Rect(rePropertyRect.position.x + rePropertyRect.width + spaceBetweenSubProperty, position.y, imLabelWidth, position.height);
            var imPropertyRect = new Rect(imLabelRect.position.x + imLabelRect.width, position.y, subPropertyWidth, position.height);

            
            EditorGUI.LabelField(reLabelRect, new GUIContent("Re", "The real part"));
            EditorGUI.PropertyField(rePropertyRect, reProperty, GUIContent.none);
            
            EditorGUI.LabelField(imLabelRect, new GUIContent("Im", "The imaginary part"));
            EditorGUI.PropertyField(imPropertyRect, imProperty, GUIContent.none);
            
            
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}