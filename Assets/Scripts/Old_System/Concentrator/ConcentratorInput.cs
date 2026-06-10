//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class ConcentratorInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
//{

//    public Sprite open;
//    public Sprite close;

//    private bool isopen;
//    public Concentrator concentrator;

//    private Image image;
//    public void Awake()
//    {
//        image = GetComponent<Image>();
//        isopen = false;
//        concentrator = GetComponentInParent<Concentrator>();
//    }

//    public void OnDrop(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//        {
//            if (!concentrator.use)
//            {
//                image.sprite = close;
//                isopen = false;
//                if(eventData.pointerDrag.GetComponent<IngredientDrag>().fromInventory) GameManager.Instance.inventory.RestIngredient(eventData.pointerDrag.GetComponent<IngredientDrag>().ingredient);
//                concentrator.ConcentrateIngredient(eventData.pointerDrag.GetComponent<IngredientDrag>().simbolList);
//            }
//            else
//            {
//                eventData.pointerDrag.GetComponent<IngredientDrag>().RecoverPosition();
//            }
//        }
//        else if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Cocktail>() != null)
//        {
//            if (!concentrator.use && !eventData.pointerDrag.GetComponent<Cocktail>().shaking)
//            {
//                image.sprite = close;
//                isopen = false;
//                concentrator.ConcentrateIngredient(eventData.pointerDrag.GetComponent<Cocktail>().ingredientlist);
//                eventData.pointerDrag.GetComponent<Cocktail>().ClearCocktail();
//            }
//            else
//            {
//                eventData.pointerDrag.GetComponent<Cocktail>().RecoverPosition();
//            }
//        }
//    }

//    /*public bool AllWhite(IngredientDrag ingredient)
//    {
//        for(int i=0; i < ingredient.simbolList.Count; i++)
//        {
//            if (ingredient.simbolList[i].color != GameManager.Colors.White) return false;
//        }
//        return true;
//    }*/

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if(!concentrator.use && eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//        {

//            image.sprite = open;
//            isopen = true;
//            eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = true;
//        }
//        else if(!concentrator.use && eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Cocktail>() != null && !eventData.pointerDrag.GetComponent<Cocktail>().shaking)
//        {
//            image.sprite = open;
//            isopen = true;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (isopen)
//        {
//            image.sprite = close;
//            isopen = false;
//        }

//        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null && !concentrator.use)
//        {
//            eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = false;
//        }
//    }

//}
