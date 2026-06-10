//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Concentrator : MonoBehaviour 
//{

//    public bool use;
//    public GameManager.Colors color;
//    private Animator animator;

//    public Glass glass;

//    public void Awake()
//    {
//        use = false;
//        color = GameManager.Colors.White;
//        animator = GetComponent<Animator>();
//    }


//    public void ClearConcentrator()
//    {
//        transform.GetChild(1).GetComponent<Valvula>().CloseValvula();
//        use = false;
//    }

//    public void ConcentrateIngredient(List <Ingredient.SimbolColored> simbolList)
//    {
//        color = GameManager.Colors.White;
//        use = true;

//        for(int i = 0; i < simbolList.Count; i++)
//        {
//            color |= simbolList[i].color;
//        }

//        animator.SetInteger("Color", (int)color);
//        animator.SetTrigger("Activate");
//    }

//    public void Empty()
//    {
//        glass.animator.SetInteger("Color", (int)color);
//        glass.animator.SetTrigger("Activate");
//        glass.full = true;
//        glass.color = color;
//        color = GameManager.Colors.White;
//        animator.SetTrigger("Valvula");
//    }
//}
