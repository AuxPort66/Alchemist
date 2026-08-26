using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct SortModeIcon
{
    public SortMode mode;
    public Sprite icon;
}

public class SortButtonUI : MonoBehaviour
{
    [Header("SortModes")]
    [SerializeField] private Image iconOrder;
    [SerializeField] private SortModeIcon[] modes;
    private int currentIndex = 0;

    [Header("Direction")]
    [SerializeField] private Image iconDirection;
    [SerializeField] private Sprite ascendingIcon;
    [SerializeField] private Sprite descendingIcon;
    private bool ascending = false;
    public void HandleOrderClick()
    {
        currentIndex = (currentIndex + 1) % modes.Length;
        iconOrder.sprite = modes[currentIndex].icon;
        InventoryManager.Instance.SortInventory(modes[currentIndex].mode);
    }

    public void HandleDirectionClick()
    {
        ascending = !ascending;
        iconDirection.sprite = ascending ? ascendingIcon : descendingIcon;
        InventoryManager.Instance.ChangeSortDirection(ascending);
    }
}
