using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;
using static IngredientRandomizationState;

public class IngredientGenerator : EditorWindow
{
    public Texture2D spriteSheet;
    public DefaultAsset outputFolder;
    private bool generated = false;
    private int timeNotificacion;

    private int defaultMinSymbol = 1;
    private int defaultMaxSymbol = 4;
    private bool useDefault = false;

    [MenuItem("Tools/Ingredient Generator")]
    public static void ShowWindow()
    {
        GetWindow<IngredientGenerator>("Ingredient Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Ingredient Generator from Sprite Sheet", EditorStyles.boldLabel);

        spriteSheet = (Texture2D)EditorGUILayout.ObjectField("Sprite Sheet:", spriteSheet, typeof(Texture2D), false);
        outputFolder = (DefaultAsset)EditorGUILayout.ObjectField("OutputFolder:", outputFolder, typeof(DefaultAsset), false);

        bool canGenerate = spriteSheet != null && outputFolder != null;

        EditorGUI.BeginDisabledGroup(!canGenerate);
        EditorGUILayout.Space(1);
        if (GUILayout.Button("Generate"))
        {
            generated = GenerateIngredientsFromSpriteSheet();
        }

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("DefaultMin:", GUILayout.Width(70));
        defaultMinSymbol = EditorGUILayout.IntField(defaultMinSymbol, GUILayout.Width(20));

        GUILayout.Label("DefaultMax:", GUILayout.Width(70));
        defaultMaxSymbol = EditorGUILayout.IntField(defaultMaxSymbol, GUILayout.Width(20));

        GUILayout.Label("Use Default?", GUILayout.Width(70));
        useDefault = EditorGUILayout.Toggle(useDefault);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(1);

        EditorGUI.BeginDisabledGroup(outputFolder == null);
        if (GUILayout.Button("Randomize Symbols of Ingredients"))
        {
            RandomeIngredientsOnFolder();
        }

        EditorGUI.EndDisabledGroup();

        if (generated)
        {
            GUILayout.Label("Succes!", EditorStyles.boldLabel);
            RestartMessageCheck();
        }
    }

    private void RestartMessageCheck()
    {
        if (timeNotificacion < 10)
        {
            timeNotificacion++;
        }
        else
        {
            timeNotificacion = 0;
            generated = false;
        }
    }

    private void RandomeIngredientsOnFolder()
    {
        string outputFolderPath = AssetDatabase.GetAssetPath(outputFolder);
        string[] guids = AssetDatabase.FindAssets("t:Ingredient", new[] { outputFolderPath });
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Ingredient ingredient = AssetDatabase.LoadAssetAtPath<Ingredient>(path);
            if (ingredient.GetType() == typeof(Ingredient))
            {
                RandomizeSymbolList((Ingredient)ingredient);
            }
        }
    }

    private void RandomizeSymbolList(Ingredient ingredient)
    {
        int buttonIndexStart = 0;

        List<SymbolType> mandatorySymbols = new List<SymbolType>();
        List<SymbolType> bannedSymbols = new List<SymbolType>();
        GenerateSymbolFilters(ingredient, ref buttonIndexStart,ref mandatorySymbols, ref bannedSymbols);

        List<ColorType> mandatoryColors = new List<ColorType>();
        List<ColorType> bannedColors = new List<ColorType>();
        GenerateColorFilters(ingredient, ref buttonIndexStart,ref mandatoryColors, ref bannedColors);

        MinMaxRange minMaxStoredRange = new MinMaxRange { min = defaultMinSymbol, max = defaultMaxSymbol };

        if (!useDefault)
        {
            minMaxStoredRange = IngredientRandomizationState.instance.rangeRandom.GetValueOrDefault(GetGUID(ingredient), minMaxStoredRange);
        }

        int min = minMaxStoredRange.min;

        if (minMaxStoredRange.max >= mandatoryColors.Count && minMaxStoredRange.max >= mandatorySymbols.Count)
        {
            min = Math.Max(mandatorySymbols.Count, Math.Max(mandatoryColors.Count, minMaxStoredRange.min));
        }

        int listSize = UnityEngine.Random.Range(min, minMaxStoredRange.max + 1);

        ingredient.RandomizeSymbolList(listSize, mandatorySymbols, bannedSymbols, mandatoryColors, bannedColors);
    }
    public string GetKey(ScriptableObject ingredient, int index)
    {
        string guid = GetGUID(ingredient);
        return $"{guid}_Boton_{index}";
    }
    public string GetGUID(ScriptableObject ingredient)
    {
        return AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(ingredient));
    }

    private void GenerateColorFilters(Ingredient ingredient,ref int buttonIndexStart, ref List<ColorType> mandatoryColors, ref List<ColorType> bannedColors)
    {
        int size = FilterStateStorage.instance.buttonStates.GetSize();
        for(int i = 0; i < size; ++i)
        {
            int state = FilterStateStorage.instance.buttonStates[GetKey(ingredient, buttonIndexStart)];
            if (state == 1) mandatoryColors.Add((ColorType)i);
            else if (state == 2) bannedColors.Add((ColorType)i);
            ++buttonIndexStart;
        }
    }
    private void GenerateSymbolFilters(Ingredient ingredient, ref int buttonIndexStart, ref List<SymbolType> mandatorySymbols, ref List<SymbolType> bannedSymbols)
    {
        int size = FilterStateStorage.instance.buttonStates.GetSize();
        for (int i = 0; i < size; ++i)
        {
            int state = FilterStateStorage.instance.buttonStates[GetKey(ingredient, buttonIndexStart)];
            if (state == 1) mandatorySymbols.Add((SymbolType)i);
            else if (state == 2) bannedSymbols.Add((SymbolType)i);
            ++buttonIndexStart;
        }
    }

    private bool GenerateIngredientsFromSpriteSheet()
    {
        if(spriteSheet == null)
        {
            Debug.LogError("There is no sprite sheet asigned.");
            return false;
        }

        string outputFolderPath = AssetDatabase.GetAssetPath(outputFolder);
        if (!AssetDatabase.IsValidFolder(outputFolderPath))
        {
            Debug.LogError("The outputfolder is not valid.");
            return false;
        }

        string path = AssetDatabase.GetAssetPath(spriteSheet);
        UnityEngine.Object[] assets = AssetDatabase.LoadAllAssetsAtPath(path);

        foreach (UnityEngine.Object a in assets)
        {
            if (a is Sprite sprite)
            {
                Ingredient ingredient = InitAssetIngredient(sprite);
                string fullAssetPath = outputFolderPath + '/' + sprite.name + ".asset";
                AssetDatabase.CreateAsset(ingredient, fullAssetPath);
            }
        }
        return true;
    }

    private Ingredient InitAssetIngredient(Sprite sprite)
    {
        Ingredient ingredient = ScriptableObject.CreateInstance<Ingredient>();
        ingredient.nameIngredient = sprite.name;
        ingredient.icon = sprite;
        int listSize = UnityEngine.Random.Range(1, 4 + 1);
        ingredient.RandomizeSymbolList(listSize,null,null,null,null);
        return ingredient;
    }
}