using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditorInternal.VersionControl.ListControl;

[CustomPropertyDrawer(typeof(SymbolColored))]
public class SymbolListDrawer : PropertyDrawer
{
    float previewSize = 40f;
    private Dictionary<ColorType, Texture2D> colorIcons = new Dictionary<ColorType, Texture2D>();
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


[CustomEditor(typeof(Ingredient))]
public class IngredientEditor : Editor
{
    private int minSymbols = 1;
    private int maxSymbols = 4;

    private bool init = true;

    private ColorDatabase colorDB;
    private SymbolDatabase symbolDB;

    List<(string text, Color color)> states;
    List<MultiStateButton> colorButtons;
    List<MultiStateButton> symbolButtons;

    private void InitMultiStateButtons()
    {
        states = new List<(string text, Color color)>();
        states.Add(("", Color.white));
        states.Add(("✔", Color.green));
        states.Add(("✖", Color.red));

        colorDB = AssetDatabase.LoadAssetAtPath<ColorDatabase>("Assets/Resources/Data/ColorData.asset");

        colorButtons = new List<MultiStateButton>();
        foreach(ColorEntry c in colorDB.colors)
        {
            colorButtons.Add(new MultiStateButton(c.color,null,ref states));
        }

        symbolDB = AssetDatabase.LoadAssetAtPath<SymbolDatabase>("Assets/Resources/Data/SymbolData.asset");
        symbolButtons = new List<MultiStateButton>();
        foreach (SymbolEntry s in symbolDB.symbols)
        {
            symbolButtons.Add(new MultiStateButton(null,s.image, ref states));
        }
    }

    private void ClearFilterRandom()
    {
        minSymbols = 1;
        maxSymbols = 4;

        foreach(MultiStateButton b in symbolButtons)
        {
            b.CleanState();
        }

        foreach (MultiStateButton b in colorButtons)
        {
            b.CleanState();
        }

        EditorUtility.SetDirty(target);
    }

    public override void OnInspectorGUI()
    {
        if (init)
        {
            InitMultiStateButtons();
            init = false;
        }

        DrawDefaultInspector();
        EditorGUILayout.Space(10);
        DrawRandomOptions();
    }

    private void DrawRandomOptions()
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Random Options", EditorStyles.boldLabel, GUILayout.Width(120));

        if (GUILayout.Button("Generate Symbol List", GUILayout.MaxWidth(140)))
        {
            RandomizeSymbolList();
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);

        DrawMinMaxRandomOptions();
        EditorGUILayout.Space(10);

        DrawColorListRandomOptions();
        EditorGUILayout.Space(10);

        DrawSymbolListRandomOptions();
        EditorGUILayout.Space(10);
    }

    private void DrawMinMaxRandomOptions()
    {
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Min:", GUILayout.Width(30));
        minSymbols = EditorGUILayout.IntField(minSymbols, GUILayout.Width(30));

        GUILayout.Label("Max:", GUILayout.Width(30));
        maxSymbols = EditorGUILayout.IntField(maxSymbols, GUILayout.Width(30));

        if (GUILayout.Button("Reset", GUILayout.MaxWidth(50)))
        {
            ClearFilterRandom();
        }

        EditorGUILayout.EndHorizontal();
    }

    private void DrawSymbolListRandomOptions()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(symbolDB.symbols.Count * symbolButtons[0].size));
        foreach(MultiStateButton b in symbolButtons)
        {
            b.DrawMultiStateButton();
        }
        EditorGUILayout.EndHorizontal();
    }

    public void DrawSymbol(Rect position, Sprite symbolSprite)
    {
        Texture2D tex = symbolSprite.texture;
        Rect texCoords = new Rect(
            symbolSprite.textureRect.x / tex.width,
            symbolSprite.textureRect.y / tex.height,
            symbolSprite.textureRect.width / tex.width,
            symbolSprite.textureRect.height / tex.height
        );
        GUI.DrawTexture(position, tex, ScaleMode.StretchToFill);
    }

    private void DrawColorListRandomOptions()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(colorDB.colors.Count * colorButtons[0].size));
        foreach (MultiStateButton b in colorButtons)
        {
            b.DrawMultiStateButton();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawTextWithOutline(Rect rect, string text, Color color)
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 16;

        Color prev = GUI.contentColor;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(rect.x + 1, rect.y + 1, rect.width, rect.height), text, style);

        GUI.contentColor = color;
        GUI.Label(rect, text, style);

        GUI.contentColor = prev;
    }

    private void RandomizeSymbolList()
    {
        Ingredient ingredient = (Ingredient)target;

        List<SymbolType> mandatorySymbols = new List<SymbolType>();
        List<SymbolType> bannedSymbols = new List<SymbolType>();
        GenerateSymbolFilters(ref mandatorySymbols, ref bannedSymbols);

        List<ColorType> mandatoryColors = new List<ColorType>();
        List<ColorType> bannedColors = new List<ColorType>();
        GenerateColorFilters(ref mandatoryColors, ref bannedColors);

        int min = minSymbols;

        if(maxSymbols >= mandatoryColors.Count && maxSymbols >= mandatorySymbols.Count)
        {
            min = Math.Max(mandatorySymbols.Count, Math.Max(mandatoryColors.Count, minSymbols));
        }

        int listSize = UnityEngine.Random.Range(min, maxSymbols + 1);

        ingredient.RandomizeSymbolList(listSize, mandatorySymbols, bannedSymbols, mandatoryColors, bannedColors);

        EditorUtility.SetDirty(ingredient);
        serializedObject.Update();
    }

    private void GenerateColorFilters(ref List<ColorType> mandatoryColors, ref List<ColorType> bannedColors)
    {
        int i = 0;
        foreach (MultiStateButton b in colorButtons)
        {
            if (b.GetState() == 1) mandatoryColors.Add((ColorType)i);
            else if (b.GetState() == 2) bannedColors.Add((ColorType)i);
            ++i;
        }
    }

    private void GenerateSymbolFilters(ref List<SymbolType> mandatorySymbols, ref List<SymbolType> bannedSymbols)
    {
        int i = 0;
        foreach (MultiStateButton b in symbolButtons)
        {
            if (b.GetState() == 1) mandatorySymbols.Add((SymbolType)i);
            else if (b.GetState() == 2) bannedSymbols.Add((SymbolType)i);
            ++i;
        }
    }
}
