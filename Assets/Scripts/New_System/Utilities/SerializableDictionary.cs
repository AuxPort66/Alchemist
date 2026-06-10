
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class SerializableDictionary <T, K>
{
    [Serializable]
    struct DictionaryItem
    {
        public T key;
        public K value;
    }

    [SerializeField]
    private List<DictionaryItem> serializedDictionary;
    private Dictionary<T, K> internalDictionary;

    private Dictionary<T, int> indexDictionary;

    public void Init()
    {
        if(internalDictionary != null)
        {
            return;
        }

        LoadInternalDictionary();
    }
    private void LoadInternalDictionary()
    {
        internalDictionary = new Dictionary<T, K>();
        indexDictionary = new Dictionary<T, int>();
        if (serializedDictionary != null)
        {
            int index = 0;
            foreach (DictionaryItem item in serializedDictionary)
            {
                internalDictionary.Add(item.key, item.value);
                indexDictionary.Add(item.key, index);
                ++index;
            }
        }
        else
        {
            serializedDictionary = new List<DictionaryItem>();
        }
    }

    public int GetSize()
    {
        return serializedDictionary.Count;
    }

    public K GetValueOrDefault(T key, K defaultValue)
    {
        Init();
        return internalDictionary.TryGetValue(key, out var v) ? v : defaultValue;
    }

    public K this [T key]
    {
        get
        {
            Init();
            return internalDictionary.TryGetValue(key, out var v) ? v : default;
        }

        set
        {
            Init();
            internalDictionary[key] = value;
            if(indexDictionary.TryGetValue(key, out int index))
            {
                serializedDictionary[index] = new DictionaryItem { key = key, value = value };

            }
            else
            {
                indexDictionary[key] = internalDictionary.Count - 1;
                serializedDictionary.Add(new DictionaryItem { key = key, value = value });
            }
        }
    }
}