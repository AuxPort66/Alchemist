//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using TMPro;
//using System;

//public class Cocktail : DragDrop, IDropHandler, IPointerEnterHandler, IPointerExitHandler
//{
//    public Sprite openimage;
//    public Sprite fullimage;
//    public Sprite closeimage;
//    public Sprite finishimage;

//    public GameManager.Colors color;
//    public List<Ingredient.SimbolColored> ingredientlist;

//    public GameObject simbolPopUpPrefab;

//    private GameObject hover;

//    public int shakes = 0;
//    private Vector3 initposdrag;
//    private bool up = true;

//    public Sprite CocktailIngredient;
//    public GameObject ingredientPrefab;

//    public bool shaking = false;

//    public void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        initialPos = rectTransform.anchoredPosition;
//        indexSibling = rectTransform.GetSiblingIndex();
//        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
//        ingredientlist = null;
//        color = GameManager.Colors.White;
//        hover = transform.GetChild(0).gameObject;
//        hover.SetActive(false);
//    }

//    public override void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = false;
//        initposdrag = rectTransform.anchoredPosition;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.slicer.canvasGroup.blocksRaycasts = true;
//    }

//    public override void OnDrag(PointerEventData eventData)
//    {
//        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
//        if (shakes >= 0 && up && rectTransform.anchoredPosition.y < (initposdrag.y - 10))
//        {
//            ++shakes;
//            up = false;
//        }
//        else if (shakes >= 0 && !up && rectTransform.anchoredPosition.y > (initposdrag.y + 10))
//        {
//            ++shakes;
//            up = true;
//        }
//    }

//    public void FormSimbolList()
//    {
//        foreach(var simbol in ingredientlist)
//        {
//            simbol.color |= color;
//        }
//    }

//    internal void RecoverPosition()
//    {
//        rectTransform.anchoredPosition = initialPos;
//    }

//    public override void OnPointerUp(PointerEventData eventData)
//    {
//        Debug.Log("Soltamos");
//        rectTransform.SetSiblingIndex(indexSibling);

//        if(shakes > 3)
//        {
//            GetComponent<Image>().sprite = finishimage;
//            shakes = -1;
//            up = true;
//            hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
//            hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = GameManager.Instance.colorPicks[(int)GameManager.Colors.White].rgb;
//            FormSimbolList();
//            shaking = false;
//            for (int i = 0; i < ingredientlist.Count;i++)
//            {
//                GameObject child = hover.transform.GetChild(1).transform.GetChild(i).gameObject;
//                child.GetComponent<Image>().color = GameManager.Instance.colorPicks[(int)ingredientlist[i].color].rgb;
//            }

//            hover.SetActive(true);

//        }
//        rectTransform.anchoredPosition = initialPos;
//    }

//    public override void OnDrop(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null) { 
//            if(eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//            {
//                if(ingredientlist == null)
//                {
//                    ingredientlist = new List<Ingredient.SimbolColored>();
//                    foreach(var child in eventData.pointerDrag.GetComponent<IngredientDrag>().simbolList)
//                    {
//                        ingredientlist.Add(new Ingredient.SimbolColored(child.color, child.simbols));
//                    }

//                    if (color == GameManager.Colors.White)
//                    {
//                        GetComponent<Image>().sprite = fullimage;


//                        foreach (Ingredient.SimbolColored child in ingredientlist)
//                        {
//                            GameObject simbol = Instantiate(simbolPopUpPrefab, hover.transform.GetChild(1).transform);
//                            simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                            int aux = (int)child.color;
//                            simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//                        }

//                        hover.SetActive(true);
//                    }
//                    else
//                    {
//                        shakes = 0;
//                        GetComponent<Image>().sprite = closeimage;
//                        hover.SetActive(false);
//                        shaking = true;
//                    }
//                    IngredientDrag ingredientdrag = eventData.pointerDrag.GetComponent<IngredientDrag>();
//                    if (ingredientdrag.fromInventory) GameManager.Instance.inventory.RestIngredient(ingredientdrag.ingredient);
//                }
//            }
//            else if (eventData.pointerDrag.GetComponent<Glass>() != null)
//            {
//                if (eventData.pointerDrag.GetComponent<Glass>().color != GameManager.Colors.White)
//                {
//                    color |= eventData.pointerDrag.GetComponent<Glass>().color;
//                }
//                else color = GameManager.Colors.White;
//                if (ingredientlist == null)
//                {
//                    GetComponent<Image>().sprite = fullimage;
//                    hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = color.ToString();
//                    if(color == GameManager.Colors.White) hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
//                    hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = GameManager.Instance.colorPicks[(int)color].rgb;

//                    hover.SetActive(true);

//                }
//                else
//                {
//                    shakes = 0;
//                    GetComponent<Image>().sprite = closeimage;
//                    hover.SetActive(false);
//                    shaking = true;

//                }

//                Glass glass = eventData.pointerDrag.GetComponent<Glass>();
//                glass.animator.Play("Glassempty");
//                glass.full = false;
//                glass.trashed = false;
//                glass.color = GameManager.Colors.White;
//            eventData.pointerDrag.GetComponent<Glass>().RestorePosition();
//            }
//        }
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null)
//        {
//            if (eventData.pointerDrag.GetComponent<Glass>() != null) eventData.pointerDrag.GetComponent<Glass>().trashed = true;
//            if (ingredientlist == null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null) eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = true;
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

//    public void ClearCocktail()
//    {
        
//        shakes = -1;
//        ingredientlist = null;
//        color = GameManager.Colors.White;
//        GetComponent<Image>().sprite = openimage;
//        hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
//        hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = GameManager.Instance.colorPicks[(int)GameManager.Colors.White].rgb;

//        foreach(Transform child in hover.transform.GetChild(1).transform)
//        {
//            Destroy(child.gameObject);
//        }
//        rectTransform.anchoredPosition = initialPos;

//        hover.SetActive(false);
//    }

//    public GameObject CreateIngredientCustom()
//    {
//        Ingredient ingredient = new Ingredient();
//        ingredient.name = "Artificial";
//        ingredient.image = CocktailIngredient;

//        GameObject ingredientdrag = Instantiate(ingredientPrefab, canvas.transform);
//        ingredientdrag.GetComponent<IngredientDrag>().ingredient = ingredient;

//        ingredientdrag.GetComponent<IngredientDrag>().simbolList = new List<Ingredient.SimbolColored>();
//        foreach (var child in ingredientlist)
//        {
//            ingredientdrag.GetComponent<IngredientDrag>().simbolList.Add(new Ingredient.SimbolColored(child.color, child.simbols));
//        }

//        ingredientdrag.GetComponent<Image>().sprite = CocktailIngredient;
//        ingredientdrag.GetComponent<IngredientDrag>().fromInventory = false;
//        ingredientdrag.GetComponent<IngredientDrag>().fromInventoryAux = false;

//        return ingredientdrag;
//    }

//}
