using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.Sql;
using System.Data;

public class funciones_C_Entrenamiento : MonoBehaviour
{
    public GameObject ConfPanel, warning, btnConfirm, MessConf, notEnought, LoadPanel, tut;
    public GameObject[] slots = new GameObject[25];
    public Image[] Prev = new Image[25];
    public Image Prevform, ImgChar, struc;
    public Text Nameform, NameChar, NoTrain, cost;
    public Sprite[] Formula = new Sprite[25];
    public Text[] Name = new Text[25];
    public Text[] Cant = new Text[25];
    private string[] levelChar = { "easy", "Complex", "Hard" };
    private int costcoin, costbi, selectedId, selectedc, selectedb;
    public Archivos arcEnt;

    void Start()
    {
        ConfPanel.SetActive(false);
        MessConf.SetActive(false);
        arcEnt = GameObject.Find("Tienda").GetComponent<Archivos>();
        arcEnt.cargar_variables();
        if (variables_indestructibles.Tutorial.Equals("6"))
        {
            tut.SetActive(true);
        }
        else
        {
            tut.SetActive(false);
        }
        for (int x = 0; x < 25; x++)
        {
            if (Int32.Parse(variables_indestructibles.Personajes[x, 2]) > 0)
            {
                slots[x].SetActive(true);
                Prev[x].sprite = Resources.Load<Sprite>(variables_indestructibles.Personajes[x, 0]);
                Name[x].text = variables_indestructibles.Personajes[x, 0];
                Cant[x].text = variables_indestructibles.Personajes[x, 2];
            }
            if (Int32.Parse(variables_indestructibles.Personajes[x, 2]) < 1)
            {
                slots[x].SetActive(false);
            }
        }
    }

    public void Train()
    {
        MessConf.SetActive(false);
        if (Int32.Parse(variables_indestructibles.monedas[0]) >= costcoin && Int32.Parse(variables_indestructibles.bismuto) >= costbi)
        {
            ConfPanel.SetActive(false);
            variables_indestructibles.monedas[0] = (Int32.Parse(variables_indestructibles.monedas[0]) - costcoin).ToString();
            variables_indestructibles.bismuto = (Int32.Parse(variables_indestructibles.bismuto) - costbi).ToString();
            variables_indestructibles.Personajes[selectedId, 6] = (Int32.Parse(variables_indestructibles.Personajes[selectedId, 6]) + 1).ToString();
            arcEnt.guardar_variables();
        }
        else
        {
            notEnought.SetActive(true);
        }
    }

    public void ShowPanelEnt(int id)
    {
        arcEnt.cargar_variables();
        selectedId = id;
        for (int i = 0; i < 3; i++)
        {
            if (variables_indestructibles.Personajes[id, 1].Equals(levelChar[i]))
            {
                switch (Int32.Parse(variables_indestructibles.Personajes[id, 6]))
                {
                    case 0:
                        switch (levelChar[i])
                        {
                            case "easy":
                                costcoin = 1000;
                                costbi = 0;
                                break;
                            case "Complex":
                                costcoin = 50000;
                                costbi = 0;
                                break;
                            case "Hard":
                                costcoin = 12500;
                                costbi = 15;
                                break;
                        }
                        break;
                    case 1:
                        switch (levelChar[i])
                        {
                            case "easy":
                                costcoin = 10000;
                                costbi = 0;
                                break;
                            case "Complex":
                                costcoin = 80000;
                                costbi = 0;
                                break;
                            case "Hard":
                                costcoin = 200000;
                                costbi = 30;
                                break;
                        }
                        break;
                    case 2:
                        switch (levelChar[i])
                        {
                            case "easy":
                                costcoin = 15000;
                                costbi = 0;
                                break;
                            case "Complex":
                                costcoin = 100000;
                                costbi = 10;
                                break;
                            case "Hard":
                                costcoin = 400000;
                                costbi = 45;
                                break;
                        }
                        break;
                    case 3:
                        switch (levelChar[i])
                        {
                            case "easy":
                                costcoin = 30000;
                                costbi = 0;
                                break;
                            case "Complex":
                                costcoin = 120000;
                                costbi = 20;
                                break;
                            case "Hard":
                                costcoin = 500000;
                                costbi = 60;
                                break;
                        }
                        break;
                }
            }
        }
        cost.text = costcoin.ToString() + " monedas, " + costbi.ToString() + " Bismutos";
        if (Int32.Parse(variables_indestructibles.Personajes[id, 6]) > 3)
        {
            cost.text = "--";
            warning.SetActive(true);
            btnConfirm.SetActive(false);
        }
        if (Int32.Parse(variables_indestructibles.Personajes[id, 6]) < 4)
        {
            warning.SetActive(false);
            btnConfirm.SetActive(true);
        }
        struc.sprite = Formula[id];
        ImgChar.sprite = Resources.Load<Sprite>(variables_indestructibles.Personajes[id, 0]);
        Nameform.text = variables_indestructibles.Personajes[id, 4];
        Prevform.sprite = Formula[id];
        NameChar.text = variables_indestructibles.Personajes[id, 0];
        NoTrain.text = variables_indestructibles.Personajes[id, 6];
        ConfPanel.SetActive(true);
    }

    public void Back()
    {
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }

}
