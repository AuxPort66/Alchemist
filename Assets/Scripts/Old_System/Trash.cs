//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Trash : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler
//{

//    public void OnDrop(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null)
//        {
//           if (eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//           {
//                IngredientDrag ingredient = eventData.pointerDrag.GetComponent<IngredientDrag>();
//                if (ingredient.fromInventory) GameManager.Instance.inventory.RestIngredient(ingredient.ingredient);
//                Destroy(eventData.pointerDrag);
//           }
//           else if(eventData.pointerDrag.GetComponent<PotionDrag>() != null)
//           {
//                GameManager.Instance.inventory.RestPotion(eventData.pointerDrag.GetComponent<PotionDrag>().potion);
//                Destroy(eventData.pointerDrag);
//           }
//           else if(eventData.pointerDrag.GetComponent<Glass>() != null)
//           {
//                Glass glass = eventData.pointerDrag.GetComponent<Glass>();
//                glass.animator.Play("Glassempty");
//                glass.full = false;
//                glass.RestorePosition();
//                glass.trashed = false;
//                glass.color = GameManager.Colors.White;
//           }
//           else if(eventData.pointerDrag.GetComponent<Cocktail>() != null)
//            {
//                Cocktail cocktail = eventData.pointerDrag.GetComponent<Cocktail>();
//                cocktail.ClearCocktail();
//            }
//        }
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null)
//        {
//            if(eventData.pointerDrag.GetComponent<Glass>() != null) eventData.pointerDrag.GetComponent<Glass>().trashed = true;
//            if(eventData.pointerDrag.GetComponent<IngredientDrag>() != null) eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = true;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null)
//        {
//            if (eventData.pointerDrag.GetComponent<Glass>() != null) eventData.pointerDrag.GetComponent<Glass>().trashed = false;
//            if (eventData.pointerDrag.GetComponent<IngredientDrag>() != null) eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = false;
//        }
//    }
//}
