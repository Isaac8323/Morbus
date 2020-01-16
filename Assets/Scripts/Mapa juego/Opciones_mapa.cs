using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Threading;
public class Opciones_mapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Archivos archivo_mapa = GameObject.Find("Mapa_juego").GetComponent<Archivos>();
        archivo_mapa.cargar_variables();
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
        SceneManager.LoadScene("Santuario");
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
