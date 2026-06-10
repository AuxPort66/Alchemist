//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class DragDrop : MonoBehaviour, IPointerDownHandler,IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
//{

//    [SerializeField] protected Canvas canvas;
//    protected RectTransform rectTransform;
//    protected CanvasGroup canvasGroup;
//    public Vector3 initialPos;
//    public int indexSibling;

//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        initialPos = rectTransform.anchoredPosition;
//        indexSibling = rectTransform.GetSiblingIndex();
//        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
//    }

//    public virtual void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = false;
//    }

//    public virtual void OnDrag(PointerEventData eventData)
//    {
//        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
//    }

//    public virtual void OnEndDrag(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = false;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = false;
//        GameManager.Instance.slicer.canvasGroup.blocksRaycasts = false;
//    }

//    public virtual void OnPointerDown(PointerEventData eventData)
//    {
//        rectTransform.SetAsLastSibling();
//    }

//    public virtual void OnPointerUp(PointerEventData eventData)
//    {
//        rectTransform.SetSiblingIndex(indexSibling);
//    }

//    public virtual void OnDrop(PointerEventData eventData)
//    {

//    }

    
//}
