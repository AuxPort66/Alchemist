//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ingredient", order = 1)]
//public class Ingredient : ScriptableObject, IComparable<Ingredient>
//{
//    [Serializable]
//    public class SimbolColored
//    {
//        public GameManager.Colors color;
//        public GameManager.Simbols simbols;

//        public SimbolColored(GameManager.Colors color, GameManager.Simbols simbols)
//        {
//            this.color = color;
//            this.simbols = simbols;
//        }
//    }

//    public String name;
//    public Sprite image;
//    public List<SimbolColored> simbolList;

//    public int CompareTo(Ingredient obj)
//    {
//        return this.name.CompareTo(obj.name);
//    }
//}
