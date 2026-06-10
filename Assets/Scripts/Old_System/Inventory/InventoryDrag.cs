//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using TMPro;
//using System;

//public class InventoryDrag : DragDrop, IPointerEnterHandler, IPointerExitHandler
//{
//    [SerializeField]
//    private GameObject ingredientPrefab;
//    public Ingredient ingredient;

//    public GameObject hoverPopUpPrefab;
//    public GameObject simbolPopUpPrefab;

//    private GameObject hoveractual;

//    private int timertoHover = -1;


//    public override void OnPointerDown(PointerEventData eventData)
//    {
        
//    }

//    public override void OnBeginDrag(PointerEventData eventData)
//    {
//        if (hoveractual != null) Destroy(hoveractual);

//        Ingredient ingredient = eventData.pointerDrag.GetComponent<InventoryDrag>().ingredient;
//        ExecuteEvents.Execute<IEndDragHandler>(gameObject, eventData, ExecuteEvents.endDragHandler);
//        GameObject ingredientdrag = Instantiate(ingredientPrefab, canvas.transform);
//        ingredientdrag.GetComponent<IngredientDrag>().ingredient = ingredient;

//        ingredientdrag.GetComponent<IngredientDrag>().simbolList = new List<Ingredient.SimbolColored>();
//        foreach(var child in ingredient.simbolList)
//        {
//            ingredientdrag.GetComponent<IngredientDrag>().simbolList.Add(new Ingredient.SimbolColored(child.color,child.simbols));
//        }

//        (ingredientdrag.transform as RectTransform).position = eventData.pointerDrag.transform.position;
//        ingredientdrag.GetComponent<Image>().sprite = ingredient.image;
//        ingredientdrag.GetComponent<IngredientDrag>().fromInventory = true;
//        ingredientdrag.GetComponent<IngredientDrag>().fromInventoryAux = true;
//        eventData.pointerDrag = ingredientdrag;
//        eventData.pointerPress = ingredientdrag;
//        eventData.pointerEnter = ingredientdrag;
//        GameManager.Instance.inventory.OpenInventory();
//        ExecuteEvents.Execute<IBeginDragHandler>(ingredientdrag, eventData, ExecuteEvents.beginDragHandler);
//    }

//    public void Update()
//    {
//        if (timertoHover > 0) timertoHover--;
//        else if (timertoHover == 0)
//        {
//            hoveractual = Instantiate(hoverPopUpPrefab, canvas.transform);
//            hoveractual.transform.position = gameObject.transform.position;
//            hoveractual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ingredient.name;

//            foreach(Ingredient.SimbolColored child in ingredient.simbolList)
//            {
//                GameObject simbol = Instantiate(simbolPopUpPrefab, hoveractual.transform.GetChild(1).transform);
//                simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                int aux = (int)child.color;
//                simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//            }

//            timertoHover = -1;
//        }
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        Debug.Log("Entramos");
//        timertoHover = 8;
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        Debug.Log("Salimos");
//        timertoHover = -1;
//        if(hoveractual != null) Destroy(hoveractual);
//    }
//}
