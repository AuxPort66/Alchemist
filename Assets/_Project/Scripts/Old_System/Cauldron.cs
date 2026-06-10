//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using TMPro;
//using UnityEngine.UI;
//using System;

//public class Cauldron : MonoBehaviour, IDropHandler , IPointerEnterHandler, IPointerExitHandler
//{
//    private GameObject hover;
//    public GameObject simbolPopUpPrefab;
//    public List<Ingredient.SimbolColored> simbolList = new List<Ingredient.SimbolColored>();
//    public GameManager.Colors color = GameManager.Colors.White;
//    public GameObject hoverfinish;
//    public bool finishing = false;
//    public bool checking = false;
//    public bool check = false;
//    public int checktimer = 0;
//    public Color checkcolor;

//    public Animator animator;

//    public void Awake()
//    {
//        hover = transform.GetChild(0).gameObject;
//        hoverfinish = transform.GetChild(2).gameObject;
//        animator = GetComponent<Animator>();
//    }
    

//    public void FinishPotion()
//    {
//        hoverfinish.SetActive(true);
//        finishing = true;
//        for(int i = 0; i < simbolList.Count; i++)
//        {
//            simbolList[i].color |= color;
//        }

//        hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
//        foreach (Transform child in hover.transform.GetChild(1).transform)
//        {
//            Destroy(child.gameObject);
//        }

//        animator.SetTrigger("Finish");
//    }

//    public void PotionFinished()
//    {
//        checking = true;
//        check = GameManager.Instance.CheckList(simbolList);
//        if (!check)
//        {
//            checkcolor = new Color(166, 0, 0, 255);
//            checktimer = 250;
//        }
//        else
//        {
//            checktimer = 450;
//            checkcolor = new Color(0, 217, 35, 255);
//        }
        
//    }

//    public void CleanCauldron()
//    {
//        finishing = false;
//        checking = false;
//        color = GameManager.Colors.White;
//        simbolList = new List<Ingredient.SimbolColored>();
//        hoverfinish.GetComponent<Image>().color = Color.white;
//        hoverfinish.SetActive(false);
//        foreach (Transform child in hoverfinish.transform.GetChild(0).transform)
//        {
//            Destroy(child.gameObject);
//        }
//    }

//    public void Update()
//    {
//        if (checking)
//        {
//            if (!check)
//            {
//                if (checktimer == 250 || checktimer == 150 || checktimer == 50) hoverfinish.GetComponent<Image>().color = checkcolor;
//                else if (checktimer == 200 || checktimer == 100) hoverfinish.GetComponent<Image>().color = Color.white;
//                if (checktimer > 0) checktimer--;
//                else
//                {
//                    CleanCauldron();
//                }
//            }
//            else
//            {
//                if (checktimer == 450 || checktimer == 350 || checktimer == 250) hoverfinish.GetComponent<Image>().color = checkcolor;
//                else if (checktimer == 400 || checktimer == 300) hoverfinish.GetComponent<Image>().color = Color.white;
//                if (checktimer > 0) checktimer--;
//                else
//                {
//                    CleanCauldron();
//                }
//            }
            
            
//        }
//    }

//    public void Clear()
//    {
//        hoverfinish.SetActive(false);
//    }

//    public void OnDrop(PointerEventData eventData)
//    {
//       if(eventData.pointerDrag != null)
//        {
//            if(eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//            {
//                IngredientDrag ingredient = eventData.pointerDrag.GetComponent<IngredientDrag>();
//                if (ingredient.fromInventory) GameManager.Instance.inventory.RestIngredient(ingredient.ingredient);

//                foreach(var child in ingredient.simbolList)
//                {
//                    simbolList.Add(new Ingredient.SimbolColored(child.color,child.simbols));
//                    GameObject simbol = Instantiate(simbolPopUpPrefab, hover.transform.GetChild(1).transform);
//                    simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                    int aux = (int)child.color;
//                    simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;

//                    GameObject simbol2 = Instantiate(simbolPopUpPrefab, hoverfinish.transform.GetChild(0).transform);
//                    simbol2.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                    GameManager.Colors colaux = child.color;
//                    colaux |= color;
//                    aux = (int)colaux;
//                    simbol2.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//                }

//            }
//            else if(eventData.pointerDrag.GetComponent<Cocktail>() != null)
//            {
//                if (!eventData.pointerDrag.GetComponent<Cocktail>().shaking)
//                {
//                    foreach (var child in eventData.pointerDrag.GetComponent<Cocktail>().ingredientlist)
//                    {
//                        simbolList.Add(new Ingredient.SimbolColored(child.color, child.simbols));
//                        GameObject simbol = Instantiate(simbolPopUpPrefab, hover.transform.GetChild(1).transform);
//                        simbol.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                        int aux = (int)child.color;
//                        simbol.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;

//                        GameObject simbol2 = Instantiate(simbolPopUpPrefab, hoverfinish.transform.GetChild(0).transform);
//                        simbol2.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                        GameManager.Colors colaux = child.color;
//                        colaux |= color;
//                        aux = (int)colaux;
//                        simbol2.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//                    }
//                    eventData.pointerDrag.GetComponent<Cocktail>().ClearCocktail();
//                }
//                else
//                {
//                    eventData.pointerDrag.GetComponent<Cocktail>().RecoverPosition();
//                }
//            }
//            else if(eventData.pointerDrag.GetComponent<Glass>() != null)
//            {
//                GameManager.Colors auxcolor = eventData.pointerDrag.GetComponent<Glass>().color;
//                if (auxcolor != GameManager.Colors.White) color |= auxcolor;
//                else color = auxcolor;
//                hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = GameManager.Instance.colorPicks[(int)color].rgb;
//                if (auxcolor != GameManager.Colors.White)
//                {
//                    hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = color.ToString();
//                }
//                else
//                {
//                    hover.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
//                }

//                for(int i = 0; i < simbolList.Count;i++)
//                {
//                    Ingredient.SimbolColored child = simbolList[i];
//                    GameObject simbol2 = hoverfinish.transform.GetChild(0).transform.GetChild(i).gameObject;
//                    simbol2.GetComponent<Image>().sprite = GameManager.Instance.simbolImages[(int)child.simbols].sprite;
//                    GameManager.Colors colaux = child.color;
//                    colaux |= color;
//                    int aux = (int)colaux;
//                    simbol2.GetComponent<Image>().color = GameManager.Instance.colorPicks[aux].rgb;
//                }

//                Glass glass = eventData.pointerDrag.GetComponent<Glass>();
//                glass.animator.Play("Glassempty");
//                glass.full = false;
//                glass.trashed = false;
//                glass.color = GameManager.Colors.White;
//            }
//        }
//    }


//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//        {
//            eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = true;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<IngredientDrag>() != null)
//        {
//            eventData.pointerDrag.GetComponent<IngredientDrag>().trashed = false;
//        }
//    }

//}
