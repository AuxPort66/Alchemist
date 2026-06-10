//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class CortarInput : MonoBehaviour, IDropHandler, IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler
//{
//    private RectTransform rectTransform;
//    public IngredientDrag actualingredient;
//    public Ingredient.SimbolColored simbolist;
//    public CanvasGroup canvasGroup;

//    public GameObject simbolPopUpPrefab;

//    private GameObject originaux;

//    public GameObject hover;
//    public GameObject simbolhover;

//    public GameObject selectedimage;

//    public int selected = 0;

//    public Cortar cortar;


//    public void Awake()
//    {
//        actualingredient = null;
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        canvasGroup.blocksRaycasts = false;
//        simbolhover = hover.transform.GetChild(0).gameObject;
//        cortar = transform.parent.GetChild(0).GetComponent<Cortar>();
//    }

//    public void Clear()
//    {
//        if(actualingredient != null)Destroy(actualingredient.gameObject);
//        actualingredient = null;
//        originaux = null;

//        EliminateHover();
//    }

//    public void OnDrop(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null)
//        {
//            if(eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//            {
//                if (actualingredient == null)
//                {
//                    actualingredient = eventData.pointerDrag.GetComponent<IngredientDrag>();
//                    if (actualingredient.fromInventory) GameManager.Instance.inventory.RestIngredient(actualingredient.ingredient);
//                    actualingredient.fromInventory = false;
//                    Putintotheslicer(actualingredient.gameObject);
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
//                    Putintotheslicer(eventData.pointerDrag.GetComponent<Cocktail>().CreateIngredientCustom());
//                    eventData.pointerDrag.GetComponent<Cocktail>().ClearCocktail();
//                }
//                else
//                {
//                    eventData.pointerDrag.GetComponent<Cocktail>().RecoverPosition();
//                }
//            }
//        }
//    }

//    public void Putintotheslicer(GameObject obj)
//    {
//        selected = 0;
//        obj.transform.SetParent(transform.parent);
//        obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-54,0);
//        obj.transform.SetSiblingIndex(1);
//        actualingredient = obj.GetComponent<IngredientDrag>();
//        actualingredient.transform.localScale = new Vector3(2, 2, 2);
//        actualingredient.initialPos = rectTransform.anchoredPosition;
//        actualingredient.origin = gameObject;

//        ChargeHover();

//        canvasGroup.blocksRaycasts = false;
//    }

//    public void ChargeHover()
//    {
        

//        foreach (Ingredient.SimbolColored child in actualingredient.simbolList)
//        {
//            GameObject simbol = Instantiate(simbolPopUpPrefab, hover.transform.GetChild(0).transform);
//            simbol.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//            int aux = (int)child.color;
//            simbol.transform.GetChild(0).GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//        }

//        simbolhover.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

//        hover.SetActive(true);
//    }

//    public void EliminateHover()
//    {

//        foreach (Transform child in hover.transform.GetChild(0).transform)
//        {
//            Destroy(child.gameObject);
//        }
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

//    public void UpSelected()
//    {
//        if(actualingredient != null)
//        {
//            simbolhover.transform.GetChild(selected).transform.GetChild(1).gameObject.SetActive(false);
//            if (selected == 0) selected = actualingredient.simbolList.Count;
//            else selected--;
//            simbolhover.transform.GetChild(selected).transform.GetChild(1).gameObject.SetActive(true);
//            cortar.ProcessForm();
//        }
        
//    }

//    public void DownSelected()
//    {
//        if (actualingredient != null)
//        {
//            simbolhover.transform.GetChild(selected).transform.GetChild(1).gameObject.SetActive(false);
//            if (selected == actualingredient.simbolList.Count-1) selected = 0;
//            else selected++;
//            simbolhover.transform.GetChild(selected).transform.GetChild(1).gameObject.SetActive(true);
//            cortar.ProcessForm();
//        }
//    }

//}
