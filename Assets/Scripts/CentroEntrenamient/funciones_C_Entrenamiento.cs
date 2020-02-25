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
    Image UIImage, Imagepanel;
    Text UITexto, titulotext;
    String[,] Personajes = new String[25, 7];
    String[,] Elementos = new String[25, 5];
    Archivos archivo_CE;
    String bis, bis1;
    int startTime;
    String moneda,titulo_panel;
    public GameObject panel_confirmar;
    // Start is called before the first frame update
    void Start()
    {
        archivo_CE = GameObject.Find("Tienda").GetComponent<Archivos>();
  
        archivo_CE.Cargar_Tienda(Personajes, Elementos);
        bis = archivo_CE.carga_bismuto(bis1);
        UITexto = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
        UITexto.text = bis;
        UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
        UITexto.text = archivo_CE.carga_monedas(moneda);
        moneda = UITexto.text;
        cargar_personajes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cargar_personajes()
    {
        int x = 1;
        for (int i = 0; i < 25; i++)
        {
            if (!Personajes[i, 2].Equals("0"))
            {
                UIImage = GameObject.Find("imgcomp" + x.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0]);
                UITexto = GameObject.Find("txtcompuesto" + x.ToString()).GetComponentInChildren<Text>();
                UITexto.text = Personajes[i, 0];
                x++;
            } 
        }
    }
    public void mapa()
    {
        SceneManager.LoadScene("Mapajuego");
    }
    public void celda0()
    {
        UITexto = GameObject.Find("txtcompuesto1").GetComponentInChildren<Text>();
        UIImage = GameObject.Find("imgcomp1").GetComponentInChildren<Image>();
        if (!UITexto.text.Equals(""))
        {
            panel_confirmar.SetActive(true);
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            for (int i = 0; i < 25; i++)
            {
                if (titulotext.text.Equals(Personajes[i, 0]))
                {
                    UITexto = GameObject.Find("lblnoentrenamiento").GetComponentInChildren<Text>();
                    UITexto.text = Personajes[i, 6];
                    if (UITexto.text.Equals("1"))
                    {
                        UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                        UITexto.text = "1000";
                    }
                    else if (UITexto.text.Equals("2"))
                    {
                        UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                        UITexto.text = "10000";
                    }
                    else if (UITexto.text.Equals("3"))
                    {
                        UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                        UITexto.text = "15000";
                    }
                    else if (UITexto.text.Equals("4"))
                    {
                        UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                        UITexto.text = "30000";
                    }
                }
            }
        }
    }
}
