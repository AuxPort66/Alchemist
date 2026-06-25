using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<InventorySlot> inventory = new List<InventorySlot>();
    
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


}
