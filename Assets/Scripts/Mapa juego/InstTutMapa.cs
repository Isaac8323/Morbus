using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InstTutMapa : MonoBehaviour
{
    public Dialogs dialog;
    public GameObject load, tut, focus, plus, less, next, dt, pan, back, proceed, help;
    public GameObject[] celdas = new GameObject[3];
    public Image clara, panel;
    public Animator pointer, animclara, key;
    public TextMeshProUGUI displayText;
    public Archivos arcTut;
    private int cont;
    private bool stop = false, stoptwo = false, stopthree = false;

    void Start()
    {
        arcTut.cargar_variables();
        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                FindObjectOfType<Dialog_manager>().StartDialogue(dialog);
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
            }
        }
    }

    private void HideClara(string anim)
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
        clara.enabled = false;
        focus.SetActive(true);
        pointer.SetBool(anim, true);
    }

    public void Omitir()
    {
        if (variables_indestructibles.TempTut.Equals("true"))
        {
            variables_indestructibles.Tutorial = "7";
            arcTut.guardar_variables();
        }
        else
        {
            variables_indestructibles.Tutorial = (Int32.Parse(variables_indestructibles.Tutorial) + 1).ToString();
            arcTut.guardar_variables();
        }
    }

    void Update()
    {

        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                cont = FindObjectOfType<Dialog_manager>().cont;
                switch (variables_indestructibles.Tutorial)
                {
                    case "0":
                        if (cont == 13 || cont == 47)
                        {
                            key.SetBool("Texting", true);
                            animclara.SetBool("Verguenza", true);
                        }
                        else if (cont == 45 || cont == 48)
                        {
                            key.SetBool("Texting", true);
                            animclara.SetBool("Happy", true);
                        }
                        else
                        {
                            key.SetBool("Texting", true);
                            animclara.SetBool("Silencio", false);
                        }
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            if (cont == 13 || cont == 47)
                            {
                                animclara.SetBool("SilVerguenza", true);
                                key.SetBool("Texting", false);
                            }
                            else if (cont == 45 || cont == 48)
                            {
                                key.SetBool("Texting", false);
                                animclara.SetBool("SilHappy", true);
                            }
                            else
                            {
                                animclara.SetBool("Silencio", true);
                                key.SetBool("Texting", false);
                            }
                        }
                        if (cont == 13 || cont == 18 || cont == 28 || cont == 33 || cont == 42)
                        {
                            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                            panel.enabled = true;
                            clara.enabled = true;
                            focus.SetActive(false);
                        }
                        if (cont == 14 || cont == 48)
                        {
                            animclara.SetBool("SilVerguenza", false);
                            animclara.SetBool("Verguenza", false);
                        }
                        if (cont == 46 || cont == 49)
                        {
                            animclara.SetBool("Happy", false);
                            animclara.SetBool("SilHappy", false);
                        }
                        switch (cont)
                        {
                            case 11:
                                HideClara("Tutorial");
                                break;
                            case 15:
                                HideClara("Tienda");
                                break;
                            case 26:
                                HideClara("Laboratorio");
                                break;
                            case 30:
                                HideClara("Almacen");
                                break;
                            case 40:
                                HideClara("Arena");
                                break;
                            case 50:
                                if (variables_indestructibles.TempTut.Equals("true"))
                                {
                                    variables_indestructibles.Tutorial = "7";
                                    arcTut.guardar_variables();
                                }
                                else
                                {
                                    variables_indestructibles.Tutorial = "1";
                                    arcTut.guardar_variables();
                                    LoadScene.sceneToLoad = "Laboratorio";
                                    load.SetActive(true);
                                }
                                break;
                        }
                        break;
                    case "1":
                        key.SetBool("Texting", true);
                        animclara.SetBool("Silencio", false);
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            animclara.SetBool("Silencio", true);
                            key.SetBool("Texting", false);
                        }
                        if (cont == 3 || cont == 10)
                        {
                            clara.enabled = true;
                            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                            focus.SetActive(false);
                        }
                        switch (cont)
                        {
                            case 2:
                                HideClara("Elements");
                                break;
                            case 5:
                                panel.enabled = false;
                                clara.enabled = false;
                                ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                break;
                            case 7:
                                HideClara("Buttons");
                                break;
                            case 11:
                                panel.enabled = false;
                                clara.enabled = false;
                                if (stop == false)
                                {
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    for (int x = 0; x < 10; x++)
                                    {
                                        ExecuteEvents.Execute<IPointerClickHandler>(plus, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    }
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    for (int x = 0; x < 9; x++)
                                    {
                                        ExecuteEvents.Execute<IPointerClickHandler>(plus, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    }
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    for (int x = 0; x < 5; x++)
                                    {
                                        ExecuteEvents.Execute<IPointerClickHandler>(plus, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    }
                                    stop = true;
                                }
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                clara.enabled = true;
                                break;
                            case 13:
                                if (stoptwo == false)
                                {
                                    back.SetActive(false);
                                    dt.SetActive(false);
                                    pan.SetActive(false);
                                    ExecuteEvents.Execute<IPointerClickHandler>(next, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    back.SetActive(true);
                                    dt.SetActive(true);
                                    pan.SetActive(true);
                                    stop = true;
                                }
                                break;
                            case 16:
                                //Banderas de terminar con el tuto
                                if (stopthree == false)
                                {
                                    if (variables_indestructibles.TempTut.Equals("true"))
                                    {
                                        variables_indestructibles.TempTut = "false";
                                        variables_indestructibles.Tutorial = "7";
                                        arcTut.guardar_variables();
                                    }
                                    variables_indestructibles.Tutorial = "2";
                                    arcTut.guardar_variables();
                                    back.SetActive(false);
                                    dt.SetActive(false);
                                    pan.SetActive(false);
                                    ExecuteEvents.Execute<IPointerClickHandler>(proceed, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    stopthree = true;
                                }
                                break;
                        }
                        break;
                    case "2":
                        key.SetBool("Texting", true);
                        animclara.SetBool("Silencio", false);
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            animclara.SetBool("Silencio", true);
                            key.SetBool("Texting", false);
                        }
                        switch (cont)
                        {
                            case 1:
                                help.SetActive(true);
                                break;
                        }
                        break;
                    case "3":
                        //Tienda
                        break;
                    case "4":
                        //Combates
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                }
            }
        }
    }
}
