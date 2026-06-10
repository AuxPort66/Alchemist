using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/FilterStateStorage.asset", FilePathAttribute.Location.ProjectFolder)]
public class FilterStateStorage : ScriptableSingleton<FilterStateStorage>
{
    [SerializeField]
    NewDictionary newDictionary = new NewDictionary();
    public Dictionary<string, int> buttonStates = new();

    public void LoadFromDictionary()
    {
        buttonStates = newDictionary.ToDictionary();
    }

    public void Save()
    {
        newDictionary.FromDictionary(buttonStates);
        Save(true);
    }

}

[Serializable]
public class NewDictionary
{
    [SerializeField]
    List<NewDictionaryItem> dictionary;

    public Dictionary<string,int> ToDictionary()
    {
        Dictionary<string, int> newDict = new Dictionary<string, int>();
        if(dictionary != null)
        {
            foreach (var item in dictionary)
            {
                newDict.Add(item.name, item.state);
            }
        }
        return newDict;
    }

    public void FromDictionary(Dictionary<string, int> dict)
    {
        dictionary = new List<NewDictionaryItem>();
        foreach (var i in dict)
        {
            NewDictionaryItem item = new NewDictionaryItem();
            item.name = i.Key;
            item.state = i.Value;
            dictionary.Add(item);
        }
    }
}
[Serializable]
public class NewDictionaryItem
{
    [SerializeField]
    public string name;
    [SerializeField]
    public int state;
}
