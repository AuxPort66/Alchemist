using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SortMode { ByColor, BySymbol, ByName, ByValue}


public class Inventory
{
    public List<InventorySlot> inventory = new List<InventorySlot>();

    private static readonly SymbolType[] symbolHierarchy =
       {
        SymbolType.Fire, SymbolType.Water, SymbolType.Air, SymbolType.Earth
    };

    private static readonly ColorType[] colorHierarchy =
       {
        ColorType.White,ColorType.Cyan,ColorType.Magenta,ColorType.Yellow,ColorType.Red,ColorType.Green,ColorType.Blue,ColorType.Black
    };

    public void AddIngredient(Ingredient ingredient)
    {
        int index = SearchForIngredient(ingredient);
        if (index == -1)
        {
            InventorySlot newIngredient = new InventorySlot(ingredient);
            inventory.Add(newIngredient);
        }
        else
        {
            inventory[index].Add();
        }
    }

    public List<InventorySlot> GetAllSlots()
    {
        return inventory;
    }

    private int SearchForIngredient(Ingredient ingredient)
    {
        int index = 0;
        foreach(InventorySlot slot in inventory)
        {
            if (slot.ingredient == ingredient)
            {
                return index;
            }
            ++index;
        }
        return -1;
    }

    public void Sort(SortMode mode) 
    {
        switch (mode)
        {
            case SortMode.ByColor:
                inventory.Sort(CompareByColor);
                break;
            case SortMode.BySymbol:
                inventory.Sort(CompareBySymbol);
                break;
            case SortMode.ByName:
                inventory = inventory.OrderBy(s => s.ingredient.name).ToList();
                break;
            case SortMode.ByValue:
                inventory = inventory.OrderByDescending(s => s.quantity).ToList();
                break;
        }
    }

    private int CompareBySymbol(InventorySlot a, InventorySlot b)
    {
        Ingredient ia = a.ingredient;
        Ingredient ib = b.ingredient;

        int typeA = Array.IndexOf(symbolHierarchy, ia.dominantSymbol);
        int typeB = Array.IndexOf(symbolHierarchy, ib.dominantSymbol);
        if (typeA != typeB) return typeA.CompareTo(typeB);

        int purityA = ia.nonDominantSymbolTotal;
        int purityB = ib.nonDominantSymbolTotal;
        if (purityA != purityB) return purityA.CompareTo(purityB);

        int countSymbolA = ia.symbolCounts[(int)ia.dominantSymbol];
        int countSymbolB = ib.symbolCounts[(int)ib.dominantSymbol];
        if (countSymbolA != countSymbolB) return countSymbolA.CompareTo(countSymbolB);

        if(purityA != 0)
        {
            foreach (SymbolType symbol in symbolHierarchy)
            {
                if (symbol == ia.dominantSymbol) continue;
                int cmp = ia.symbolCounts[(int)symbol].CompareTo(ib.symbolCounts[(int)symbol]);
                if (cmp != 0) return cmp;
            }
        }

        return string.Compare(ia.nameIngredient, ib.nameIngredient, StringComparison.Ordinal);
    }

    private int CompareByColor(InventorySlot a, InventorySlot b)
    {
        Ingredient ia = a.ingredient;
        Ingredient ib = b.ingredient;

        int typeA = Array.IndexOf(colorHierarchy, ia.dominantColor);
        int typeB = Array.IndexOf(colorHierarchy, ib.dominantColor);
        if (typeA != typeB) return typeA.CompareTo(typeB);

        int purityA = ia.nonDominantColorTotal;
        int purityB = ib.nonDominantColorTotal;
        if (purityA != purityB) return purityA.CompareTo(purityB);

        int countSymbolA = ia.colorCounts[(int)ia.dominantColor];
        int countSymbolB = ib.colorCounts[(int)ib.dominantColor];
        if (countSymbolA != countSymbolB) return countSymbolA.CompareTo(countSymbolB);

        if (purityA != 0)
        {
            foreach (ColorType color in colorHierarchy)
            {
                if (color == ia.dominantColor) continue;
                int cmp = ia.colorCounts[(int)color].CompareTo(ib.colorCounts[(int)color]);
                if (cmp != 0) return cmp;
            }
        }

        return string.Compare(ia.nameIngredient, ib.nameIngredient, StringComparison.Ordinal);
    }

}
