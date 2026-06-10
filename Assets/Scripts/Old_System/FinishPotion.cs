//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//public class FinishPotion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
//{
//    public Cauldron cauldron;
//    private int hovertimer;

//    public void Awake()
//    {
//        hovertimer = -1;
//        cauldron = transform.parent.GetComponent<Cauldron>();
//    }

//    public void Update()
//    {
//        if (hovertimer > 0) hovertimer--;
//        else if(hovertimer == 0)
//        {
//            cauldron.hoverfinish.SetActive(true);
//            hovertimer = -1;
//        }
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag == null && cauldron.simbolList.Count > 0) hovertimer = 150;
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (!cauldron.finishing)
//        {
//            cauldron.hoverfinish.SetActive(false);
//            hovertimer = -1;
//        }
//    }

//}
