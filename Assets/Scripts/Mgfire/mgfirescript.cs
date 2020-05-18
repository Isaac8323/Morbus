using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;

public class mgfirescript : MonoBehaviour
{
    float[] time = new float [6];
    int[] fuegos_activados = new int[6];
    int[] banders = new int[6];
    public GameObject extintor, fuego1, fuego2, fuego3, fuego4, fuego5, fuego6, LoadPanel;
    Archivos a;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("EnLlamas").GetComponent<Archivos>();
        a.cargar_variables();
        time[0] = 3.0f;
        time[1] = 3.0f;
        time[2] = 3.0f;
        time[3] = 3.0f;
        time[4] = 3.0f;
        time[5] = 3.0f;
        banders[0] = 1;
        banders[1] = 1;
        banders[2] = 1;
        banders[3] = 1;
        banders[4] = 1;
        banders[5] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(banders[0]==0 && banders[1] == 0 && banders[2] == 0 && banders[3] == 0 && banders[4] == 0 && banders[5] == 0)
        {
            variables_indestructibles.mantenimient = "0";
            a.guardar_variables();
            LoadScene.sceneToLoad = "Laboratorio";
            LoadPanel.SetActive(true);
        }
        if (!Input.GetMouseButton(0))
        {
            Debug.Log("no click");
            fuegos_activados[0] = 0;
            fuegos_activados[1] = 0;
            fuegos_activados[2] = 0;
            fuegos_activados[3] = 0;
            fuegos_activados[4] = 0;
            fuegos_activados[5] = 0;
        }
        else
        {
            if (fuegos_activados[0] == 1)
            {
                if (time[0] >= 0)
                {
                    time[0] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 1 apagado");
                    banders[0] = 0;
                    fuego1.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[1] == 1)
            {
                if (time[1] >= 0)
                {
                    time[1] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 2 apagado");
                    banders[1] = 0;
                    fuego2.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[2] == 1)
            {
                if (time[2] >= 0)
                {
                    time[2] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 3 apagado");
                    banders[2] = 0;
                    fuego3.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[3] == 1)
            {
                if (time[3] >= 0)
                {
                    time[3] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 4 apagado");
                    banders[3] = 0;
                    fuego4.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[4] == 1)
            {
                if (time[4] >= 0)
                {
                    time[4] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 5 apagado");
                    banders[4] = 0;
                    fuego5.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[5] == 1)
            {
                if (time[5] >= 0)
                {
                    time[5] -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("fuego 6 apagado");
                    banders[5] = 0;
                    fuego6.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
        }
        extintor.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
    }
    public void OnMouseDown()
    {
        Debug.Log("1");
    }
    public void f1()
    {
        fuegos_activados[0] = 1;
        Debug.Log("1");
    }
    public void f2()
    {
        fuegos_activados[1] = 1;
    }
    public void f3()
    {
        fuegos_activados[2] = 1;
    }
    public void f4()
    {
        fuegos_activados[3] = 1;
    }
    public void f5()
    {
        fuegos_activados[4] = 1;
    }
    public void f6()
    {
        fuegos_activados[5] = 1;
    }
}

