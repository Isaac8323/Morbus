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
    public GameObject LoadPanel, organismo, tutorial, tienda, gym, lab, almacen, santuario, exit;
    String[,] Personajes = new String[25, 8];
    String[,] Elementos = new String[11, 5];
    Text textin;
    void Start()
    {
        textin = GameObject.Find("Place").GetComponentInChildren<Text>();
        Archivos archivo_mapa = GameObject.Find("Mapa_juego").GetComponent<Archivos>();
        /*archivo_mapa.Borrar();
        archivo_mapa.Crear();*/
        archivo_mapa.cargar_variables();
        archivo_mapa.Cargar_Tienda(Personajes, Elementos);
        Debug.Log("entre");
        Debug.Log(Personajes[0, 6]);
    }

    void Update()
    {
        
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
        LoadScene.sceneToLoad = "Santuario_";
        LoadPanel.SetActive(true);
    }
    public void OverSantuario()
    {
        textin.text = "Santuario";
        santuario.SetActive(true);
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
        LoadScene.sceneToLoad = "CentroEntrenamiento";
        LoadPanel.SetActive(true);
    }
    public void OverCentro()
    {
        textin.text = "Centro de entrenamiento";
        gym.SetActive(true);
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
