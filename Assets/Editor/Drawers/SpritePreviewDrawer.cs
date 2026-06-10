using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Sprite))]
public class SpritePreviewDrawer : PropertyDrawer
{
    private const float textureSize = 65;

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        if (prop.objectReferenceValue != null)
        {
            return textureSize;
        }
        else
        {
            return base.GetPropertyHeight(prop, label);
        }
    }

    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, prop);

        if (prop.objectReferenceValue != null)
        {
            position.width = EditorGUIUtility.labelWidth;
            GUI.Label(position, prop.displayName);

            position.x += position.width;
            position.width = textureSize;
            position.height = textureSize;

            prop.objectReferenceValue = EditorGUI.ObjectField(position, prop.objectReferenceValue, typeof(Sprite), false);
        }
        else
        {
            EditorGUI.PropertyField(position, prop, true);
        }

        EditorGUI.EndProperty();
    }
}