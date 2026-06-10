using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/FilterStateStorage.asset", FilePathAttribute.Location.ProjectFolder)]
public class FilterStateStorage : ScriptableSingleton<FilterStateStorage>
{
    [SerializeField]
    public SerializableDictionary<string,int> buttonStates = new();

    public void Save()
    {
        Save(true);
    }

    public static string GetKey(ScriptableObject obj, int index)
    {
        string guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(obj));
        return $"{guid}_Boton_{index}";
    }
}

