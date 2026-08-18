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

        int purityA = ia.nonDominantTotal;
        int purityB = ib.nonDominantTotal;
        if (purityA != purityB) return purityA.CompareTo(purityB);

        foreach (SymbolType symbol in symbolHierarchy)
        {
            if (symbol == ia.dominantSymbol) continue;
            int cmp = ia.symbolCounts[(int)symbol].CompareTo(ib.symbolCounts[(int)symbol]);
            if (cmp != 0) return cmp;
        }

        return string.Compare(ia.nameIngredient, ib.nameIngredient, StringComparison.Ordinal);
    }

   
}
