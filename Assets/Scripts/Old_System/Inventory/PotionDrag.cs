//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class PotionDrag : DragDrop
//{
//    [SerializeField]
//    public Potions potion;
//    public override void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.blocksRaycasts = false;
//        canvasGroup.alpha = 1.0f;
//        GameManager.Instance.colorSlot.canvasGroup.blocksRaycasts = true;
//        GameManager.Instance.emptyPot.canvasGroup.blocksRaycasts = true;
//        if (GameManager.Instance.colorSlot.actualingredient == this) GameManager.Instance.colorSlot.actualingredient = null;
//        if (GameManager.Instance.emptyPot.actualingredient == this) GameManager.Instance.emptyPot.actualingredient = null;

//    }
//}
