using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    
    private Vector3 pos;
    private Vector3 dest;
    private Transform mov;
    public Text[] labels = new Text[3];
    public Text boss;
    FightData data;
    TempData selected;


    void Start()
    {
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        data = GetComponent<FightData>();
        boss.text = selected.nameBoss;
        for (int x = 0; x<3; x++)
        {
            labels[x].text = selected.nameChar[x];
        }
        
    }

    void Update()
    {
        
    }

    public void Arrow(string bot)
    {
        mov = GameObject.Find(bot).GetComponent<Transform>();
        pos = mov.transform.position;
        dest = new Vector3(152, pos.y + 4, pos.z);
        GameObject.Find("Aspirina_arrow01").transform.position = dest;
    }

    public void HOne()
    {
        Arrow("Aspirina_Hab_01");
    }

    public void HTwo()
    {
        Arrow("Aspirina_Hab_02");
    }
    public void HThree()
    {
        Arrow("Aspirina_Hab_03");
    }
    public void HFour()
    {
        Arrow("Aspirina_Hab_04");
    }
}
