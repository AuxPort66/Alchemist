using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static IngredientRandomSizeStorage;

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

    int buttonIndex = 0;

    private void InitMultiStateButtons()
    {
        states = new List<(string text, Color color)>();
        states.Add(("", Color.white));
        states.Add(("✔", Color.green));
        states.Add(("✖", Color.red));

        colorDB = AssetDatabase.LoadAssetAtPath<ColorDatabase>("Assets/_Project/ProjectAssets/Resources/SymbolColored/ColorData.asset");

        colorButtons = new List<MultiStateButton>();

        buttonIndex = 0;

        foreach(ColorEntry c in colorDB.colors)
        {
            string key = FilterStateStorage.GetKey((Ingredient)target, buttonIndex);
            int savedState = FilterStateStorage.instance.buttonStates[key];
            colorButtons.Add(new MultiStateButton(c.color,null,ref states, savedState));
            ++buttonIndex;
        }

        symbolDB = AssetDatabase.LoadAssetAtPath<SymbolDatabase>("Assets/_Project/ProjectAssets/Resources/SymbolColored/SymbolData.asset");
        symbolButtons = new List<MultiStateButton>();
        foreach (SymbolEntry s in symbolDB.symbols)
        {
            string key = FilterStateStorage.GetKey((Ingredient)target, buttonIndex);
            int savedState = FilterStateStorage.instance.buttonStates[key];
            symbolButtons.Add(new MultiStateButton(null,s.image, ref states, savedState));
            ++buttonIndex;
        }
    }
    private void InitMinMaxOptions()
    {
        MinMaxRange minMaxStoredRange = new MinMaxRange { min = minSymbols, max = maxSymbols };
        minMaxStoredRange = IngredientRandomSizeStorage.instance.rangeRandom.GetValueOrDefault(GetGUID((Ingredient)target), minMaxStoredRange);
        minSymbols = minMaxStoredRange.min;
        maxSymbols = minMaxStoredRange.max;
    }

    private void ClearFilterRandom()
    {
        minSymbols = 1;
        maxSymbols = 4;
        IngredientRandomSizeStorage.instance.rangeRandom[GetGUID((Ingredient)target)] = new MinMaxRange { min = minSymbols, max = maxSymbols };

        buttonIndex = 0;
        foreach (MultiStateButton b in symbolButtons)
        {
            b.CleanState();
            string key = FilterStateStorage.GetKey((Ingredient) target, buttonIndex);
            FilterStateStorage.instance.buttonStates[key] = b.GetState();
            FilterStateStorage.instance.Save();
            ++buttonIndex;
        }

        foreach (MultiStateButton b in colorButtons)
        {
            b.CleanState();
            string key = FilterStateStorage.GetKey((Ingredient)target, buttonIndex);
            FilterStateStorage.instance.buttonStates[key] = b.GetState();
            FilterStateStorage.instance.Save();
            ++buttonIndex;
        }

        EditorUtility.SetDirty(target);
    }

    public string GetGUID(ScriptableObject ingredient)
    {
        return AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(ingredient));
    }

    public override void OnInspectorGUI()
    {
        if (init)
        {
            InitMultiStateButtons();
            InitMinMaxOptions();
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

        buttonIndex = 0;

        DrawColorListRandomOptions();
        EditorGUILayout.Space(10);

        DrawSymbolListRandomOptions();
        EditorGUILayout.Space(10);
    }

    private void DrawMinMaxRandomOptions()
    {
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Min:", GUILayout.Width(30));
        int newMin = EditorGUILayout.IntField(minSymbols, GUILayout.Width(30));

        GUILayout.Label("Max:", GUILayout.Width(30));
        int newMax = EditorGUILayout.IntField(maxSymbols, GUILayout.Width(30));

        if(newMin != minSymbols || newMax != maxSymbols)
        {
            minSymbols = newMin;
            maxSymbols = newMax;
            IngredientRandomSizeStorage.instance.rangeRandom[GetGUID((Ingredient)target)] = new MinMaxRange { min = minSymbols, max = maxSymbols };
            IngredientRandomSizeStorage.instance.Save();
        }

        if (GUILayout.Button("Reset", GUILayout.MaxWidth(50)))
        {
            ClearFilterRandom();
        }

        EditorGUILayout.EndHorizontal();
    }

    private void DrawColorListRandomOptions()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(colorDB.colors.Count * colorButtons[0].size));
        foreach (MultiStateButton b in colorButtons)
        {
            if (b.DrawMultiStateButton())
            {
                string key = FilterStateStorage.GetKey((Ingredient)target, buttonIndex);
                FilterStateStorage.instance.buttonStates[key] = b.GetState();
                FilterStateStorage.instance.Save();
            }
            ++buttonIndex;
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawSymbolListRandomOptions()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(symbolDB.symbols.Count * symbolButtons[0].size));
        foreach (MultiStateButton b in symbolButtons)
        {
            if (b.DrawMultiStateButton())
            {
                string key = FilterStateStorage.GetKey((Ingredient)target, buttonIndex);
                FilterStateStorage.instance.buttonStates[key] = b.GetState();
                FilterStateStorage.instance.Save();
            }
            ++buttonIndex;
        }
        EditorGUILayout.EndHorizontal();
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
