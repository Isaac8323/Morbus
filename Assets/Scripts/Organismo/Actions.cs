using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    public float delay;
    int flagdelay;
    public int turnoj;
    public int turnoa;
    public GameObject character, boss, atck01, atck02, atck03, atck04, damage, damaged;
    public int BossLife;
    public int AspirinaLife;
    Archivos healthpoints;
    Text HPC, HPB, status;
    // Start is called before the first frame update
    void Start()
    {
        damage.SetActive(false);
        damaged.SetActive(false);
        Deactivate();
        turnoj = 1;        
        healthpoints = GameObject.Find("Canvas").GetComponent<Archivos>();
        AspirinaLife = healthpoints.HealthPoints(0);
        BossLife = healthpoints.BossLife(0);
        HPC = GameObject.Find("Aspirina_life").GetComponentInChildren<Text>();
        HPC.text = AspirinaLife.ToString();
        HPB = GameObject.Find("Cefalea_life").GetComponentInChildren<Text>();
        HPB.text = BossLife.ToString();
        status = GameObject.Find("Status").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BossLife > 0)
        {
            if (turnoj == 1)
            {
                Deactivate();
                delay += Time.deltaTime;
                if (delay > 3)
                {
                    status.text = "Cefalea utilizo: Contagion";
                    AspirinaLife = AspirinaLife - 8333;
                    turnoj = 0;
                    delay = delay - delay;
                }
            }
        }
        else
        {
            boss.SetActive(false);
            BossLife = 0;
            Deactivate();
            status.text = "Victoria!";
        }
        
        if(turnoj == 0)
        {
            delay += Time.deltaTime;
            if(delay > 3)
            {
                status.text = "Turno: Aspirina";
                if(turnoa == 0)
                {
                    atck01.SetActive(true);
                }
                if(turnoa == 1)
                {
                    atck01.SetActive(true);
                    atck02.SetActive(true);
                }
                if(turnoa == 2)
                {
                    atck01.SetActive(true);
                    atck02.SetActive(true);
                    atck03.SetActive(true);
                }
                if(turnoa == 3)
                {
                    atck01.SetActive(true);
                    atck02.SetActive(true);
                    atck03.SetActive(true);
                    atck04.SetActive(true);
                }
            }
        }
        HPC.text = AspirinaLife.ToString();
        HPB.text = BossLife.ToString();
    }

    public void Deactivate()
    {
        atck01.SetActive(false);
        atck02.SetActive(false);
        atck03.SetActive(false);
        atck04.SetActive(false);
    }

    IEnumerator Attack(int damage)
    {
        yield return new WaitForSeconds(2);        
        character.GetComponent<Animator>().Play("Stand");
        if (turnoa < 4)
        {
            turnoa++;
        }
        if (turnoa > 3)
        {
            turnoa = 0;
        }
        BossLife = BossLife - damage;
        turnoj = 1;
        StopAllCoroutines();
    }

    public void attackone()
    {
        character.GetComponent<Animator>().Play("Aspirina_atack01");                
        StartCoroutine(Attack(8350));
    }
    public void attacktwo()
    {
        character.GetComponent<Animator>().Play("Aspirina_atack02");
        StartCoroutine(Attack(8350));
    }
    public void attackthree()
    {
        character.GetComponent<Animator>().Play("Aspirina_atack03");
        StartCoroutine(Attack(8350));
    }
    public void attackfour()
    {
        character.GetComponent<Animator>().Play("Aspirina_atack04");
        StartCoroutine(Attack(8350));
    }
}
