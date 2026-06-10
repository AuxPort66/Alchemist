using System;
using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/IngredientRandomSizeStorage.asset", FilePathAttribute.Location.ProjectFolder)]
public class IngredientRandomSizeStorage : ScriptableSingleton<IngredientRandomSizeStorage>
{
    [Serializable]
    public struct MinMaxRange
    {
        public int min;
        public int max;
    }

    [SerializeField]
    public SerializableDictionary<string, MinMaxRange> rangeRandom = new();
    public void Save()
    {
        Save(true);
    }
}
