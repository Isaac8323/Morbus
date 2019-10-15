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
    public void Salir()
    {
        Application.Quit();
    }
}
