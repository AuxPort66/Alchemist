using UnityEditor;
using UnityEngine;

public abstract class Database : ScriptableObject
{
    public static T LoadDatabase<T>() where T : Database
    {
        string searchTag = $"t:{typeof(T).Name}";

        string[] guids = AssetDatabase.FindAssets(searchTag);
        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }
        else
        {
            Debug.LogError($"There is no asset of {typeof(T).Name}");
            return null;
        }
    }
}
