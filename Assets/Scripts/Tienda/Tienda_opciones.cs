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
public class Tienda_opciones : MonoBehaviour
{
    Image UIImage;
    Text UITexto;
    String[,] Personajes = new String[25, 6];
    String[,] Elementos= new String[25, 5];
    String level,monedas;

    // Start is called before the first frame update
    void Start()
    {
        Archivos archivo_tienda = GameObject.Find("Tienda").GetComponent<Archivos>();
        archivo_tienda.Borrar();
        archivo_tienda.Crear();
        archivo_tienda.Cargar_Tienda(level,monedas,Personajes,Elementos);
        personajes();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void personajes()
    {
                UIImage = GameObject.Find("Image0").GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("aspirina");
                UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
                UITexto.text = "Aspirina";
                UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
                UITexto.text = Personajes[0,5];

                UIImage = GameObject.Find("Image1" ).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("paracetamol");
                UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
                UITexto.text = "Paracetamol";
                UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
                UITexto.text = Personajes[1, 5];

                UIImage = GameObject.Find("Image2" ).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("penicilina");
                UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
                UITexto.text = "Penicilina";
                UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
                UITexto.text = Personajes[2, 5];

                UIImage = GameObject.Find("Image3").GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("ibuprofeno");
                UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
                UITexto.text = "Ibuprofeno";
                UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
                UITexto.text = Personajes[3, 5];
    }
    public void elementos()
    {
    }
    public void intercambio()
    {

    }
}
