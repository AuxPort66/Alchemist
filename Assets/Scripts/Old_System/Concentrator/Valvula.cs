//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class Valvula : MonoBehaviour, IPointerDownHandler
//{

//    public Sprite open;
//    public Sprite close;
//    private bool isopen;
//    private Image image;

//    public Concentrator concentrator;

//    public void Awake()
//    {
//        image = GetComponent<Image>();
//        isopen = false;
//        concentrator = GetComponentInParent<Concentrator>();
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if(!isopen && concentrator.use && !concentrator.glass.full)
//        {
//            image.sprite = open;
//            isopen = true;
//            concentrator.Empty();
//        }
//    }

//    public void CloseValvula()
//    {
//        image.sprite = close;
//        isopen = false;
//    }

//}
