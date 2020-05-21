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

    void Start()
    {
        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                FindObjectOfType<Dialog_manager>().StartDialogue(dialog);
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
            }
        }
    }

    void Update()
    {
        if (tut)
        {
            if (tut.activeInHierarchy == true)
            {
                if (FindObjectOfType<Dialog_manager>().cont == 13 || FindObjectOfType<Dialog_manager>().cont == 47)
                {
                    key.SetBool("Texting", true);
                    animclara.SetBool("Verguenza", true);
                }
                else if (FindObjectOfType<Dialog_manager>().cont == 45 || FindObjectOfType<Dialog_manager>().cont == 48)
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
                    if (FindObjectOfType<Dialog_manager>().cont == 13 || FindObjectOfType<Dialog_manager>().cont == 47)
                    {
                        animclara.SetBool("SilVerguenza", true);
                        key.SetBool("Texting", false);
                    }
                    else if (FindObjectOfType<Dialog_manager>().cont == 45 || FindObjectOfType<Dialog_manager>().cont == 48)
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
                switch (FindObjectOfType<Dialog_manager>().cont)
                {
                    case 11:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                        clara.enabled = false;
                        focus.SetActive(true);
                        pointer.SetBool("Tutorial", true);
                        break;
                    case 13:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                        panel.enabled = true;
                        clara.enabled = true;
                        focus.SetActive(false);
                        break;
                    case 14:
                        animclara.SetBool("SilVerguenza", false);
                        animclara.SetBool("Verguenza", false);
                        break;
                    case 15:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                        clara.enabled = false;
                        focus.SetActive(true);
                        pointer.SetBool("Tienda", true);
                        break;
                    case 18:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                        panel.enabled = true;
                        clara.enabled = true;
                        focus.SetActive(false);
                        break;
                    case 26:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                        clara.enabled = false;
                        focus.SetActive(true);
                        pointer.SetBool("Laboratorio", true);
                        break;
                    case 28:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                        panel.enabled = true;
                        clara.enabled = true;
                        focus.SetActive(false);
                        break;
                    case 30:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                        clara.enabled = false;
                        focus.SetActive(true);
                        pointer.SetBool("Almacen", true);
                        break;
                    case 33:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                        panel.enabled = true;
                        clara.enabled = true;
                        focus.SetActive(false);
                        break;
                    case 40:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.2f);
                        clara.enabled = false;
                        focus.SetActive(true);
                        pointer.SetBool("Arena", true);
                        break;
                    case 42:
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0.5f);
                        panel.enabled = true;
                        clara.enabled = true;
                        focus.SetActive(false);
                        break;
                    case 46:
                        animclara.SetBool("Happy", false);
                        animclara.SetBool("SilHappy", false);
                        break;
                    case 48:
                        animclara.SetBool("SilVerguenza", false);
                        animclara.SetBool("Verguenza", false);
                        break;
                    case 50:
                        LoadScene.sceneToLoad = "Laboratorio";
                        load.SetActive(true);
                        break;
                }
            }
        }

    }
}
