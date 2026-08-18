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
    [SerializeField] private Image icon;
    [SerializeField] private SortModeIcon[] modes;
    private int currentIndex = 0;
    public void HandleClick()
    {
        currentIndex = (currentIndex + 1) % modes.Length;
        icon.sprite = modes[currentIndex].icon;
        InventoryManager.Instance.SortInventory(modes[currentIndex].mode);
    }
}
