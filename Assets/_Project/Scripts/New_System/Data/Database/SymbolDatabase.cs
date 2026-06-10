using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[CreateAssetMenu(fileName = "SymbolData", menuName = "GameData/Base/Symbols", order = 1)]
public class SymbolDatabase : Database
{
    public List<SymbolEntry> symbols;

    public Sprite GetSymbolImage(SymbolType type)
    {
        return symbols.FirstOrDefault(s => s.type == type).image;
    }
}

[System.Serializable]
public class SymbolEntry
{
    public SymbolType type;
    public Sprite image;
}