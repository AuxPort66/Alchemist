using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SymbolColored))]
public class SymbolListDrawer : PropertyDrawer
{
    float previewSize = 40f;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return previewSize + 4f;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        FieldInfo[] fields = typeof(SymbolColored).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo symbolField = fields.First(f => f.FieldType == typeof(SymbolType));
        FieldInfo colorField = fields.First(f => f.FieldType == typeof(ColorType));

        SerializedProperty colorProperty = property.FindPropertyRelative(colorField.Name);
        SerializedProperty symbolProperty = property.FindPropertyRelative(symbolField.Name);

        ColorType colorType = (ColorType)colorProperty.enumValueIndex;
        SymbolType symbolType = (SymbolType)symbolProperty.enumValueIndex;

        SymbolDatabase symbolDB = Database.LoadDatabase<SymbolDatabase>();
        ColorDatabase colorDB = Database.LoadDatabase<ColorDatabase>();

        Sprite symbolSprite = symbolDB.GetSymbolImage(symbolType);
        Color symbolColor = colorDB.GetColor(colorType);

        DrawColoredSymbolPreview(position, symbolSprite, symbolColor);

        DrawDropdownEnums(position, symbolProperty, colorProperty);

        EditorGUI.EndProperty();
    }

    public void DrawColoredSymbolPreview(Rect position, Sprite symbolSprite, Color symbolColor)
    {
        Rect previewRect = new Rect(position.x, position.y, previewSize, previewSize);

        if (symbolSprite != null)
        {
            Texture2D tex = symbolSprite.texture;

            Rect texCoords = new Rect(
                symbolSprite.textureRect.x / tex.width,
                symbolSprite.textureRect.y / tex.height,
                symbolSprite.textureRect.width / tex.width,
                symbolSprite.textureRect.height / tex.height
            );

            Color oldColor = GUI.color;
            GUI.color = symbolColor;

            GUI.DrawTextureWithTexCoords(previewRect, tex, texCoords);

            GUI.color = oldColor;
        }
        else
        {
            EditorGUI.HelpBox(previewRect, "No sprite", MessageType.None);
        }
    }

    public void DrawDropdownEnums(Rect position, SerializedProperty symbolProperty, SerializedProperty colorProperty)
    {
        float fieldX = position.x + previewSize + 6f;
        float fieldWidth = position.width - previewSize - 6f;

        Rect symbolRect = new Rect(fieldX, position.y, fieldWidth, EditorGUIUtility.singleLineHeight);
        Rect colorRect = new Rect(fieldX, position.y + EditorGUIUtility.singleLineHeight + 2f, fieldWidth, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(symbolRect, symbolProperty);
        EditorGUI.PropertyField(colorRect, colorProperty);
    }
}