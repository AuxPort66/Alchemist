//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class Glass : DragDrop
//{

//    public bool isConnected;
//    public Concentrator concentrator;
//    public Animator animator;
//    public bool trashed;

//    public Sprite empty;

//    public bool full;

//    public GameManager.Colors color;

//    public void Awake()
//    {
//        trashed = false;
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        initialPos = rectTransform.anchoredPosition;
//        indexSibling = rectTransform.GetSiblingIndex();
//        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
//        animator = GetComponent<Animator>();
//        full = false;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
//    }

//    public override void OnDrop(PointerEventData eventData)
//    {
//        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Glass>() != null)
//        {
//            Glass dropedGlass = eventData.pointerDrag.GetComponent<Glass>();
//            Vector3 auxpos = dropedGlass.initialPos;
//            dropedGlass.initialPos = this.initialPos;
//            dropedGlass.gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;
//            initialPos = auxpos;
//            rectTransform.anchoredPosition = auxpos;

//            if (dropedGlass.isConnected)
//            {
//                isConnected = true;
//                concentrator.glass = this;
//                dropedGlass.isConnected = false;
//            }
//            else if (isConnected)
//            {
//                dropedGlass.isConnected = true;
//                concentrator.glass = dropedGlass;
//                isConnected = false;
//            }
//        }
//    }

//    internal void EmptyImage()
//    {
//        GetComponent<Image>().sprite = empty;

//    }

//    public void RestorePosition()
//    {
//        rectTransform.anchoredPosition = initialPos;
//    }

//    public override void OnEndDrag(PointerEventData eventData)
//    {
//        if(!trashed)rectTransform.anchoredPosition = initialPos;
//        canvasGroup.blocksRaycasts = true;
//    }

//}
