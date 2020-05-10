using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Levels : MonoBehaviour
{
    public FightData data;
    public Image bar;
    public Archivos arclvl;
    public Text lvl, req, usr;
    private float exp, newlvl, newrq;
    private float perc, act, total, res;//total es el total de exp que se requiere para pasar de un nivel a otro
    void Start()
    {
        arclvl.cargar_variables();
    }
    void Update()
    {
        exp = Int32.Parse(variables_indestructibles.experiencia);
        for (int e = 0; e < 20; e++)
        {
            if (exp >= data.Exp[e] && exp < data.Exp[e + 1])
            {
                total = data.Exp[e + 1] - data.Exp[e];
                act = exp - data.Exp[e];
                newrq = data.Exp[e + 1];
                newlvl = e + 1;
                variables_indestructibles.level[0] = newlvl.ToString();
                arclvl.guardar_variables();
                req.text = newrq.ToString();
                usr.text = exp.ToString();
                res = ((100 * act) / total) / 100;
                bar.fillAmount = res;
                Debug.Log(total.ToString());
                Debug.Log(exp.ToString());
                Debug.Log(newrq.ToString());
                Debug.Log("Perc: " + res.ToString());
            }
        }
        if (exp >= data.Exp[20])
        {
            req.text = "--";
            usr.text = "--";
            variables_indestructibles.level[0] = "20";
            arclvl.guardar_variables();
            bar.fillAmount = 1;
        }
        lvl.text = variables_indestructibles.level[0];
    }
}
