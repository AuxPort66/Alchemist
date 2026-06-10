using System;
using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/IngredientRandomizationState.asset", FilePathAttribute.Location.ProjectFolder)]
public class IngredientRandomizationState : ScriptableSingleton<IngredientRandomizationState>
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
