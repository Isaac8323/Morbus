using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class Actions : MonoBehaviour
{
    public int turno, noatck;
    private Animator animate, animateboss; //Animator que ira ejecutando las animaciones de cada personaje
    private Animation anim;
    public Animator clics;
    public Animator[] AniHabs = new Animator[6];
    private Vector3 pos; //Posición del texto en el que se enfocará el puntero >>
    private Vector3 dest; //Coordenadas a donde irá el puntero >>
    private Transform mov; //Posición a donde irá el puntero >>
    public GameObject instBoss, congrats, LoadPanel, panel;
    public GameObject Goclics; //Objeto que contiene los efectos de clic
    public GameObject[] Characters = new GameObject[3]; //G.O.'s donde se instanciaran los personajes
    public GameObject[] AnimHabs = new GameObject[6];
    public GameObject PanelHabs; //Panel de habilidades de personajes
    public GameObject[] character = new GameObject[26]; //Prefabs de los personajes que serán instanciados
    public GameObject[] Bosses = new GameObject[16]; //Prefabs de los jefes que serán instanciados
    public Text[] habilities = new Text[4]; //Text's donde irá la habilidad del personaje en turno
    public Text[] damages = new Text[4]; //Text's donde irá el daño correspondiente de la habilidad  del personaje en turno
    public Text[] labels = new Text[3]; //Text's donde irán los nombres de los personajes
    public Text[] lifeChar = new Text[3]; //Text's donde irá la vida total de cada personaje
    public Text[] lifeAct = new Text[3]; //Text's donde irá la vida restante de cada personaje
    public Text lifeBoss, actBoss; //Vida del jefe, vida restante del jefe
    public Image[] preview = new Image[3]; //Miniatura del personaje
    public Image[] BarChar = new Image[3]; //Barra de vida de cada personaje
    public Image BarBoss; //Barra de vida del jefe
    public Text boss, status, desc, nameboss, monedas, bismuto; //Text que contiene el nombre del jefe actual
    private string[,] HabPS = new string[3, 4]; //Nombres de las habilidades de cada personaje
    private string actanim;
    private bool acthab; //Verifica si la habilidad está potenciada en el text que se presióno (habilidad)
    private int[,] HabP = new int[3, 4]; //Puntos de las habilidades de cada personaje
    private int[] PP = new int[4]; //Contador para el uso de habilidades de cada personaje
    private float[] percentC = new float[3]; //Valor para graficar la vida de cada personaje
    private float percentB; //Valor para graficar la vida de cada personaje
    private float actc; //Valor de la vida actual del personaje
    private float totalc; //Valor de la vida total del personaje
    private float actb; //Valor de la vida actual del jefe
    private float totalb; //Valor de la vida total del jefe
    TempData selected; //Archivo con los parametros actuales de la batalla
    RewardData reward;
    Archivos arcrew;

    void Start()
    {
        arcrew = GameObject.Find("Fight").GetComponent<Archivos>();
        reward = GameObject.Find("Fight").GetComponent<RewardData>();
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        arcrew.cargar_variables();
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
        panel.SetActive(false);
        PanelHabs.SetActive(false);
        congrats.SetActive(false);
        StartCoroutine(InitAppear());
    }

    void Update()
    {
        for (int h = 0; h < 3; h++)
        {
            if (Int32.Parse(lifeAct[h].text) < 0)
            {
                lifeAct[h].text = "0";
                Destroy(Characters[h]);
            }
        }
        if (instBoss == null)
        {
            PanelHabs.SetActive(false);
            status.text = "¡Felicidades!";
            desc.text = "Has derrotado a:";
            nameboss.text = selected.nameBoss;
            monedas.text = reward.Reward[selected.idBoss - 1, 0].ToString();
            bismuto.text = reward.Reward[selected.idBoss - 1, 1].ToString();
            panel.SetActive(true);
            congrats.SetActive(true);
        }
        if (Characters[0] == null && Characters[1] == null && Characters[2] == null)
        {
            PanelHabs.SetActive(false);
            status.text = "Lastima..";
            desc.text = "Te ha derrotado:";
            nameboss.text = selected.nameBoss;
            monedas.text = reward.RewardF[selected.idBoss - 1, 0].ToString();
            bismuto.text = reward.RewardF[selected.idBoss - 1, 1].ToString();
            panel.SetActive(true);
            congrats.SetActive(true);
        }
        switch (turno)
        {
            case 0:
                if (Characters[turno])
                {
                    //animate = GameObject.Find("Char01").GetComponentInChildren<Animator>();
                    ShowHabs(turno, PP[turno]);
                    ImgTurn("Name01");
                }
                else
                {
                    Turn();
                }
                break;
            case 1:
                if (Characters[turno])
                {
                    //animate = GameObject.Find("Char02").GetComponentInChildren<Animator>();
                    ShowHabs(turno, PP[turno]);
                    ImgTurn("Name02");
                }
                else
                {
                    Turn();
                }
                break;
            case 2:
                if (Characters[turno])
                {
                    //animate = GameObject.Find("Char03").GetComponentInChildren<Animator>();
                    ShowHabs(turno, PP[turno]);
                    ImgTurn("Name03");
                }
                else
                {
                    Turn();
                }
                break;
            case 3:
                if (instBoss)
                {
                    int[] acts = new int[3];
                    for (int x = 0; x < 3; x++)
                    {
                        acts[x] = Int32.Parse(lifeAct[x].text);
                        Debug.Log(acts[x]);
                    }
                    int max = acts.Min();
                    bool first = false;
                    for (int y = 0; y < 3; y++)
                    {
                        if (first == false)
                        {
                            if (lifeAct[y].text.Equals(max.ToString()))
                            {
                                if (Characters[y])
                                {
                                    lifeAct[y].text = (Int32.Parse(lifeAct[y].text) - selected.damageBoss).ToString();
                                    StartCoroutine(BossTurn(y));
                                    first = true;
                                }
                            }
                        }
                    }
                    Turn();
                }
                else
                {
                    //Ganaste we
                }
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

    public void Finish()
    {
        if (status.text == "Lastima..")
        {
            variables_indestructibles.monedas[0] = (Int32.Parse(variables_indestructibles.monedas[0]) + reward.RewardF[selected.idBoss - 1, 0]).ToString();
            variables_indestructibles.bismuto = (Int32.Parse(variables_indestructibles.bismuto) + reward.RewardF[selected.idBoss - 1, 1]).ToString();
            arcrew.guardar_variables();
        }
        if (status.text == "¡Felicidades!")
        {
            variables_indestructibles.monedas[0] = (Int32.Parse(variables_indestructibles.monedas[0]) + reward.Reward[selected.idBoss - 1, 0]).ToString();
            variables_indestructibles.bismuto = (Int32.Parse(variables_indestructibles.bismuto) + reward.Reward[selected.idBoss - 1, 1]).ToString();
            if (Int32.Parse(variables_indestructibles.nivel_organismo_jefes) == 16)
            {
                variables_indestructibles.Arenas = "true";
            }
            else
            {
                variables_indestructibles.nivel_organismo_jefes = (Int32.Parse(variables_indestructibles.nivel_organismo_jefes) + 1).ToString();
            }
            variables_indestructibles.experiencia = (Int32.Parse(variables_indestructibles.experiencia) + reward.Rewardxp[selected.idBoss - 1]).ToString();
            arcrew.guardar_variables();
        }
        Destroy(GameObject.Find("Reference"));
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }

    private void Turn()
    {
        if (turno < 4)
        {
            turno++;
        }
        if (turno == 4)
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
        if (PanelHabs.activeInHierarchy)
        {
            PanelHabs.SetActive(true);
            for (int x = 0; x < points; x++)
            {
                habilities[x].text = HabPS[id, x].ToString();
                damages[x].text = selected.damageChar[id, x].ToString();
            }
            for (int b = points; b < 4; b++)
            {
                habilities[b].text = "Cargando...";
                damages[b].text = "...";
            }
        }
    }

    private IEnumerator BossTurn(int id)
    {
        animate = Characters[id].GetComponentInChildren<Animator>();
        animate.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.2f);
        animate.SetBool("Hurt", false);

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
                    if (selected.idChar[x + 1] == 24 && variables_indestructibles.Skin.Equals("true"))
                    {
                            GameObject children = Instantiate(character[25]) as GameObject;
                            children.transform.parent = Characters[x].transform;
                            children.transform.position = Characters[x].transform.position;
                            children.transform.localScale = new Vector3(1, 1, 1);
                    }
                    GameObject child = Instantiate(character[y]) as GameObject;
                    child.transform.parent = Characters[x].transform;
                    child.transform.position = Characters[x].transform.position;
                    child.transform.localScale = new Vector3(1, 1, 1);

                }
            }
            yield return wait;
        }
        StartCoroutine(AppearBoss());
    }

    private IEnumerator AppearBoss()
    {
        GameObject child = Instantiate(Bosses[selected.idBoss]) as GameObject;
        child.transform.parent = instBoss.transform;
        child.transform.position = instBoss.transform.position;
        child.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
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
        animateboss = instBoss.GetComponentInChildren<Animator>();
        animateboss.SetBool("Stand", true);
        PanelHabs.SetActive(true);
    }

    private IEnumerator DoAnim()
    {
        animate.SetBool(actanim, true);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Clic(variables_indestructibles.Personajes[selected.idChar[turno], 1]));
    }

    IEnumerator Clic(string type)
    {
        Goclics.SetActive(true);
        clics.SetBool("Cliceasy", true);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(AnimHab(selected.idChar[turno + 1]));
        Goclics.SetActive(false);
        clics.SetBool("Cliceasy", false);
    }

    IEnumerator AnimHab(int id)
    {
        int hab = 0;
        switch (variables_indestructibles.Personajes[id, 1])
        {
            case "easy":
                hab = 0;
                if (acthab == true)
                {
                    hab = 1;
                }
                break;
            case "Complex":
                hab = 2;
                if (acthab == true)
                {
                    hab = 3;
                }
                break;
            case "Hard":
                hab = 4;
                if (acthab == true)
                {
                    //hab = 5;
                }
                break;
        }
        AnimHabs[hab].SetActive(true);
        AniHabs[hab].SetBool("Attack", true);
        yield return new WaitForSeconds(1.8f);
        StartCoroutine(DamageBoss());
        //Coroutine de daño
        AnimHabs[hab].SetActive(false);
        AniHabs[hab].SetBool("Attack", false);
        animate.SetBool(actanim, false);
    }

    IEnumerator DamageBoss()
    {
        animateboss = instBoss.GetComponentInChildren<Animator>();
        animateboss.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.2f);
        animateboss.SetBool("Hurt", false);
        actBoss.text = (Int32.Parse(actBoss.text) - selected.damageChar[turno, noatck]).ToString();
        if (Int32.Parse(actBoss.text) < 0)
        {
            StartCoroutine(DefeatBoss());
            actBoss.text = "0";
            Destroy(instBoss);
            PanelHabs.SetActive(false);
        }
        Points();
        Turn();
    }

    IEnumerator DefeatBoss()
    {
        animateboss.SetBool("Defeat", true);
        yield return new WaitForSeconds(0.2f);
    }

    public void UseHab(int id)
    {
        if (habilities[id].text != "Cargando...")
        {
            if (habilities[id].text.Contains("+"))
            {
                acthab = true;
            }
            else
            {
                acthab = false;
            }
            animate = Characters[turno].GetComponentInChildren<Animator>();
            actanim = "Hab0" + (id + 1).ToString();
            noatck = id;
            StartCoroutine(DoAnim());
        }
    }

    public void ImgTurn(string space)
    {
        mov = GameObject.Find(space).GetComponent<Transform>();
        pos = mov.transform.position;
        dest = new Vector3(pos.x, pos.y, pos.z);
        GameObject.Find("Turn01").transform.position = dest;
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
