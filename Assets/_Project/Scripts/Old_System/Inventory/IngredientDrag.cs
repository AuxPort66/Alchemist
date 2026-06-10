//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class IngredientDrag : DragDrop, IPointerEnterHandler,IPointerExitHandler
//{
//    [SerializeField]
//    public Ingredient ingredient;

//    public List<Ingredient.SimbolColored> simbolList;

//    public bool recover = false;

//    public bool fromInventory;
//    public bool fromInventoryAux;

//    public GameObject origin;

//    public GameObject hoverPopUpPrefab;
//    public GameObject simbolPopUpPrefab;

//    private GameObject hoveractual;
//    private bool nothover = false;

//    private int timertoHover = -1;
//    public bool trashed = false;



//    public override void OnDrop(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ColorPots>() != null)
//        {
//            GameManager.Instance.colorSlot.PutColor(eventData.pointerDrag.GetComponent<ColorPots>().color);
//        }
//    }

//    public override void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = false;
//        canvasGroup.alpha = 1.0f;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.slicer.canvasGroup.blocksRaycasts = true;
//        if (GameManager.Instance.colorSlot.actualingredient == this) GameManager.Instance.colorSlot.actualingredient = null;
//        if (GameManager.Instance.emptyPot.actualingredient == this) GameManager.Instance.emptyPot.actualingredient = null;
//        if (GameManager.Instance.slicer.actualingredient == this)
//        {
//            GameManager.Instance.slicer.actualingredient = null;
//            GameManager.Instance.slicer.hover.SetActive(false);
//            GameManager.Instance.slicer.EliminateHover();
//        }
//        gameObject.transform.localScale = new Vector3(3, 3, 3);
//    }

//    public void DiluteColor(GameManager.Colors colortochange)
//    {
//        for(int i = 0; i < simbolList.Count; i++)
//        {
//            if (simbolList[i].color == colortochange) simbolList[i].color = GameManager.Colors.White;
//        }
//    }

//    public void RecoverPosition()
//    {
//        if((fromInventory && fromInventoryAux) || trashed) Destroy(gameObject);
//        else
//        {
//            recover = true;
//        }
//    }



//    public override void OnPointerUp(PointerEventData eventData)
//    {
//        Debug.Log("Soltamos");
//        rectTransform.SetSiblingIndex(indexSibling);
//        RecoverPosition();
//        nothover = true;
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        Debug.Log("Entramos");
//        if(eventData.pointerDrag == null && eventData.pointerPress == null && !nothover && origin.name != "CortarInput")timertoHover = 8;
//    }

//    public override void OnPointerDown(PointerEventData eventData)
//    {
//        if(origin != null && origin.name == "CortarInput")
//        {
//            gameObject.transform.SetParent(canvas.transform);
//        }
//        rectTransform.SetAsLastSibling();
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        Debug.Log("Salimos");
//        timertoHover = -1;
//        nothover = false;
//        if (hoveractual != null) Destroy(hoveractual);
//    }
//    public void Update()
//    {
//        if (recover)
//        {
//            if (origin != null && origin.name == "ColorPot" && GameManager.Instance.colorSlot.actualingredient == null)
//            {
//                origin.GetComponent<Slot>().PutintotheJar(gameObject);
//            }
//            else if (origin != null && origin.name == "CortarInput" && GameManager.Instance.slicer.actualingredient == null)
//            {
//                origin.GetComponent<CortarInput>().Putintotheslicer(gameObject);
//            }
//            if (origin != null && origin.name == "EmptyPot" && GameManager.Instance.emptyPot.actualingredient == null)
//            {
//                origin.GetComponent<Emptyslot>().PutintotheJar(gameObject);
//            }
//            recover = false;
//        }

//        if (timertoHover > 0) timertoHover--;
//        else if (timertoHover == 0)
//        {
//            hoveractual = Instantiate(hoverPopUpPrefab, canvas.transform);
//            hoveractual.transform.position = gameObject.transform.position;
//            hoveractual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ingredient.name;

//            foreach (Ingredient.SimbolColored child in simbolList)
//            {
//                GameObject simbol = Instantiate(simbolPopUpPrefab, hoveractual.transform.GetChild(1).transform);
//                simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                int aux = (int)child.color;
//                simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//            }

//            timertoHover = -1;
//        }
//    }
//}
