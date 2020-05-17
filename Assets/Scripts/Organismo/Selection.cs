using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public GameObject[] characters = new GameObject[26]; //Arreglo de gameobjects de las cartas de personajes
    public GameObject[] bosses = new GameObject[16]; //Arreglo de gameobjects de las cartas de los jefes
    public GameObject[] miniBoss = new GameObject[16]; //Arreglo de las miniaturas de los jefes
    public GameObject LoadPanel, panel, arrowl, arrowr, error; //Pantalla de carga, panel de personajes, flechas para cambiar de organismo, etiqueta de error
    public GameObject Reference; //G.O. donde se almacena la información temporal de selección
    public GameObject ReadyButton; //Botón para proceder al enfrentamiento
    private Image[] thumbs = new Image[4]; //Arreglo de imagenes de las miniaturas de personajes
    private Image[] SoonB = new Image[4]; //Arreglo de imagenes de las miniaturas de los 3 jefes siguientes
    public Image[] locks = new Image[16]; //Arreglo de las imagenes de candado de jefes
    public Image[] courts = new Image[16]; //Arreglo de las imagenes oscurecidas dentro de las cartas de jefes
    public Text warning; //label que limita los sistemas al jugador según su nivel
    public Text[] defeats = new Text[16]; //Arreglo de los textos de "derrotado" dentro de las cartas de jefes
    private Text[] labels = new Text[4]; //Labels de los nombres de personajes elegidos
    private Image background; //Imagen del fondo del organismo actual
    private Text nameboss, descboss, system; //Nombre y descripción del jefe en turno, sistema del ser humano actual
    public Text[] cants = new Text[26]; //Arreglo de las cantidades de personajes dentro de las tarjetas
    private int[] cant; //Cantidades de personajes leídas del archivo
    private bool[] slots = new bool[4]; //Banderas que indican si el slot ya tiene personaje    
    private string[] tags = { "one", "two", "three", "First", "Sec", "Third" }; //Prefijos y sufijos de los nombres de los gameobjects
    public int[] ides = new int[4]; //Guarda el id del personaje que en el slot que fue seleccionado
    private int slot, boss, flagBoss, flagSystem, bossControl; //etiqueta que indica a qué slot se guardara el personaje seleccionado, id del jefe leído del archivo, bandera del siguiente jefe, bandera de selección de jefe
    public int pos; //Posición del arreglo de personajes del script TempData
    public Archivos archivo_organismo; //Funciones de la clase archivos para obtener info de los personajes del jugador
    FightData data;
    TempData temp;

    void Start()
    {
        Reference = GameObject.Find("Reference");
        temp = GameObject.Find("Reference").GetComponent<TempData>();
        data = GameObject.Find("Select").GetComponent<FightData>();
        archivo_organismo.cargar_variables();
        if (variables_indestructibles.Arenas.Equals("true"))
        {
            arrowl.SetActive(true);
            arrowr.SetActive(true);
        }

        if (variables_indestructibles.Arenas.Equals("false"))
        {
            arrowl.SetActive(false);
            arrowr.SetActive(false);
        }
        cant = new int[26];
        for (int i = 0; i < 25; i++)
        {
            cant[i] = Int32.Parse(variables_indestructibles.Personajes[i, 2]);
        }
        background = GameObject.Find("BossSelection").GetComponent<Image>();
        boss = Int32.Parse(variables_indestructibles.nivel_organismo_jefes);
        bossControl = boss;
        nameboss = GameObject.Find("NameBoss").GetComponent<Text>();
        descboss = GameObject.Find("DescBoss").GetComponent<Text>();
        system = GameObject.Find("lbl_sistema").GetComponent<Text>();

        bosses[boss - 1].SetActive(true);
        flagBoss = boss + 1;

        if (boss > 0 && boss <= 4)
        {
            flagSystem = 0;
        }
        if (boss >= 5 && boss <= 8)
        {
            flagSystem = 1;
        }
        if (boss >= 9 && boss <= 12)
        {
            flagSystem = 2;
        }
        if (boss >= 13 && boss <= 16)
        {
            flagSystem = 3;
        }

        for (int v = 0; v <= 2; v++)
        {
            thumbs[v] = GameObject.Find(tags[v + 3] + "Char").GetComponent<Image>();
            thumbs[v].sprite = Resources.Load<Sprite>("none");
            labels[v] = GameObject.Find("lbl_Char" + tags[v]).GetComponent<Text>();
            labels[v].text = "Seleccionar...";
        }
        VerifyStateBoss();
    }

    private void Update()
    {
        nameboss.text = data.NameBoss[bossControl];
        descboss.text = data.DescBoss[bossControl];
    }

    public void SelectBoss(int id)
    {
        if (variables_indestructibles.Arenas.Equals("true"))
        {
            HideBoss();
            bossControl = id;
            bosses[id - 1].SetActive(true);
        }
    }

    private void HideMiniB()
    {
        for (int i = 0; i <= 15; i++)
        {
            miniBoss[i].SetActive(false);
        }
    }

    public void Arrow(string dir)
    {
        if (dir.Equals("left"))
        {
            if (flagSystem > 0)
            {
                flagSystem--;
            }
        }
        if (dir.Equals("right"))
        {
            if (flagSystem < 3)
            {
                flagSystem++;
            }
        }
        VerifyStateBoss();
    }

    public void VerifyStateBoss()
    {
        switch (flagSystem)
        {
            case 0:
                system.text = data.Organisms[0];
                HideMiniB();
                for (int b = 0; b <= 3; b++)
                {
                    miniBoss[b].SetActive(true);
                    if (variables_indestructibles.Arenas.Equals("true"))
                    {
                        bossControl = 1;
                        HideBoss();
                        bosses[0].SetActive(true);
                        locks[b].enabled = false;
                        courts[b].enabled = false;
                        defeats[b].enabled = false;
                    }
                    if (variables_indestructibles.Arenas.Equals("false"))
                    {
                        if (b < boss - 1)
                        {
                            locks[b].enabled = false;
                            courts[b].enabled = false;
                            defeats[b].enabled = true;
                        }
                        if (b > boss - 1)
                        {
                            locks[b].enabled = true;
                            courts[b].enabled = true;
                            defeats[b].enabled = false;
                        }
                        if (b == boss - 1)
                        {
                            locks[b].enabled = false;
                            courts[b].enabled = false;
                            defeats[b].enabled = false;
                        }
                    }
                }
                background.sprite = Resources.Load<Sprite>("SisNervioso");
                temp.background = 0;
                break;
            case 1:
                if (Int32.Parse(variables_indestructibles.level[0]) > 3)
                {
                    ReadyButton.SetActive(true);
                    system.text = data.Organisms[1];
                    HideMiniB();
                    for (int p = 4; p <= 7; p++)
                    {
                        miniBoss[p].SetActive(true);
                        if (variables_indestructibles.Arenas.Equals("true"))
                        {
                            bossControl = 5;
                            HideBoss();
                            bosses[4].SetActive(true);
                            locks[p].enabled = false;
                            courts[p].enabled = false;
                            defeats[p].enabled = false;
                        }
                        if (variables_indestructibles.Arenas.Equals("false"))
                        {
                            if (p < boss - 1)
                            {
                                locks[p].enabled = false;
                                courts[p].enabled = false;
                                defeats[p].enabled = true;
                            }
                            if (p > boss - 1)
                            {
                                locks[p].enabled = true;
                                courts[p].enabled = true;
                                defeats[p].enabled = false;
                            }
                            if (p == boss - 1)
                            {
                                locks[p].enabled = false;
                                courts[p].enabled = false;
                                defeats[p].enabled = false;
                            }
                        }
                    }
                    background.sprite = Resources.Load<Sprite>("SisRes");
                    temp.background = 1;
                }
                if (Int32.Parse(variables_indestructibles.level[0]) < 4)
                {
                    warning.text = "El siguiente sistema se desbloquea al nivel 4";
                    flagSystem--;
                    ReadyButton.SetActive(false);
                    VerifyStateBoss();
                }
                break;
            case 2:
                if (Int32.Parse(variables_indestructibles.level[0]) > 8)
                {
                    ReadyButton.SetActive(true);
                    system.text = data.Organisms[2];
                    HideMiniB();
                    for (int q = 8; q <= 11; q++)
                    {
                        miniBoss[q].SetActive(true);
                        if (variables_indestructibles.Arenas.Equals("true"))
                        {
                            bossControl = 9;
                            HideBoss();
                            bosses[8].SetActive(true);
                            locks[q].enabled = false;
                            courts[q].enabled = false;
                            defeats[q].enabled = false;
                        }
                        if (variables_indestructibles.Arenas.Equals("false"))
                        {
                            if (q < boss - 1)
                            {
                                locks[q].enabled = false;
                                courts[q].enabled = false;
                                defeats[q].enabled = true;
                            }
                            if (q > boss - 1)
                            {
                                locks[q].enabled = true;
                                courts[q].enabled = true;
                                defeats[q].enabled = false;
                            }
                            if (q == boss - 1)
                            {
                                locks[q].enabled = false;
                                courts[q].enabled = false;
                                defeats[q].enabled = false;
                            }
                        }
                    }
                    background.sprite = Resources.Load<Sprite>("SisDigestivo");
                    temp.background = 2;
                }
                if (Int32.Parse(variables_indestructibles.level[0]) < 9)
                {
                    warning.text = "El siguiente sistema se desbloquea al nivel 9";
                    flagSystem--;
                    ReadyButton.SetActive(false);
                    VerifyStateBoss();
                }
                break;
            case 3:
                if (Int32.Parse(variables_indestructibles.level[0]) > 12)
                {
                    ReadyButton.SetActive(true);
                    system.text = data.Organisms[3];
                    HideMiniB();
                    for (int r = 12; r <= 15; r++)
                    {
                        miniBoss[r].SetActive(true);
                        if (variables_indestructibles.Arenas.Equals("true"))
                        {
                            bossControl = 13;
                            HideBoss();
                            bosses[12].SetActive(true);
                            locks[r].enabled = false;
                            courts[r].enabled = false;
                            defeats[r].enabled = false;
                        }
                        if (variables_indestructibles.Arenas.Equals("false"))
                        {
                            if (r < boss - 1)
                            {
                                locks[r].enabled = false;
                                courts[r].enabled = false;
                                defeats[r].enabled = true;
                            }
                            if (r > boss - 1)
                            {
                                locks[r].enabled = true;
                                courts[r].enabled = true;
                                defeats[r].enabled = false;
                            }
                            if (r == boss - 1)
                            {
                                locks[r].enabled = false;
                                courts[r].enabled = false;
                                defeats[r].enabled = false;
                            }
                        }

                    }
                    background.sprite = Resources.Load<Sprite>("SisInmune");
                    temp.background = 3;
                }
                if (Int32.Parse(variables_indestructibles.level[0]) < 13)
                {
                    warning.text = "El siguiente sistema se desbloquea al nivel 13";
                    flagSystem--;
                    ReadyButton.SetActive(false);
                    VerifyStateBoss();
                }
                break;
        }
    }

    //Función que grafica los personajes que el usuario tiene en el archivo y las cantidades de estos
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
    //Desactiva todos las previews de los jefes
    private void HideBoss()
    {
        for (int d = 0; d <= 15; d++)
        {
            bosses[d].SetActive(false);
        }
    }
    //Regresa al menu anterior
    public void Back()
    {
        HideBoss();
        Destroy(Reference);
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }
    //Oculta el panel de personajes
    public void HideChar()
    {
        panel.SetActive(false);
    }
    //Coloca la imagen y nombre del personajes en su casilla correspondiente segun id del mismo y resta la cantidad 
    private void Put(string character, int id)
    {
        thumbs[slot - 1].sprite = Resources.Load<Sprite>(character);
        labels[slot - 1].text = variables_indestructibles.Personajes[id, 0];
        ides[slot] = id;
        if (slots[slot] == false)
        {
            cant[id]--;
            slots[slot] = true;
        }
    }
    //Establece el id del slot en el que se va colocar el personaje
    public void Select(int id)
    {
        slot = id;
        pos = id - 1;
        if (slots[id] == false)
        {
            ViewChar();
        }
    }
    //Carga la pantalla de batalla
    public void Ready()
    {
        if (slots[1] == true && slots[2] == true && slots[3] == true)
        {
            HideBoss();
            if (variables_indestructibles.Arenas.Equals("false"))
            {
                temp.nameBoss = data.NameBoss[Int32.Parse(variables_indestructibles.nivel_organismo_jefes)];
                temp.lifeBoss = data.LifeBoss[boss];
                temp.damageBoss = data.atckBoss[boss];
                temp.idBoss = Int32.Parse(variables_indestructibles.nivel_organismo_jefes);
            }
            if (variables_indestructibles.Arenas.Equals("true"))
            {
                temp.nameBoss = data.NameBoss[bossControl];
                temp.lifeBoss = data.LifeBoss[bossControl];
                temp.damageBoss = data.atckBoss[bossControl];
                temp.idBoss = bossControl;
            }
            for (int x = 0; x < 3; x++)
            {
                temp.idChar[x + 1] = ides[x + 1];
                temp.nameChar[x] = variables_indestructibles.Personajes[ides[x + 1], 0]; //Le pasa el nombre del personaje al script que no se destruye
                temp.lifeChar[x] = Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 7]);
                for (int h = 0; h < 4; h++) //Asignación de daños base
                {
                    //Si está potenciada la habilidad se le agrega el "+" al nombre
                    if (Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 6]) == h + 1)
                    {
                        int t = h;
                        while (t >= 0)
                        {
                            temp.HabChar[x, t] = data.HabChar[ides[x + 1], t] + " +";
                            t--;
                        }
                    }
                    else //Si no está potenciada la habilidad (Para el nombre)
                    {
                        temp.HabChar[x, h] = data.HabChar[ides[x + 1], h];
                    }
                    temp.damageChar[x, h] = data.HChar[ides[x + 1]]; //Puntos contra patología no clave
                }

                //Asignación de daños si es Aspirina
                if (ides[x + 1] == 0)
                {
                    if (temp.idBoss == 10) //Si el jefe es Hemorroides
                    {
                        //En caso de que esté potenciada
                        if (Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 6]) == 1)
                        {
                            temp.damageChar[x, 0] = 69643;
                        }
                        else //Caso de que no esté potenciada
                        {
                            temp.damageChar[x, 0] = 541667;
                        }
                        //En caso de que esté potenciada
                        if (Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 6]) == 2)
                        {
                            temp.damageChar[x, 1] = 81250;
                        }
                        else //Caso de que no esté potenciada
                        {
                            temp.damageChar[x, 1] = 60937;
                        }
                        //En caso de que esté potenciada
                        if (Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 6]) == 3)
                        {
                            temp.damageChar[x, 2] = 97500;
                        }
                        else //Caso de que no esté potenciada
                        {
                            temp.damageChar[x, 2] = 69643;
                        }
                        //En caso de que esté potenciada
                        if (Int32.Parse(variables_indestructibles.Personajes[ides[x + 1], 6]) == 4)
                        {
                            temp.damageChar[x, 3] = 97500;
                        }
                        else //Caso de que no esté potenciada
                        {
                            temp.damageChar[x, 3] = 81250;
                        }
                    }
                }

            }
            LoadScene.sceneToLoad = "Fight";
            LoadPanel.SetActive(true);
        }
        else
        {
            error.SetActive(true);
        }
    }
    //Deselecciona el personaje segun el id de la casilla y resta su cantidad
    public void Minus(int id)
    {
        thumbs[id - 1].sprite = Resources.Load<Sprite>("none");
        labels[id - 1].text = "Seleccionar...";
        if (slots[id] == true)
        {
            cant[ides[id]]++;
            slots[id] = false;
        }
    }
    //Coloca el personaje en la casilla correspondiente
    public void SelectChar(int id)
    {
        Put(variables_indestructibles.Personajes[id, 0], id);
        panel.SetActive(false);
    }
}