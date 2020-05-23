using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FalseFight : MonoBehaviour
{
    private Transform mov;
    private Vector3 pos, dest;
    public int turno;
    FightData data;
    private Archivos arcfalse;
    private Animator aspanim, animboss, clics, attack, darka;
    private int[] hp = new int[4];
    private int actl, lifec, actlb, lifeb;
    public Text[] habnames = new Text[4];
    public Text[] habpoints = new Text[4];
    public Text lifeBoss, actBoss, lifeChar, lifeAct; //Vida del jefe, vida restante del jefe
    public GameObject PanelHabs, jefe, tut, dt;
    public TextMeshProUGUI displayText;
    private float actc; //Valor de la vida actual del personaje
    private float totalc, percentC; //Valor de la vida total del personaje
    private float actb; //Valor de la vida actual del jefe
    private float totalb, percentB; //Valor de la vida total del jefe
    public Image BarChar, BarBoss;
    public Image clara, panel;
    private string actanim;
    private bool isatck = false, isatckB = false;
    private int pp;

    void Start()
    {
        turno = 0;
        pp = 1;
        data = GameObject.Find("Fight").GetComponent<FightData>();
        arcfalse = GameObject.Find("Fight").GetComponent<Archivos>();
        darka = GameObject.Find("BossDark").GetComponent<Animator>();
        aspanim = GameObject.Find("PerAspirina").GetComponent<Animator>();
        animboss = GameObject.Find("PerCefalea").GetComponent<Animator>();
        attack = GameObject.Find("HabSimple").GetComponent<Animator>();
        clics = GameObject.Find("DestSimple").GetComponent<Animator>();
        arcfalse.cargar_variables();
        lifeChar.text = variables_indestructibles.Personajes[0, 7];
        lifeAct.text = variables_indestructibles.Personajes[0, 7];
        lifeBoss.text = data.LifeBoss[0].ToString();
        actBoss.text = data.LifeBoss[0].ToString();
        for (int i = 0; i < 4; i++)
        {
            hp[i] = 8350;
            Debug.Log(data.HabChar[0, i]);
        }
        StartCoroutine(InitAnimation());
    }

    private IEnumerator InitAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        aspanim.SetBool("Stand", true);
        animboss.SetBool("Stand", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (turno == 0)
        {
            ShowHabs(pp);
        }
        if (turno == 1)
        {
            if (jefe)
            {
                PanelHabs.SetActive(false);
                isatckB = false;
                StartCoroutine(BossAtck());
                if (isatck == false)
                {
                    lifeAct.text = (Int32.Parse(lifeAct.text) - 8333).ToString();
                    isatck = true;
                }
            }
        }
        for (int y = 0; y < 3; y++)
        {
            actc = float.Parse(lifeAct.text);
            totalc = float.Parse(lifeChar.text);
            percentC = ((100 * actc) / totalc) / 100;
            BarChar.fillAmount = percentC;
        }
        actb = float.Parse(actBoss.text);
        totalb = float.Parse(lifeBoss.text);
        percentB = ((100 * actb) / totalb) / 100;
        BarBoss.fillAmount = percentB;
    }

    private void Points()
    {
        if (pp < 5)
        {
            pp++;
        }
        if (pp > 4)
        {
            pp = 1;
        }
    }

    private void ShowHabs(int points)
    {
        PanelHabs.SetActive(true);
        for (int x = 0; x < points; x++)
        {
            habnames[x].text = data.HabChar[0, x];
            habpoints[x].text = hp[x].ToString();
        }
        for (int b = points; b < 4; b++)
        {
            habnames[b].text = "Cargando...";
            habpoints[b].text = "...";
        }
    }

    private IEnumerator BossAtck()
    {
        darka.SetBool("Action", true);
        yield return new WaitForSeconds(2f);
        darka.SetBool("Action", false);
        StartCoroutine(Dark());
    }

    private IEnumerator Dark()
    {
        aspanim.SetBool("Hurt", true);
        yield return new WaitForSeconds(1f);
        aspanim.SetBool("Hurt", false);
        isatck = false;
        turno = 0;
    }

    private IEnumerator DoAnim()
    {
        aspanim.SetBool(actanim, true);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Clic());
    }

    IEnumerator Clic()
    {
        clics.SetBool("Cliceasy", true);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(AnimHab());
        clics.SetBool("Cliceasy", false);
    }

    IEnumerator AnimHab()
    {
        attack.SetBool("Attack", true);
        yield return new WaitForSeconds(1.8f);
        StartCoroutine(DamageB());
        attack.SetBool("Attack", false);
        aspanim.SetBool(actanim, false);
    }

    IEnumerator DamageB()
    {
        animboss.SetBool("Hurt", true);
        yield return new WaitForSeconds(1f);
        animboss.SetBool("Hurt", false);
        Points();
        StartCoroutine(IsDefeated());
    }

    IEnumerator IsDefeated()
    {
        actBoss.text = (Int32.Parse(actBoss.text) - 8350).ToString();
        if (Int32.Parse(actBoss.text) < 0)
        {
            actBoss.text = "0";
            animboss.SetBool("Defeat", true);
        }
        else
        {
            turno = 1;
        }
        yield return new WaitForSeconds(1f);
        if (actBoss.text.Equals("0"))
        {
            Destroy(GameObject.Find("PerCefalea"));
            clara.enabled = true;
            panel.enabled = true;
            dt.SetActive(true);
            displayText.enabled = true;
        }
    }

    public void UseHab(int id)
    {
        if (habnames[id].text != "Cargando...")
        {
            actanim = "Hab0" + (id + 1).ToString();
            StartCoroutine(DoAnim());
        }
    }

    public void Arrow(string bot)
    {
        mov = GameObject.Find(bot).GetComponent<Transform>();
        pos = mov.transform.position;
        dest = new Vector3(pos.x - 95, pos.y + 1, pos.z);
        GameObject.Find("arrow").transform.position = dest;
    }
}
