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
    // Start is called before the first frame update
    String[,] Personajes = new String[25, 6];
    String[,] Elementos = new String[25, 5];
    void Start()
    {
        Archivos archivo_mapa = GameObject.Find("Mapa_juego").GetComponent<Archivos>();
        archivo_mapa.cargar_variables();
        archivo_mapa.Cargar_Tienda(Personajes, Elementos);
        Debug.Log("entre");
        Debug.Log(Personajes[19, 2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Almacen()
    {
        SceneManager.LoadScene("Almacen");
    }
    public void Tutoriales()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Santuario()
    {
        SceneManager.LoadScene("Santuario_");
    }
    public void Tienda()
    {
        SceneManager.LoadScene("Tienda");
    }
    public void Laboratorio()
    {
        SceneManager.LoadScene("Laboratorio");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
