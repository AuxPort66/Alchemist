using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "TagData", menuName = "GameData/Base/Tag", order = 1)]
public class TagDatabase : Database
{
    public GameObject[] tagTypes;
    public List<SymbolTagEntry> symbols;
    public List<ColorTagEntry> color;

    public GameObject GetTagPrefab(int numElements)
    {
        return tagTypes[numElements - 1];
    }
    public Sprite GetSymbolImageTag(SymbolType type)
    {
        return symbols.FirstOrDefault(s => s.type == type).sprite;
    }

    public Sprite GetColorImageTag(ColorType type)
    {
        return color.FirstOrDefault(s => s.type == type).sprite;
    }
}

[Serializable]
public struct SymbolTagEntry
{
    public SymbolType type;
    public Sprite sprite;
}

[Serializable]
public struct ColorTagEntry
{
    public ColorType type;
    public Sprite sprite;
}
