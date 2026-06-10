//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Emptyslot : MonoBehaviour, IDropHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
//{
//    private RectTransform rectTransform;
//    public CanvasGroup canvasGroup;
//    [SerializeField]
//    public IngredientDrag actualingredient;

//    private GameObject originaux;

//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//    }

//    public void Clear()
//    {
//        if(actualingredient != null)Destroy(actualingredient.gameObject);
//        actualingredient = null;
//        originaux = null;
//    }

//    public void OnDrop(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null)
//        {
//           if (eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//           {
//                if (actualingredient == null)
//                {
//                    actualingredient = eventData.pointerDrag.GetComponent<IngredientDrag>();
//                    if (actualingredient.fromInventory) GameManager.Instance.inventory.RestIngredient(actualingredient.ingredient);
//                    actualingredient.fromInventory = false;
//                    PutintotheJar(actualingredient.gameObject);
//                }
//                else
//                {
//                    eventData.pointerDrag.GetComponent<IngredientDrag>().RecoverPosition();
//                }
//            }
//            else if (eventData.pointerDrag.GetComponent<Cocktail>() != null)
//            {
//                if (!eventData.pointerDrag.GetComponent<Cocktail>().shaking)
//                {
//                    PutintotheJar(eventData.pointerDrag.GetComponent<Cocktail>().CreateIngredientCustom());
//                    eventData.pointerDrag.GetComponent<Cocktail>().ClearCocktail();
//                }
//                else
//                {
//                    eventData.pointerDrag.GetComponent<Cocktail>().RecoverPosition();
//                }
//            }
//        }
//    }

//    public void PutintotheJar(GameObject obj)
//    {
//        obj.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
//        actualingredient = obj.GetComponent<IngredientDrag>();
//        actualingredient.transform.localScale = new Vector3(2, 2, 2);
//        actualingredient.GetComponent<CanvasGroup>().alpha = 0.5f;
//        actualingredient.initialPos = rectTransform.anchoredPosition;
//        actualingredient.origin = gameObject;

//        canvasGroup.blocksRaycasts = false;
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = false;
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null && actualingredient == null)
//        {
//            eventData.pointerDrag.GetComponent<IngredientDrag>().fromInventoryAux = false;
//            originaux = eventData.pointerDrag.GetComponent<IngredientDrag>().origin;
//            eventData.pointerDrag.GetComponent<IngredientDrag>().origin = gameObject;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//        {
//            eventData.pointerDrag.GetComponent<IngredientDrag>().fromInventoryAux = eventData.pointerDrag.GetComponent<IngredientDrag>().fromInventory;
//            eventData.pointerDrag.GetComponent<IngredientDrag>().origin = originaux;
//        }
//    }

//}
