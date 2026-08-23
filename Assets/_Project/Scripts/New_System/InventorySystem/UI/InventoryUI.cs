using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] private InventoryHandler inventoryHandler;

    [SerializeField] private RectTransform maskArea;
    [SerializeField] private InventorySlotUI slotPrefab;
    [SerializeField] private Transform slotsParent;

    [Header("Prefabs")]
    [SerializeField] private GameObject drawerPrefab;
    [SerializeField] private GameObject bottlesRowPrefab;
    [SerializeField] private GameObject bottlePrefab;

    [Header("Texture Poll")]
    [SerializeField] private Sprite[] drawerTextures;

    [Header("Layout")]
    [SerializeField] private Transform drawersGrid;
    [SerializeField] private Transform bottleGrid;

    [SerializeField] private TextMeshProUGUI textHoverBottle;

    private const int SLOTS_PER_ROW = 3;
    private const int MINIMUM_ROWS = 4;

    public void Load(List<InventorySlot> inventorySlots)
    {
        int index = 0;
        foreach (InventorySlot slot in inventorySlots) 
        {
            if (index % SLOTS_PER_ROW == 0) CreateDrawerRow();
            index++;

            CreateBottle(slot);
        }

        int rows = Mathf.CeilToInt(inventorySlots.Count / (float)SLOTS_PER_ROW);
        for (int defaultRows = MINIMUM_ROWS; rows < defaultRows; --defaultRows )
        {
            CreateDrawerRow();
        }
    }
    private void CreateDrawerRow()
    {
        GameObject drawerGO = Instantiate(drawerPrefab, drawersGrid);
        SetRandomDrawerTexture(drawerGO);
    }

    private void CreateBottle(InventorySlot slot)
    {
        GameObject bottleGO = Instantiate(bottlePrefab, bottleGrid);
        InitBottle(bottleGO, slot);
    }

    private void SetRandomDrawerTexture(GameObject drawerGO)
    {
        Image img = drawerGO.GetComponent<Image>();
        img.sprite = drawerTextures[UnityEngine.Random.Range(0, drawerTextures.Length)];
    }

    public bool isInventoryAnimating()
    {
        return inventoryHandler.isAnimating;
    }

    public bool isInventoryClose()
    {
        return !inventoryHandler.isOpen;
    }

    private void InitBottle(GameObject bottleGO, InventorySlot slot)
    {
        BottleUI bottleUI = bottleGO.GetComponent<BottleUI>();
        bottleUI.maskArea = maskArea;

        InventorySlotUI slotUI = bottleGO.GetComponent<InventorySlotUI>();
        slotUI.Init(slot);
    }

    public void Reorder(List<InventorySlot> sortedInventory)
    {
       for(int i = 0; i < sortedInventory.Count; i++)
       {
            Ingredient ingredient = sortedInventory[i].ingredient;
            InventorySlotUI slotUI = FindSlotFor(ingredient);
            slotUI.transform.SetSiblingIndex(i);
       }
    }
    private InventorySlotUI FindSlotFor(Ingredient ingredient)
    {
        foreach (Transform child in bottleGrid)
        {
            InventorySlotUI slotUI = child.GetComponent<InventorySlotUI>();
            if (slotUI.slot.ingredient == ingredient)
                return slotUI;
        }
        return null;
    }

    public void SetTextBottleHover(string name)
    {
        textHoverBottle.text = name;
    }
}
