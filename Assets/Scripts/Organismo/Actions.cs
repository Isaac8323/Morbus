using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    public int turno;
    private Animator animate; //Animator que ira ejecutando las animaciones de cada personaje
    private Animation anim;
    public Animator[] clics = new Animator[3];
    private Vector3 pos; //Posición del texto en el que se enfocará el puntero >>
    private Vector3 dest; //Coordenadas a donde irá el puntero >>
    private Transform mov; //Posición a donde irá el puntero >>
    public GameObject[] Goclics = new GameObject[3]; //Objetos que contienen los efectos de clic
    public GameObject[] Characters = new GameObject[3]; //G.O.'s donde se instanciaran los personajes
    public GameObject PanelHabs; //Panel de habilidades de personajes
    public GameObject[] character = new GameObject[25]; //Prefabs de los personajes que serán instanciados
    public Text[] habilities = new Text[4]; //Text's donde irá la habilidad del personaje en turno
    public Text[] damages = new Text[4]; //Text's donde irá el daño correspondiente de la habilidad  del personaje en turno
    public Text[] labels = new Text[3]; //Text's donde irán los nombres de los personajes
    public Text[] lifeChar = new Text[3]; //Text's donde irá la vida total de cada personaje
    public Text[] lifeAct = new Text[3]; //Text's donde irá la vida restante de cada personaje
    public Text lifeBoss, actBoss; //Vida del jefe, vida restante del jefe
    public Image[] turn = new Image[3]; //Barra que indica el turno actual del personaje
    public Image[] preview = new Image[3]; //Miniatura del personaje
    public Image[] BarChar = new Image[3]; //Barra de vida de cada personaje
    public Image BarBoss; //Barra de vida del jefe
    public Text boss; //Text que contiene el nombre del jefe actual
    private string[,] HabPS = new string[4, 4]; //Nombres de las habilidades de cada personaje
    private int[,] HabP = new int[4, 4]; //Puntos de las habilidades de cada personaje
    private int[] PP = new int[4]; //Contador para el uso de habilidades de cada personaje
    private float[] percentC = new float[3]; //Valor para graficar la vida de cada personaje
    private float percentB; //Valor para graficar la vida de cada personaje
    private float actc; //Valor de la vida actual del personaje
    private float totalc; //Valor de la vida total del personaje
    private float actb; //Valor de la vida actual del jefe
    private float totalb; //Valor de la vida total del jefe
    TempData selected; //Archivo con los parametros actuales de la batalla

    void Start()
    {
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        boss.text = selected.nameBoss;
        for (int x = 0; x < 3; x++)
        {
            labels[x].text = selected.nameChar[x];
            preview[x].sprite = Resources.Load<Sprite>(selected.nameChar[x]);
            lifeChar[x].text = selected.lifeChar[x].ToString();
            lifeAct[x].text = selected.lifeChar[x].ToString();
            for (int y = 0; y < 4; y++)
            {
                HabP[x, y] = selected.damageChar[x, y];
                HabPS[x, y] = selected.HabChar[x, y];
            }
        }
        for (int u = 0; u < 4; u++)
        {
            PP[u] = 1;
        }
        lifeBoss.text = selected.lifeBoss.ToString();
        actBoss.text = selected.lifeBoss.ToString();
        StartCoroutine(InitAppear());
        StartCoroutine(Wait());
    }

    void Update()
    {
        switch (turno)
        {
            case 0:
                animate = GameObject.Find("Char01").GetComponentInChildren<Animator>();
                ShowHabs(selected.idChar[turno + 1], PP[turno]);
                /*Character[0].MyTurn = true;
                Character[1].MyTurn = false;
                Character[2].MyTurn = false;*/
                break;
            case 1:
                animate = GameObject.Find("Char02").GetComponentInChildren<Animator>();
                ShowHabs(selected.idChar[turno + 1], PP[turno]);
                /*Character[0].MyTurn = false;
                Character[1].MyTurn = true;
                Character[2].MyTurn = false;*/
                break;
            case 2:
                animate = GameObject.Find("Char03").GetComponentInChildren<Animator>();
                ShowHabs(selected.idChar[turno + 1], PP[turno]);
                /*Character[0].MyTurn = false;
                Character[1].MyTurn = false;
                Character[2].MyTurn = true;*/
                break;
            case 3:
                /*Character[0].MyTurn = false;
                Character[1].MyTurn = false;
                Character[2].MyTurn = false;
                BossS.MyTurn = true;*/
                break;
        }
        for (int y = 0; y < 3; y++)
        {
            actc = float.Parse(lifeAct[y].text);
            totalc = float.Parse(lifeChar[y].text);
            percentC[y] = ((100 * actc) / totalc) / 100;
            BarChar[y].fillAmount = percentC[y];
            //lifeAct[y].text = (Int32.Parse(lifeAct[y].text) - 100).ToString(); prueba para barra
            //Debug.Log(percentC[y]);
        }
        actb = float.Parse(actBoss.text);
        totalb = float.Parse(lifeBoss.text);
        percentB = ((100 * actb) / totalb) / 100;
        BarBoss.fillAmount = percentB;
        //actBoss.text = (Int32.Parse(actBoss.text) - 100).ToString();
        //Debug.Log("Boss%: " + percentB);
    }

    private void Turn()
    {
        if (turno < 4)
        {
            turno++;
        }
        if (turno == 3)
        {
            turno = 0;
        }
    }

    private void Points()
    {
        if (PP[turno] < 5)
        {
            PP[turno]++;
        }
        if (PP[turno] > 4)
        {
            PP[turno] = 1;
        }
    }

    private void ShowHabs(int id, int points)
    {
        PanelHabs.SetActive(true);
        for (int x = 0; x < points; x++)
        {
            habilities[x].text = HabPS[id, x].ToString();
        }
        for (int b = points; b < 4; b++)
        {
            habilities[b].text = "Cargando...";
        }
    }

    private IEnumerator InitAppear()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 25; y++)
            {
                if (selected.idChar[x + 1] == y)
                {
                    GameObject child = Instantiate(character[y]) as GameObject;
                    child.transform.parent = Characters[x].transform;
                    child.transform.position = Characters[x].transform.position;
                    child.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            yield return wait;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(InitAnimation());
    }

    private IEnumerator InitAnimation()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        for (int x = 0; x < 3; x++)
        {
            animate = Characters[x].GetComponentInChildren<Animator>();
            animate.SetBool("Stand", true);
            yield return wait;
        }
    }

    private IEnumerator DoAnim(string name)
    {
        animate.SetBool(name, true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Clic(variables_indestructibles.Personajes[selected.idChar[turno], 1]));
        Points();
        Turn();
    }

    IEnumerator Clic(string type)
    {
        int pos = 0;
        switch (type)
        {
            case "easy":
                pos = 0;
                break;
            case "Complex":
                pos = 1;
                break;
            case "Hard":
                pos = 2;
                break;
        }
        Goclics[pos].SetActive(true);
        clics[pos].SetBool("Clic" + type, true);
        yield return new WaitForSeconds(0.2f);
        clics[pos].SetBool("Clic" + type, false);
        Goclics[pos].SetActive(false);
    }

    public void UseHab(int id)
    {
        if (habilities[id].text != "Cargando...")
        {
            animate = Characters[turno].GetComponentInChildren<Animator>();
            StartCoroutine(DoAnim("Hab0" + (id + 1).ToString()));
        }
    }

    public void Arrow(string bot)
    {
        mov = GameObject.Find(bot).GetComponent<Transform>();
        pos = mov.transform.position;
        dest = new Vector3(pos.x - 95, pos.y + 1, pos.z);
        GameObject.Find("arrow").transform.position = dest;
    }

    public void OverHab(string bot)
    {
        Arrow(bot);
    }
}
