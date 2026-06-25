using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RectTransform maskArea;
    [SerializeField] private InventorySlotUI slotPrefab;
    [SerializeField] private Transform slotsParent;

    public void SetupDrawer(GameObject drawerGO, Sprite texture)
    {
        Image img = drawerGO.GetComponent<Image>();
        img.sprite = texture;
    }

    internal void SetupBottle(GameObject bottleGO, InventorySlot slot)
    {
        BottleUI bottleUI = bottleGO.GetComponent<BottleUI>();
        bottleUI.maskArea = maskArea;

        InventorySlotUI slotUI = bottleGO.GetComponent<InventorySlotUI>();
        slotUI.Init(slot);
    }
}
