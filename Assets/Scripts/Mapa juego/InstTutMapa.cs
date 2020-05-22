using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstTutMapa : MonoBehaviour
{
    public Dialogs dialog;
    public GameObject load, tut, focus;
    public Image clara, panel;
    public Animator pointer, animclara, key;
    public TextMeshProUGUI displayText;
    public Archivos arcTut;

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

    void Update()
    {
        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                int cont = FindObjectOfType<Dialog_manager>().cont;
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
                        switch (FindObjectOfType<Dialog_manager>().cont)
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
                    case "1":

                        break;
                }
            }
        }
    }
}
