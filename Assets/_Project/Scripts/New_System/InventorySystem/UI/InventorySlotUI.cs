using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image ingredientIcon;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Transform bottleTransform;

    public InventorySlot slot;

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

        LoadTag();
    }

    private void LoadTag()
    {
        int numSymbols = slot.ingredient.symbolList.Count;

        TagDatabase tagdb = Database.LoadDatabase<TagDatabase>();
        GameObject tagGO = Instantiate(tagdb.GetTagPrefab(numSymbols), bottleTransform);

        for(int i = 0; i < numSymbols; i++)
        {
            SymbolColored symbol = slot.ingredient.symbolList[i];

            GameObject symbolGO = tagGO.transform.GetChild(i).gameObject;
            symbolGO.transform.GetChild(0).GetComponent<Image>().sprite = tagdb.GetSymbolImageTag(symbol.symbol);
            symbolGO.GetComponent<Image>().sprite = tagdb.GetColorImageTag(symbol.color);
        }
    }
}
