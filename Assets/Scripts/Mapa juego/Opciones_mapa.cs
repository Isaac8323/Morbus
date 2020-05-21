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

public class Opciones_mapa : MonoBehaviour
{
    public GameObject centerl, centerc, santuarl, santuarc;
    public GameObject LoadPanel, organismo, tutorial, tienda, gym, lab, almacen, santuario, exit;
    public GameObject tuto;
    private int lvl;
    String[,] Personajes = new String[25, 8];
    String[,] Elementos = new String[11, 5];
    Text textin;
    Archivos archivo_mapa;
    void Start()
    {
        textin = GameObject.Find("Place").GetComponentInChildren<Text>();
        archivo_mapa = GameObject.Find("Mapa_juego").GetComponent<Archivos>();
        /*archivo_mapa.Borrar();
        archivo_mapa.Crear();*/
        archivo_mapa.cargar_variables();
        archivo_mapa.Cargar_Tienda(Personajes, Elementos);
        Debug.Log("entre");
        Debug.Log(Personajes[0, 6]);
        if (variables_indestructibles.first.Equals("false"))
        {
            tuto.SetActive(false);
        }
        if (variables_indestructibles.first.Equals("true"))
        {
            tuto.SetActive(true);
        }
    }

    void Update()
    {
        lvl = Int32.Parse(variables_indestructibles.level[0]);
        if (lvl < 8)
        {
            centerc.SetActive(true);
            centerl.SetActive(true);
        }
        if (lvl > 7)
        {
            centerc.SetActive(false);
            centerl.SetActive(false);
        }
        if (lvl < 15)
        {
            santuarc.SetActive(true);
            santuarl.SetActive(true);
        }
        if (lvl > 14)
        {
            santuarc.SetActive(false);
            santuarl.SetActive(false);
        }
    }

    public void Organismo()
    {
        LoadScene.sceneToLoad = "Selection";
        LoadPanel.SetActive(true);
    }

    public void OverOrganismo()
    {
        textin.text = "Organismo Humano";
        organismo.SetActive(true);
    }
    public void Almacen()
    {
        LoadScene.sceneToLoad = "Almacen";
        LoadPanel.SetActive(true);
    }
    public void OverAlmacen()
    {
        textin.text = "Almacen";
        almacen.SetActive(true);
    }
    public void Tutoriales()
    {
        LoadScene.sceneToLoad = "Tutorial";
        LoadPanel.SetActive(true);
    }
    public void OverTutoriales()
    {
        textin.text = "Tutoriales";
        tutorial.SetActive(true);
    }
    public void Santuario()
    {
        if (lvl > 14)
        {
            LoadScene.sceneToLoad = "Santuario_";
            LoadPanel.SetActive(true);
        }
    }
    public void OverSantuario()
    {
        if (lvl > 14)
        {
            textin.text = "Santuario";
            santuario.SetActive(true);
        }
        if (lvl < 15)
        {
            textin.text = "Se desbloquea al nivel 15";
        }
    }
    public void Tienda()
    {
        LoadScene.sceneToLoad = "Tienda";
        LoadPanel.SetActive(true);
    }
    public void OverTienda()
    {
        textin.text = "Tienda";
        tienda.SetActive(true);
    }
    public void Laboratorio()
    {
        LoadScene.sceneToLoad = "Laboratorio";
        LoadPanel.SetActive(true);
    }
    public void OverLaboratorio()
    {
        textin.text = "Laboratorio Farmaceutico";
        lab.SetActive(true);
    }
    public void Centro()
    {
        if (lvl > 7)
        {
            LoadScene.sceneToLoad = "CentroEntrenamiento";
            LoadPanel.SetActive(true);
        }        
    }
    public void OverCentro()
    {
        if (lvl > 7)
        {
            textin.text = "Centro de entrenamiento";
            gym.SetActive(true);
        }
        if (lvl < 8)
        {
            textin.text = "Se desbloquea al nivel 8";
        }
        
    }
    public void OverExit()
    {
        textin.text = "Regresar al menu principal";
        exit.SetActive(true);
    }
    public void NoPlace()
    {
        textin.text = "";
        organismo.SetActive(false);
        almacen.SetActive(false);
        tutorial.SetActive(false);
        santuario.SetActive(false);
        tienda.SetActive(false);
        lab.SetActive(false);
        gym.SetActive(false);
        exit.SetActive(false);
    }
    public void Salir()
    {
        LoadScene.sceneToLoad = "Menu";
        LoadPanel.SetActive(true);
    }
}
