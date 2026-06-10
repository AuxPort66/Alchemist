//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class Inventory : MonoBehaviour
//{
//    public SortedDictionary<Ingredient, int> ingredientlist;
//    public SortedDictionary<Potions,int> potionslist;

//    public GameObject prefabSlot;
//    public GameObject contentIngredients;
//    public GameObject viewportIngredients;

//    public GameObject contentPotions;
//    public GameObject viewportPotions;


//    public void Start()
//    {
//        ingredientlist = new SortedDictionary<Ingredient, int>();
//        potionslist = new SortedDictionary<Potions, int>();
//        for(int i = 0; i < GameManager.Instance.allIngredients.Length; i++)
//        {
//            AddIngredient(GameManager.Instance.allIngredients[i]);
//        }
//    }


//    public void ChargeInventory()
//    {
//        foreach (var ingredient in ingredientlist)
//        {
//            GameObject slot = Instantiate(prefabSlot, contentIngredients.transform);
//            slot.transform.GetChild(0).GetComponent<Image>().sprite = ingredient.Key.image;
//            string quantity = "";
//            if (ingredient.Value > 1) quantity = ingredient.Value.ToString();
//            slot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = quantity;
//            slot.GetComponent<InventoryDrag>().ingredient = ingredient.Key;
//        }

//        foreach (var potion in potionslist)
//        {
//            GameObject slot = Instantiate(prefabSlot, contentPotions.transform);
//            slot.transform.GetChild(0).GetComponent<Image>().sprite = potion.Key.image;
//            string quantity = "";
//            if (potion.Value > 1) quantity = potion.Value.ToString();
//            slot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = quantity;
//        }
//    }

//    public void AddIngredient(Ingredient addingredient)
//    {

//        if (ingredientlist.ContainsKey(addingredient))
//        {
//            ingredientlist[addingredient]++;
//        }
//        else ingredientlist.Add(addingredient, 1);
//    }

//    public void AddPotion(Potions addpotions)
//    {
//        potionslist.Add(addpotions, potionslist[addpotions]++);
//    }

//    public void OpenInventory()
//    {
//        if((gameObject.transform as RectTransform).pivot.x == 0f)
//        {
//            ChargeInventory();
//            (gameObject.transform as RectTransform).pivot = new Vector2(1.0f, 1.0f);
//        }
//        else
//        {
            
//            (gameObject.transform as RectTransform).pivot = new Vector2(0.0f, 1.0f);
//            foreach (Transform child in contentIngredients.transform)
//            {
//                Destroy(child.gameObject);
//            }

//            foreach (Transform child in contentPotions.transform)
//            {
//                Destroy(child.gameObject);
//            }
//        }
//    }

//    public void RestIngredient(Ingredient restingredient)
//    {
//        /*if (ingredientlist[restingredient] > 1) ingredientlist[restingredient]--;
//        else ingredientlist.Remove(restingredient);*/
//    }

//    public void RestPotion(Potions restPotion)
//    {
//        if (potionslist[restPotion] > 1) potionslist[restPotion]--;
//        else potionslist.Remove(restPotion);
//    }

//}
