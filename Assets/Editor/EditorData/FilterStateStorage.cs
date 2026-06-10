using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[FilePath("ProjectSettings/FilterStateStorage.asset", FilePathAttribute.Location.ProjectFolder)]
public class FilterStateStorage : ScriptableSingleton<FilterStateStorage>
{
    [SerializeField]
    SerializableDictionary<string,int> newDictionary = new SerializableDictionary<string,int>();
    public Dictionary<string, int> buttonStates;

    public void LoadFromDictionary()
    {
        if(buttonStates == null)
        {
            buttonStates = newDictionary.ToDictionary();
        }
    }

    public void Save()
    {
        newDictionary.FromDictionary(buttonStates);
        Save(true);
    }

}

[Serializable]
public class SerializableDictionary<T,K>
{
    [SerializeField]
    List<DictionaryItem<T,K>> dictionary;

    public Dictionary<T,K> ToDictionary()
    {
        Dictionary<T, K> newDict = new Dictionary<T, K>();
        if(dictionary != null)
        {
            foreach (var item in dictionary)
            {
                newDict.Add(item.key, item.value);
            }
        }
        return newDict;
    }

    public void FromDictionary(Dictionary<T, K> dict)
    {
        dictionary = new List<DictionaryItem<T,K>>();
        foreach (var i in dict)
        {
            DictionaryItem<T,K> item = new DictionaryItem<T,K>();
            item.key = i.Key;
            item.value = i.Value;
            dictionary.Add(item);
        }
    }
}
[Serializable]
public class DictionaryItem<T,K>
{
    [SerializeField]
    public T key;
    [SerializeField]
    public K value;
}
