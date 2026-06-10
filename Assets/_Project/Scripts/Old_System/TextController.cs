//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System;
//using UnityEngine.UI;

//public class TextController : MonoBehaviour
//{
//    public TextMeshProUGUI text;


//    public bool sick = false; //No tomaste tu medicina 1 vez durante los 8 primeros dias
//    public bool isgato = false; //Te quedaste con el gato
//    public int rechazoscartero = 0; //Rechazos seguidos que le hiciste al cartero
//    public bool carterorechazado = false;

//    public int carteroday = 0; //Dias hasta que venga el cartero
//    public bool carterohoy = false;

//    public int gato = 0; //Cuantas veces has interactuado positivamente con el gato
//    public int positivecartero = 0; //Cuantas veces has interactuado positivamente con el cartero
//    public int negativecartero = 0; //Cuantas veces has interactuado positivamente con el cartero
//    public int tiempolibre = 0; //Cuantas veces no has trabajado para hacer algo relajante
//    public int medicinatomada = 0;


//    public TextFinals datatext;

//    public string actualtext;

//    public GameObject optionscontent;

//    public bool wait = false;
//    public bool finalizandodia = false;
//    public bool endgame = false;
//    public bool saltarsedia = false;
//    public bool saltarsediapormedicina = false;
//    public bool cerrar = false;

//    private TextMeshProUGUI daytext;
//    public void Awake()
//    {
//        text = transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
//        daytext = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
//    }

//    public void StartDay()
//    {
//        if (!wait)
//        {
//            daytext.text = "Day " + (GameManager.Instance.day + 1).ToString();
//            gameObject.SetActive(true);

//            if (endgame)
//            {
//                wait = true;
//                cerrar = true;
//                gameObject.GetComponent<Image>().color = Color.black;
//                actualtext = datatext.Finales(sick, isgato, gato, positivecartero, tiempolibre, medicinatomada);
//                ChargeText();
//            }
//            else
//            {
//                if (CheckImportantDay(GameManager.Instance.day))
//                {
//                    wait = true;
//                    Importantdays(GameManager.Instance.day);
//                }
//                else
//                {
//                    Charge4Options();
//                }
//            }
            
//        }
//    }

//    public bool CheckImportantDay(int day)
//    {
//        if (day == 0) return true;
//        if (medicinatomada >= 3) return true;
//        if ((day == 8 || day == 9) && medicinatomada < 1) return true;
//        if (day == 15 || day == 16) return true;
//        if (carteroday <= 0 && rechazoscartero < 2)
//        {
//            carterohoy = true;
//            return true;
//        }
//        return false;
//    }

//    public void Importantdays(int day)
//    {
//        endgame = true;
//        saltarsedia = true;

//        if(day == 0) //primerito dia chaval
//        {
//            endgame = false;
//            saltarsedia = false;
//            actualtext = datatext.primerdia;

//        }
//        else if ((day == 8 || day == 9) && medicinatomada < 1)
//        {
//            sick = true;
//            if (gato + positivecartero + tiempolibre >= 3)
//            {
//                actualtext = datatext.sicksocializando;
//            }
//            else actualtext = datatext.sicksolotrabajar;
//        }
//        else if (day == 15 || day == 16)
//        {
//            if (gato + positivecartero + tiempolibre >= 5)
//            {
//                actualtext = datatext.NosickSocializando;
//            }
//            else actualtext = datatext.NosickSoloTrabajar;
//        }
//        else if (medicinatomada >= 3)
//        {
//            actualtext = datatext.demasiadamedicina;

//        }
//        else if(carterohoy)
//        {
//            endgame = false;
//            saltarsedia = false;
//            actualtext = datatext.CarteroInterracionesInicio(positivecartero + negativecartero);
//        }
//        ChargeText();
//    }

//    public void FinalizaDay()
//    {
//        if (!endgame)
//        {
//            gameObject.SetActive(true);
//            wait = true;
//            finalizandodia = true;
//            if (saltarsediapormedicina) actualtext = datatext.finalizardiamedicina;
//            else actualtext = datatext.finalizardia;
//            saltarsediapormedicina = false;
//            ChargeText();
//        }
//    }

//    public void Charge2Options(string a, string b)
//    {
//        wait = true;
//        optionscontent.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = a;
//        optionscontent.transform.GetChild(0).gameObject.SetActive(true);

//        optionscontent.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = b;
//        optionscontent.transform.GetChild(1).gameObject.SetActive(true);

//        optionscontent.transform.GetChild(2).gameObject.SetActive(false);

//        optionscontent.transform.GetChild(3).gameObject.SetActive(false);

//        optionscontent.SetActive(true);
//    }

//    public void Charge4Options() //0 gato 1 medicina 2 ocio 3 trabajar
//    {
//        wait = true;
//        if (isgato)
//        {
//            optionscontent.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Cat";
//            if(gato >= 2) optionscontent.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "Raki";
//            optionscontent.transform.GetChild(0).gameObject.SetActive(true);
//        }
//        else optionscontent.transform.GetChild(0).gameObject.SetActive(false);

//        optionscontent.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "Medicine";
//        optionscontent.transform.GetChild(1).gameObject.SetActive(true);

//        optionscontent.transform.GetChild(2).gameObject.SetActive(true);

//        optionscontent.transform.GetChild(3).gameObject.SetActive(true);

//        optionscontent.SetActive(true);
//    }

//    public void Option4Selected(int i)
//    {
//        optionscontent.SetActive(false);

//        if (carterohoy)
//        {
//            switch (i)
//            {
//                case 0:
//                    if (positivecartero + negativecartero == 1) isgato = true;
//                    carterorechazado = false;
//                    rechazoscartero = 0;
//                    carterohoy = false;
//                    carteroday = 2;
//                    if (positivecartero + negativecartero > 2) carteroday = 4;
//                    saltarsedia = true;
//                    actualtext = datatext.CarteroInterracionesFinalPositive(positivecartero + negativecartero);
//                    positivecartero++;
//                    break;
//                case 1:
//                    carteroday = 2;
//                    actualtext = datatext.CarteroInterracionesFinalNegative(positivecartero + negativecartero);
//                    negativecartero++;
//                    carterorechazado = true;
//                    rechazoscartero++;
//                    break;
//            }
//            ChargeText();
//        }
//        else
//        {
//            switch (i)
//            {
//                case 0: //cat
//                    actualtext = datatext.Gato(gato);
//                    gato++;
//                    saltarsedia = true;
//                    ChargeText();
//                    break;
//                case 1: //medicine
//                    actualtext = datatext.Medicina(medicinatomada);
//                    medicinatomada++;
//                    GameManager.Instance.day++;
//                    carteroday--;
//                    saltarsedia = true;
//                    saltarsediapormedicina = true;
//                    ChargeText();
//                    break;
//                case 2: //Free Time
//                    actualtext = datatext.FreeTime(tiempolibre);
//                    tiempolibre++;
//                    saltarsedia = true;
//                    ChargeText();
//                    break;
//                case 3: //Work
//                    gameObject.SetActive(false);
//                    GameManager.Instance.state = 1;
//                    wait = false;
//                    break;
//            }
//        }
        
//    }


//    public void NextPage()
//    {
//        if(text.pageToDisplay < text.textInfo.pageCount) text.pageToDisplay++;
//        else if(!carterohoy)
//        {
//            transform.GetChild(0).gameObject.SetActive(false);
//            gameObject.SetActive(false);
//            if (finalizandodia || endgame) GameManager.Instance.state = 0;
//            else if(!saltarsedia) GameManager.Instance.state = 1;
//            else GameManager.Instance.state = 3;
//            saltarsedia = false;
//            finalizandodia = false;
//            wait = false;

//            if (cerrar) Application.Quit();
//        }
//        else //Cargar Opciones de cartero
//        {
//            if (!carterorechazado)
//            {
//                transform.GetChild(0).gameObject.SetActive(false);
//                Charge2Options(datatext.CarteroOptionsPositive(positivecartero+negativecartero), datatext.CarteroOptionsNegative(positivecartero + negativecartero));
//            }
//            else
//            {
//                carterohoy = false;
//                transform.GetChild(0).gameObject.SetActive(false);
//                carterorechazado = false;
//                wait = false;
//            }
//        }
//    }


    

    

//    private void ChargeText()
//    {
//        text.text = actualtext;
//        text.pageToDisplay = 1;
//        transform.GetChild(0).gameObject.SetActive(true);
//    }


//}
