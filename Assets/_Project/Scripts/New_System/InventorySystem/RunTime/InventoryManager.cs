using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //TEST DATABASE TODO ERASE IT
        inventory = new Inventory();
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_0"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_0"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_3"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_4"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_5"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_6"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_7"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_8"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_9"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_21"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_22"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_23"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_24"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_25"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_26"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_27"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_28"));
        inventory.AddIngredient(Resources.Load<Ingredient>("Ingredients/Flowers_29"));

        LoadInventory();
        //inventoryUI.InitializeInventoryUI(inventory.GetAllSlots());
    }

    private void LoadInventory()
    {
        inventory.Sort(0);
        //Load Save to Inventory
        //inventory.LoadFromSave(SaveData)
        //Load UI from Inventory
        inventoryUI.Load(inventory.GetAllSlots());
    }

    public bool isDrawerAnimating()
    {
        return inventoryUI.isInventoryAnimating();
    }

    public bool isDrawerClose()
    {
        return inventoryUI.isInventoryClose();
    }

    public void SortInventory(SortMode mode)
    {
        inventory.Sort(mode);
        inventoryUI.Reorder(inventory.inventory);
    }

    public void SetName(string name)
    {
        inventoryUI.SetTextBottleHover(name);
    }

    public void ChangeSortDirection(bool ascending)
    {
        inventory.ChangeSortDirection(ascending);
        inventoryUI.Reorder(inventory.inventory);
    }
}
