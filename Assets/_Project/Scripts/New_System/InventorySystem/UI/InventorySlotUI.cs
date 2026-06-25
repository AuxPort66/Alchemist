using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image ingredientIcon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private InventorySlot slot;

    public void Init(InventorySlot slot)
    {
        this.slot = slot;
        Load();
    }

    public void Load()
    {
        if(slot.ingredient == null)
        {
            ingredientIcon.enabled = false;
            quantityText.text = "";
            return;
        }

        ingredientIcon.enabled = true;
        ingredientIcon.sprite = slot.ingredient.icon;
        quantityText.text = slot.quantity.ToString();
    }
}
