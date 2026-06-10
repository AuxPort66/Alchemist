//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class ColorPots : DragDrop
//{
//    public GameManager.Colors color;

//    public override void OnBeginDrag(PointerEventData eventData)
//    {
//        Debug.Log("DRAG");
//        canvasGroup.blocksRaycasts = false;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = true;

//    }

//    public override void OnEndDrag(PointerEventData eventData)
//    {
//        rectTransform.anchoredPosition = initialPos;
//        canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = false;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = false;
//        GameManager.Instance.slicer.canvasGroup.blocksRaycasts = false;
//    }
//}
