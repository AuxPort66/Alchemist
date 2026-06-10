using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public struct SymbolColored
{
    public SymbolType symbol;
    public ColorType color;

    public SymbolColored(ColorType color, SymbolType symbol)
    {
        this.color = color;
        this.symbol = symbol;
    }
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Game/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string nameIngredient;
    public Sprite icon;
    public List<SymbolColored> symbolList = new List<SymbolColored>();

    private void OnValidate()
    {
        if (!string.IsNullOrEmpty(nameIngredient))
        {
            this.name = nameIngredient;
        }
    }

    public void AddSymbol(SymbolColored newSymbol) { symbolList.Add(newSymbol); }
    public void RemoveSymbol(int index) { symbolList.RemoveAt(index); }
    public void CleanSymbolList() { symbolList.Clear(); }
    public void ModifySymbol(int index, SymbolColored newSymbol) { symbolList[index] = newSymbol; }
    public void RandomizeSymbolList(int listSize, List<SymbolType> mandatorySymbols, List<SymbolType> bannedSymbols, List<ColorType> mandatoryColors, List<ColorType> bannedColors)
    {
        int colorTypeSize = Enum.GetValues(typeof(ColorType)).Length;
        int symbolTypeSize = Enum.GetValues(typeof(SymbolType)).Length;

        CleanSymbolList();

        List<SymbolType> symbolsToPick = Enum.GetValues(typeof(SymbolType)).Cast<SymbolType>().ToList();
        if(bannedSymbols != null) symbolsToPick = symbolsToPick.Except(bannedSymbols).ToList();
        if (listSize < mandatorySymbols.Count || symbolsToPick.Count == 0)
        {
            Debug.LogError("No se puede cumplir el filtro de simbolos");
            return;
        }

        List<ColorType> colorsToPick = Enum.GetValues(typeof(ColorType)).Cast<ColorType>().ToList();
        if (bannedColors != null) colorsToPick = colorsToPick.Except(bannedColors).ToList();
        if (listSize < mandatoryColors.Count || colorsToPick.Count == 0)
        {
            Debug.LogError("No se puede cumplir el filtro de colors");
            return;
        }

        for (int i = 0; i < listSize; i++)
        {
            ColorType colorType;
            if (mandatoryColors != null && mandatoryColors.Count > 0)
            {
                colorType = mandatoryColors[0];
                mandatoryColors.Remove(colorType);
            }
            else
            {
                colorType = colorsToPick[UnityEngine.Random.Range(0, colorsToPick.Count)];
            }

            SymbolType symbolType;
            if (mandatorySymbols!= null && mandatorySymbols.Count > 0)
            {
                symbolType = mandatorySymbols[0];
                mandatorySymbols.Remove(symbolType);
            }
            else
            {
                symbolType = symbolsToPick[UnityEngine.Random.Range(0, symbolsToPick.Count)];
            }
                
            SymbolColored newSymbol = new SymbolColored(colorType, symbolType);
            AddSymbol(newSymbol);
        }
    }
}
