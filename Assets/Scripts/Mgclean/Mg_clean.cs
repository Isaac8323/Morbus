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

public class Mg_clean : MonoBehaviour
{
    int[] time = new int[6];
    int[] fuegos_activados = new int[6];
    int[] banders = new int[6];
    int presionable = 0;
    public GameObject trapido, recogedor, v1, v2, m1, m2, m3, LoadPanel, panel,felicidades;
    private Animator ext;
    bool seguidor = false, trapitotrue = false;
    Archivos a;
    // Start is called before the first frame update
    void Start()
    {
        //ext = GameObject.Find("ext").GetComponent<Animator>();
        a = GameObject.Find("Limpieza").GetComponent<Archivos>();
        a.cargar_variables();
        time[0] = 2;
        time[1] = 2;
        time[2] = 4;
        time[3] = 4;
        time[4] = 4;
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
        if (banders[0] == 0 && banders[1] == 0 && banders[2] == 0 && banders[3] == 0 && banders[4] == 0)
        {
            variables_indestructibles.mantenimient = "0";
            a.guardar_variables();
            felicidades.SetActive(true);
        }
        if (!Input.GetMouseButton(0))
        {
            fuegos_activados[0] = 0;
            fuegos_activados[1] = 0;
            fuegos_activados[2] = 0;
            fuegos_activados[3] = 0;
            fuegos_activados[4] = 0;
        }
        else
        {
            if (fuegos_activados[0] == 1)
            {
                if (time[0] >= 1)
                {
                    if (presionable == 1)
                    {
                        Debug.Log("entre");
                        presionable = 0;
                        time[0]--;
                        return;
                    }
                }
                else
                {
                    Debug.Log("vidrio 1 limpiado");
                    banders[0] = 0;
                    //    ext.SetBool("Push", false);
                    v1.SetActive(false);
                    //Do Something after clock hits 0
                }

            }
            if (fuegos_activados[1] == 1)
            {
                if (time[1] >= 1)
                {
                    if (presionable == 1)
                    {
                        presionable = 0;
                        time[1]--;
                        return;
                    }
                }
                else
                {
                    Debug.Log("vidrio 2 limpiado");
                    banders[1] = 0;
                    //    ext.SetBool("Push", false);
                    v2.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[2] == 1)
            {
                if (time[2] >= 1)
                {
                    if (presionable == 1)
                    {
                        presionable = 0;
                        time[2]--;
                        return;
                    }
                }
                else
                {
                    Debug.Log("mencha 1 limpiada");
                    banders[2] = 0;
                    //    ext.SetBool("Push", false);
                    m1.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[3] == 1)
            {
                if (time[3] >= 1)
                {
                    if (presionable == 1)
                    {
                        presionable = 0;
                        time[3]--;
                        return;
                    }
                }
                else
                {
                    Debug.Log("mencha 2 limpiada");
                    banders[3] = 0;
                    //ext.SetBool("Push", false);
                    m2.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            if (fuegos_activados[4] == 1)
            {
                if (time[4] >= 1)
                {
                    if (presionable == 1)
                    {
                        presionable = 0;
                        time[4] -= 1;
                        return;
                    }
                }
                else
                {
                    Debug.Log("mencha 3 limpiada");
                    banders[4]--;
                    //   ext.SetBool("Push", false);
                    m3.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
        }
        if (seguidor == true)
        {
            if (trapitotrue == true)
            {
                trapido.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            }
            else
            {
                recogedor.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            }
        }
    }
    public void ir_al_mapa()
    {
        felicidades.SetActive(false);
        panel.SetActive(true);
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }
    public void trapito_activo (){
        recogedor.SetActive(false);
        trapido.SetActive(true);
        trapitotrue = true;
        seguidor = true;
}
    public void recogedor_activo()
    {
        recogedor.SetActive(true);
        trapido.SetActive(false);
        trapitotrue = false;
        seguidor = true;
    }
    public void v_1()
    {
        if (trapitotrue == false)
        {
            fuegos_activados[0] = 1;
            presionable = 1;
            Debug.Log("1");
        }
    }
    public void v_2()
    {
        if (trapitotrue == false )
        {
            fuegos_activados[1] = 1;
            presionable = 1;
            Debug.Log("2");
        }
    }
    public void m_1()
    {
        if (trapitotrue == true)
        {
            fuegos_activados[2] = 1;
            presionable = 1;
            Debug.Log("3");
        }
    }
    public void m_2()
    {
        if(trapitotrue == true)
        {
            fuegos_activados[3] = 1;
            presionable = 1;
        }
    }
    public void m_3()
    {
        if(trapitotrue == true)
        {
            fuegos_activados[4] = 1;
            presionable = 1;
        }
    }
    public void controlador_pressbutton()
    {
        Debug.Log("0 todos");
        presionable = 0;
            fuegos_activados[0] = 0;
            fuegos_activados[1] = 0;
            fuegos_activados[2] = 0;
            fuegos_activados[3] = 0;
            fuegos_activados[4] = 0;
        
    }

  /*  public void startAnim()
    {
        ext.SetBool("Push", true);
    }

    public void stopAnim()
    {
        ext.SetBool("Push", false);
    }*/
}
