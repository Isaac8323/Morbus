using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InstTutMapa : MonoBehaviour
{
    // 1.Intro, 2.Creacion de curas, 3.Compras, 4.Selección, 5. Combates 6.Centro de entrenamiento, 7.Santuario, 8.Nivel20
    public Dialogs dialog;
    public GameObject load, tut, focus, plus, less, next, dt, pan, back, proceed, help;
    public GameObject[] celdas = new GameObject[3];
    public Image clara, panel;
    public Animator pointer, animclara, key;
    public TextMeshProUGUI displayText;
    public Archivos arcTut;
    private int cont;
    private bool stop = false, stoptwo = false, stopthree = false, stopfour = false;

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

    public void Sacrifice()
    {
        variables_indestructibles.Tutorial = "8";
        arcTut.guardar_variables();
    }

    public void Train()
    {
        variables_indestructibles.Tutorial = "7";
        arcTut.guardar_variables();
    }

    public void Lab()
    {
        LoadScene.sceneToLoad = "Laboratorio";
        load.SetActive(true);
    }

    public void Fight()
    {
        variables_indestructibles.Tutorial = "5";
        arcTut.guardar_variables();
        LoadScene.sceneToLoad = "TestFight";
        load.SetActive(true);
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
        variables_indestructibles.Tutorial = (Int32.Parse(variables_indestructibles.Tutorial) + 1).ToString();
        arcTut.guardar_variables();
    }

    void Update()
    {
        Debug.Log(variables_indestructibles.Tutorial);
        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                cont = FindObjectOfType<Dialog_manager>().cont;
                switch (variables_indestructibles.Tutorial)
                {
                    case "0"://Tutorial inicial
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
                                variables_indestructibles.Tutorial = "1";
                                arcTut.guardar_variables();
                                LoadScene.sceneToLoad = "Laboratorio";
                                load.SetActive(true);
                                break;
                        }
                        break;
                    case "1"://Selección de elementos
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
                    case "2"://Estructuración
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
                            case 4:
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                pointer.SetBool("Enlace", true);
                                break;
                            case 7:
                                pointer.SetBool("Enlace", false);
                                pointer.SetBool("Elemento", true);
                                break;
                            case 9:
                                pointer.SetBool("Elemento", false);
                                pointer.SetBool("Casilla", true);
                                break;
                            case 11:
                                pointer.SetBool("Casilla", false);
                                pointer.SetBool("Vertice", true);
                                break;
                            case 16:
                                pointer.SetBool("Vertice", false);
                                break;
                            case 24:
                                variables_indestructibles.Tutorial = "3";
                                arcTut.guardar_variables();
                                break;
                        }
                        break;
                    case "3":
                        //Tienda
                        if (cont == 1 || cont == 6 || cont == 14)
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
                            if (cont == 1 || cont == 6 || cont == 14)
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
                        if (cont == 2 || cont == 7 || cont == 15)
                        {
                            animclara.SetBool("Happy", false);
                            animclara.SetBool("SilHappy", false);
                        }
                        switch (cont)
                        {
                            case 7:
                                panel.enabled = false;
                                clara.enabled = false;
                                if (stop == false)
                                {
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    stop = true;
                                }
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                clara.enabled = true;
                                break;
                            case 11:
                                panel.enabled = false;
                                clara.enabled = false;
                                if (stoptwo == false)
                                {
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    ExecuteEvents.Execute<IPointerClickHandler>(celdas[2], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                    stoptwo = true;
                                }
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                clara.enabled = true;
                                break;
                            case 16:
                                variables_indestructibles.Tutorial = "4";
                                arcTut.guardar_variables();
                                break;
                        }
                        break;
                    case "4":
                        //Selección
                        key.SetBool("Texting", true);
                        animclara.SetBool("Silencio", false);
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            animclara.SetBool("Silencio", true);
                            key.SetBool("Texting", false);
                        }
                        switch (cont)
                        {
                            case 2:
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                pointer.SetBool("Personaje", true);
                                break;
                            case 3:
                                pointer.SetBool("Personaje", false);
                                pointer.SetBool("Delete", true);
                                break;
                            case 4:
                                pointer.SetBool("Delete", false);
                                pointer.SetBool("Jefe", true);
                                break;
                            case 5:
                                pointer.SetBool("Jefe", false);
                                break;
                            case 6:
                                pointer.SetBool("Jefes", true);
                                break;
                            case 8:
                                pointer.SetBool("Jefes", false);
                                pointer.SetBool("Sistema", true);
                                break;
                            case 11:
                                pointer.SetBool("Sistema", false);
                                break;
                            case 15:
                                Fight();
                                break;
                        }
                        break;
                    case "5":
                        //BAtalla
                        key.SetBool("Texting", true);
                        animclara.SetBool("Silencio", false);
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            animclara.SetBool("Silencio", true);
                            key.SetBool("Texting", false);
                        }
                        switch (cont)
                        {
                            case 14:
                                if (stopfour == false)
                                {
                                    //nombre de clara
                                    clara.enabled = false;
                                    panel.enabled = false;
                                    dt.SetActive(false);
                                    displayText.enabled = false;
                                    stopfour = true;
                                }
                                break;
                            case 19:
                                variables_indestructibles.Tutorial = "6";
                                variables_indestructibles.first = "false";
                                arcTut.guardar_variables();
                                LoadScene.sceneToLoad = "Mapajuego";
                                load.SetActive(true);
                                break;
                        }
                        break;
                    case "6":
                        //Entrenamiento
                        if (cont == 1 || cont == 13)
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
                            if (cont == 1 || cont == 13)
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
                        if (cont == 2)
                        {
                            animclara.SetBool("Happy", false);
                            animclara.SetBool("SilHappy", false);
                        }
                        switch (cont)
                        {
                            case 7:
                                panel.enabled = false;
                                ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                break;
                            case 13:
                                Train();
                                break;
                        }
                        break;
                    case "7":
                        //Santuario
                        key.SetBool("Texting", true);
                        animclara.SetBool("Silencio", false);
                        if (displayText.text == FindObjectOfType<Dialog_manager>().activeSentence)
                        {
                            animclara.SetBool("Silencio", true);
                            key.SetBool("Texting", false);
                        }
                        switch (cont)
                        {
                            case 4:
                                panel.enabled = false;
                                ExecuteEvents.Execute<IPointerClickHandler>(celdas[0], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                panel.enabled = true;
                                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                                break;
                            case 8:
                                panel.enabled = false;
                                ExecuteEvents.Execute<IPointerClickHandler>(celdas[1], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                                panel.enabled = true;
                                break;
                            case 12:
                                Sacrifice();
                                break;
                        }
                        break;
                    case "8":
                        //Nivel máximo
                        break;
                }
            }
        }
    }
}
