//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class GameManager : MonoBehaviour
//{
//    public static GameManager Instance { get; private set; }
//    public Concentrator concentrator;
//    public Cauldron cauldron;
//    private void Awake()
//    {
//        if (Instance != null && Instance != this)
//        {
//            Destroy(this);
//        }
//        else
//        {
//            Instance = this;
//        }

//    }


//    public Slot colorSlot;
//    public CortarInput slicer;

//    [Flags]
//    public enum Colors
//    {
//        White = 0,
//        Magenta = 1,
//        Yellow = 2,
//        Cyan = 4,
//        Red = Magenta | Yellow,
//        Blue = Magenta | Cyan,
//        Green = Yellow | Cyan,
//        Black =  Yellow | Cyan | Magenta,
//        Aux
//    }

//    public enum Simbols
//    {
//        Earth, Air, Water, Fire
//    }

//    [Serializable]
//    public class SimbolImages
//    {
//        public GameManager.Simbols simbols;
//        public Sprite sprite;
//    }

//    public SimbolImages[] simbolImages;

//    [Serializable]
//    public class LineActivate
//    {
//        public String line;
//        public bool activate;
//    }

//    [Serializable]
//    public class SimbolForm
//    {
//        public GameManager.Simbols simbols;
//        public List<LineActivate> form;
//    }

//    public SimbolForm[] simbolforms;

//    [Serializable]
//    public class ColorPicks
//    {
//        public GameManager.Colors colors;
//        public Color rgb;
//    }

//    public ColorPicks[] colorPicks;

//    public Ingredient[] allIngredients;
//    public Inventory inventory;
//    public Emptyslot emptyPot;

//    public GameObject actualMissionHover;
//    public GameObject simbolPopUpPrefab;
//    public List<Ingredient.SimbolColored> actualMission;

//    public List<List<Ingredient.SimbolColored>> todayMissions;
//    public List<bool> hecho;
//    public int totalentregadas = 0;
//    public int selectedmission = 0;

//    public int day = 0;


//    public int state = 0; //1 Inicio del dia, 2 Jugando normal, 3 Terminar el dia, 0 Evento especial al inicio del dia

//    public TextController text;

//    public void ExitGame()
//    {
//        Application.Quit();
//    }

//    public void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.C)) totalentregadas = 2;
//        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
//        switch (state)
//        {
//            case 0:
//                text.StartDay();
//                break;
//            case 1:
//                totalentregadas = 0;
//                selectedmission = 0;
//                state = 2;
//                CreateTodayMissions();
//                ChargeActualMission();
//                break;
//            case 2:
//                if(totalentregadas == 2)
//                {
//                    state = 3;
//                }
//                if (Input.GetKeyDown(KeyCode.I)) inventory.OpenInventory();
//                break;
//            case 3:
//                if (!text.wait)
//                {
//                    NewDay();
//                    text.FinalizaDay();
//                }
//                break;
//        }
//    }
    

//    public void NewDay()
//    {
//        day++;
//        text.carteroday--;
//        emptyPot.Clear();
//        colorSlot.Clear();
//        slicer.Clear();
//        cauldron.Clear();
//        foreach (Transform child in actualMissionHover.transform.GetChild(0))
//        {
//            Destroy(child.gameObject);
//        }
//    }

//    public void LeftSelected()
//    {
//        if (selectedmission == 0) selectedmission = todayMissions.Count - 1;
//        else selectedmission--;
//        actualMission = todayMissions[selectedmission];
//        ChargeActualMission();
//    }

//    public void RightSelected()
//    {
//        if (selectedmission == todayMissions.Count - 1) selectedmission = 0;
//        else selectedmission++;
//        actualMission = todayMissions[selectedmission];
//        ChargeActualMission();
//    }

//    public void ChargeActualMission()
//    {
//        foreach(Transform child in actualMissionHover.transform.GetChild(0))
//        {
//            Destroy(child.gameObject);
//        }

//        foreach (Ingredient.SimbolColored child in actualMission)
//        {
//            GameObject simbol = Instantiate(simbolPopUpPrefab, actualMissionHover.transform.GetChild(0).transform);
//            simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//            int aux = (int)child.color;
//            simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//        }

//        CheckHecho();

//    }

//    public void CreateTodayMissions()
//    {
//        int mindificulty = 3;
//        int maxdificulty = 4;

//        if (day <= 3)
//        {
//            mindificulty = 3;
//            maxdificulty = 5;
//        }
//        else if (day <= 6)
//        {
//            mindificulty = 3;
//            maxdificulty = 6;
//        }
//        else if (day <= 9)
//        {
//            mindificulty = 4;
//            maxdificulty = 7;
//        }
//        else if (day <= 15)
//        {
//            mindificulty = 5;
//            maxdificulty = 8;
//        }


//        todayMissions = new List<List<Ingredient.SimbolColored>>();
//        hecho = new List<bool>();

//        System.Random random = new System.Random();
//        for (int i = 0; i < 3; i++)
//        {
//            hecho.Add(false);
//            int lvl = UnityEngine.Random.Range(mindificulty, maxdificulty);
//            List<Ingredient.SimbolColored> auxlist = new List<Ingredient.SimbolColored>();

//            for (int j = 0; j < lvl; j++)
//            {
//                Simbols randomSimbol = simbolImages[UnityEngine.Random.Range(0, simbolImages.Length)].simbols;
                    
//                Colors randomColor = colorPicks[UnityEngine.Random.Range(0, colorPicks.Length)].colors;

//                Ingredient.SimbolColored simbolcolored = new Ingredient.SimbolColored(randomColor, randomSimbol);
//                auxlist.Add(simbolcolored);
//            }
//            todayMissions.Add(auxlist);
//        }
//        actualMission = todayMissions[selectedmission];
//    }

//    public void CheckHecho()
//    {
//        if (hecho[selectedmission]) actualMissionHover.GetComponent<Image>().color = Color.gray;
//        else actualMissionHover.GetComponent<Image>().color = Color.white;
//    }


//    public bool CheckList(List<Ingredient.SimbolColored> listToCheck)
//    {
//        for(int i = 0; i < todayMissions.Count; i++)
//        {
//            bool resmision = false;
//            if (todayMissions[i].Count == listToCheck.Count && !hecho[i])
//            {
//                List<bool> visitados = new List<bool>();
//                for (int j = 0; j < todayMissions[i].Count; j++)
//                {
//                    visitados.Add(false);
//                }

//                for (int j = 0; j < listToCheck.Count; j++)
//                {
//                    resmision = false;
//                    for (int x = 0; x < todayMissions[i].Count; x++)
//                    {
//                        if (!visitados[x] && listToCheck[j].color == todayMissions[i][x].color && listToCheck[j].simbols == todayMissions[i][x].simbols) {
//                            resmision = true;
//                            visitados[x] = true;
//                            break;
//                        }
//                    }
//                    if (!resmision)
//                    {
//                        break;
//                    }
//                }
//                if (resmision)
//                {
//                    totalentregadas++;
//                    hecho[i] = true;
//                    CheckHecho();
//                    return true;
//                }
//            }
//        }
//        return false;

//    }

//}
