using UnityEngine;

public class InventorySlot
{
    public Ingredient ingredient;
    public int quantity;

    public InventorySlot() {}
    public InventorySlot(Ingredient ingredient)
    {
        this.ingredient = ingredient;
        quantity = 1;
    }

    public void Add() { ++quantity; }

    public void Remove() 
    { 
        --quantity;
        if(quantity == 0)
        {
            Clean(); 
        }
    }

    public void Clean()
    {
        ingredient = null;
        quantity = 0;
    }
}
