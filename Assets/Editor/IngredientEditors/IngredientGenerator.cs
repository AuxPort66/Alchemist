using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IngredientGenerator : EditorWindow
{
    public Texture2D spriteSheet;
    public DefaultAsset outputFolder;
    private bool generated = false;
    private int timeNotificacion;

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

        if (GUILayout.Button("Generate"))
        {
            generated = GenerateIngredientsFromSpriteSheet();
        }

        EditorGUI.EndDisabledGroup();

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