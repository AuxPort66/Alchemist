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
}

