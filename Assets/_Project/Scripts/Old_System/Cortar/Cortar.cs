//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Cortar : MonoBehaviour
//{
//    public Point actualdrag = null;

//    [SerializeField]
//    public List<String> linesdata;
//    public Dictionary<String,bool> activated;

//    public CortarInput cortarinput;

//    public void Awake()
//    {
//        cortarinput = transform.parent.GetChild(1).GetComponent<CortarInput>();
//        activated = new Dictionary<string, bool>();
//        foreach(var child in linesdata)
//        {
//            activated.Add(child, false);
//        }
//    }

//    public bool ComprobateLine(Point finalpoint)
//    {
//        if (finalpoint.name == actualdrag.name) return false;

//        if (finalpoint.name == "4" || actualdrag.name == "4")
//        {
//            if (finalpoint.name == "2" || finalpoint.name == "6" || actualdrag.name == "2" || actualdrag.name == "6") return true;
//        }
//        else if (finalpoint.name == "1" || actualdrag.name == "1")
//        {
//            if (finalpoint.name == "5" || finalpoint.name == "3" || actualdrag.name == "5" || actualdrag.name == "3") return true;
//        }
//        else if ((finalpoint.name == "6" || actualdrag.name == "6") && (finalpoint.name == "2" || actualdrag.name == "2")) return true;
//        else if ((finalpoint.name == "5" || actualdrag.name == "5") && (finalpoint.name == "3" || actualdrag.name == "3")) return true;

//        return false;
//    }

//    public void ActivateLine(Point finalpoint)
//    {
//        if (cortarinput.actualingredient != null && ComprobateLine(finalpoint))
//        {
//            int a = Int32.Parse(finalpoint.name);
//            int b = Int32.Parse(actualdrag.name);

//            string nameline;

//            if (a < b) nameline = a.ToString() + b.ToString();
//            else nameline = b.ToString() + a.ToString();

//            activated[nameline] = !activated[nameline];

//            foreach(Transform child in transform.GetChild(1).transform)
//            {
//                if(child.gameObject.name == nameline)
//                {
//                    bool aux = child.gameObject.activeSelf;
//                    child.gameObject.SetActive(!aux);
//                    break;
//                }
//            }

//            ProcessForm();

//        }

//    }

//    public bool MatchForm()
//    {
//        GameManager.Simbols selectedsimbol = cortarinput.actualingredient.simbolList[cortarinput.selected].simbols;
//        List<GameManager.LineActivate> auxlistlines = GameManager.Instance.simbolforms[(int)selectedsimbol].form;

//        foreach(GameManager.LineActivate line in auxlistlines)
//        {
//            if (activated[line.line] != line.activate) return false;
//        }
//        return true;
//    }

//    public void ProcessForm()
//    {
//        if (MatchForm())
//        {
//            if(cortarinput.actualingredient.simbolList.Count > 1)
//            {

//                if (cortarinput.actualingredient.simbolList.Count > 2)
//                {
//                    if(cortarinput.selected < cortarinput.actualingredient.simbolList.Count-1) cortarinput.simbolhover.transform.GetChild(cortarinput.selected + 1).transform.GetChild(1).gameObject.SetActive(true);
//                    else cortarinput.simbolhover.transform.GetChild(cortarinput.selected - 1).transform.GetChild(1).gameObject.SetActive(true);
//                }

//                cortarinput.actualingredient.simbolList.RemoveAt(cortarinput.selected);
//                Destroy(cortarinput.simbolhover.transform.GetChild(cortarinput.selected).gameObject);
//                if(cortarinput.selected >= cortarinput.actualingredient.simbolList.Count)cortarinput.selected--;
//            }


//            foreach (Transform child in transform.GetChild(1).transform)
//            {
//                child.gameObject.SetActive(false);
//            }

//            activated = new Dictionary<string, bool>();
//            foreach (var child in linesdata)
//            {
//                activated.Add(child, false);
//            }
//        }
//    }
//}
