using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public GameObject[] characters = new GameObject[26]; //Arreglo de gameobjects de las cartas de personajes

    public GameObject[] bosses = new GameObject[17]; //Arreglo de gameobjects de las cartas de los jefes

    public GameObject LoadPanel, panel; //Pantalla de carga, panel de personajes

    private Image[] thumbs = new Image[4]; //Arreglo de imagenes de las miniaturas de personajes

    private Text[] labels = new Text[4]; //Labels de los nombres de personajes elegidos

    private Text nameboss, descboss; //Nombre y descripción del jefe en turno

    public Text[] cants = new Text[26]; //Arreglo de las cantidades de personajes dentro de las tarjetas

    private int[] cant; //Cantidades de personajes leídas del archivo

    private bool[] slots = new bool[4]; //Banderas que indican si el slot ya tiene personaje    

    private string[] tags = { "one", "two", "three", "First", "Sec", "Third" };

    private int[] ides = new int[4];

    //private int

    private int slot, boss, id_charone, id_chartwo, id_charthree, id_slot_one, id_slot_two, id_slot_three;
    Archivos archivo_organismo;

    void Start()
    {
        archivo_organismo = GameObject.Find("BossSelection").GetComponent<Archivos>();

        cant = new int[26];
        cant = archivo_organismo.GetTotalChar();

        for (int v = 0; v <= 2; v++)
        {
            thumbs[v] = GameObject.Find(tags[v + 3] + "Char").GetComponent<Image>();
            thumbs[v].sprite = Resources.Load<Sprite>("none");
            labels[v] = GameObject.Find("lbl_Char" + tags[v]).GetComponent<Text>();
            labels[v].text = "Seleccionar...";
        }

        boss = archivo_organismo.LevelBoss();
        nameboss = GameObject.Find("NameBoss").GetComponent<Text>();
        nameboss.text = archivo_organismo.NameBoss(boss);

        descboss = GameObject.Find("DescBoss").GetComponent<Text>();
        descboss.text = archivo_organismo.DescBoss(boss);

        bosses[boss - 1].SetActive(true);

    }

    public void ViewChar()
    {
        panel.SetActive(true);
        for (int h = 0; h <= 24; h++)
        {
            if (cant[h] < 1)
            {
                characters[h].SetActive(false);
            }
            else
            {
                characters[h].SetActive(true);
                cants[h].text = (cant[h]).ToString();
            }
        }
    }

    private void HideBoss()
    {
        for (int d = 0; d <= 15; d++)
        {
            bosses[d].SetActive(false);
        }
    }

    public void Back()
    {
        HideBoss();
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }

    public void HideChar()
    {
        panel.SetActive(false);
    }

    private void Put(string character, int id)
    {
        thumbs[slot].sprite = Resources.Load<Sprite>(character);

    }

    private void PutSlot(string character, int id)
    {/*
        switch (slot)
        {
            case 1:
                imgone.sprite = Resources.Load<Sprite>(character);
                lblone.text = archivo_organismo.NameCharacter(id);                
                id_slot_one = id;                
                if (full_s_one == false)
                {
                    cant[id]--;
                    full_s_one = true;
                }
                break;
            case 2:
                imgtwo.sprite = Resources.Load<Sprite>(character);
                lbltwo.text = archivo_organismo.NameCharacter(id);                
                id_slot_two = id;
                if(full_s_two == false)
                {
                    cant[id]--;
                    full_s_two = true;
                }                
                break;
            case 3:
                imgthree.sprite = Resources.Load<Sprite>(character);
                lblthree.text = archivo_organismo.NameCharacter(id);                
                id_slot_three = id;
                if(full_s_three == false)
                {
                    cant[id]--;
                    full_s_three = true;
                }                
                break;
        }*/
    }

    /*public void Select(int id)
    {
        slot = id;
        charselect.SetActive(true);
        ViewCharacters();
    }*/

    public void Ready()
    {
        //HidePrevBoss();
        LoadScene.sceneToLoad = "Battle";
        LoadPanel.SetActive(true);
    }

    /**public void MinusOne()
    {
        imgone.sprite = Resources.Load<Sprite>("none");
        lblone.text = "Seleccionar...";
        if(full_s_one == true)
        {
            cant[id_slot_one]++;
            full_s_one = false;
        }        
    }

    public void MinusTwo()
    {
        imgtwo.sprite = Resources.Load<Sprite>("none");
        lbltwo.text = "Seleccionar...";
        if (full_s_two == true)
        {
            cant[id_slot_two]++;
            full_s_two = false;
        }
    }

    public void MinusThree()
    {
        imgthree.sprite = Resources.Load<Sprite>("none");
        lblthree.text = "Seleccionar...";
        if (full_s_three == true)
        {
            cant[id_slot_three]++;
            full_s_three = false;
        }
    }

    public void SelectChar(int id)
    {
        PutSlot(archivo_organismo.NameCharacter(id), id);
        charselect.SetActive(false);
    }*/

}
