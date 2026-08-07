using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;

    [Header("Prefabs")]
    [SerializeField] private GameObject drawerPrefab;
    [SerializeField] private GameObject bottlesRowPrefab;
    [SerializeField] private GameObject bottlePrefab;

    [Header("Texture Poll")]
    [SerializeField] private Sprite[] drawerTextures;

    [Header("Layout")]
    [SerializeField] private Transform drawersGrid;
    [SerializeField] private Transform bottleGrid;

    private const int SLOTS_PER_ROW = 3;
    private const int MINIMUM_ROWS = 4;
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

        InitializeInventoryUI();
    }

    private void InitializeInventoryUI()
    {
        List<InventorySlot> slots = inventory.GetAllSlots();
        int totalRows = Mathf.CeilToInt(slots.Count /(float) SLOTS_PER_ROW);
        for(int rows = 0; rows < totalRows; rows++)
        {
            CreateDrawerRow();
            CreateBottlesRow(ref slots, rows);
        }

        for(int defaultDrawers = MINIMUM_ROWS; totalRows < defaultDrawers; --defaultDrawers)
        {
            CreateDrawerRow();
        }
    }

    private void CreateBottlesRow(ref List<InventorySlot> slots, int rowIndex)
    {
        GameObject bottleRowGO = Instantiate(bottlesRowPrefab, bottleGrid);

        for (int i = 0; i < SLOTS_PER_ROW; i++)
        {
            int slotIndex = rowIndex * SLOTS_PER_ROW + i;
            if (slots.Count > slotIndex)
            {
                InventorySlot slot = slots[slotIndex];
                GameObject bottleGO = Instantiate(bottlePrefab, bottleRowGO.transform);
                inventoryUI.SetupBottle(bottleGO,slot);
            }
        }
    }

    private void CreateDrawerRow()
    {
        Sprite drawerTexture = GetRandomDrawerTexture();
        GameObject drawerGO = Instantiate(drawerPrefab, drawersGrid);
        inventoryUI.SetupDrawer(drawerGO, drawerTexture);
    }

    private Sprite GetRandomDrawerTexture()
    {
        return drawerTextures[UnityEngine.Random.Range(0, drawerTextures.Length)];
    }

    public bool isDrawerAnimating()
    {
        return inventoryUI.isInventoryAnimating();
    }

    internal bool isDrawerClose()
    {
        return inventoryUI.isInventoryClose();
    }
}
