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
    String[,] Personajes = new String[25, 8];
    String[,] Elementos = new String[25, 5];
    Archivos archivo_CE;
    String bis, bis1, cel;
    int startTime;
    String moneda,titulo_panel;
    public GameObject panel_confirmar, cerrar_panelC;
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
    public void reload()
    {
        archivo_CE = GameObject.Find("Tienda").GetComponent<Archivos>();
        archivo_CE.cargar_variables();
        archivo_CE.Cargar_Tienda(Personajes, Elementos);
        bis = archivo_CE.carga_bismuto(bis1);
        UITexto = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
        UITexto.text = bis;
        UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
        UITexto.text = archivo_CE.carga_monedas(moneda);
        moneda = UITexto.text;
    }
    public void cerrar_paneldeC()
    {
        panel_confirmar.SetActive(false);
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
        cel = "1";
        general(cel);
    }
    public void celda1()
    {
        cel = "2";
        general(cel);
    }
    public void celda2()
    {
        cel = "3";
        general(cel);
    }
    public void celda3()
    {
        cel = "4";
        general(cel);
    }
    public void celda4()
    {
        cel = "5";
        general(cel);
    }
    public void celda5()
    {
        cel = "6";
        general(cel);
    }
    public void celda6()
    {
        cel = "7";
        general(cel);
    }
    public void celda7()
    {
        cel = "8";
        general(cel);
    }
    public void celda8()
    {
        cel = "9";
        general(cel);
    }
    public void celda9()
    {
        cel = "10";
        general(cel);
    }
    public void celda10()
    {
        cel = "11";
        general(cel);
    }
    public void celda11()
    {
        cel = "12";
        general(cel);
    }
    public void celda12()
    {
        cel = "13";
        general(cel);
    }
    public void celda13()
    {
        cel = "14";
        general(cel);
    }
    public void celda14()
    {
        cel = "15";
        general(cel);
    }
    public void celda15()
    {
        cel = "16";
        general(cel);
    }
    public void celda16()
    {
        cel = "17";
        general(cel);
    }
    public void celda17()
    {
        cel = "18";
        general(cel);
    }
    public void celda18()
    {
        cel = "19";
        general(cel);
    }
    public void celda19()
    {
        cel = "20";
        general(cel);
    }
    public void celda20()
    {
        cel = "21";
        general(cel);
    }
    public void celda21()
    {
        cel = "22";
        general(cel);
    }
    public void celda22()
    {
        cel = "23";
        general(cel);
    }
    public void celda23()
    {
        cel = "24";
        general(cel);
    }
    public void celda24()
    {
        cel = "25";
        general(cel);
    }
    public void entrenar()
    {
        int usuario_monedas = Int32.Parse(moneda);
        int usuario_bismuto, precio_entrenamiento_bis, usuario_bismuto_restante;
        usuario_bismuto = Int32.Parse(bis);
        usuario_bismuto_restante = usuario_bismuto;
         UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
        int precio_entrenamiento = Int32.Parse(UITexto.text);
        int usuario_monedas_restantes=usuario_monedas - precio_entrenamiento,indicador=0;
        titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
        for (int i = 0; i < 25; i++)
        {
            if (titulotext.text.Equals(Personajes[i, 0]))
            {
                indicador = i;
                Debug.Log("indicador " + indicador.ToString());
                UITexto = GameObject.Find("lblnoentrenamiento").GetComponentInChildren<Text>();
                UITexto.text = Personajes[i, 6];
                if (Personajes[i, 1].Equals("easy"))
                {
                }
                if (Personajes[i, 1].Equals("Complex"))
                {
                    if (UITexto.text.Equals("3"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 10;
                        usuario_bismuto_restante = usuario_bismuto-precio_entrenamiento_bis;
                    }
                    else if (UITexto.text.Equals("4"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 20;
                        usuario_bismuto_restante = usuario_bismuto - precio_entrenamiento_bis;
                    }
                }
                if (Personajes[i, 1].Equals("Hard"))
                {
                    if (UITexto.text.Equals("1"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 15;
                        usuario_bismuto_restante = usuario_bismuto - precio_entrenamiento_bis;
                    }
                    else if (UITexto.text.Equals("2"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 30;
                        usuario_bismuto_restante = usuario_bismuto - precio_entrenamiento_bis;
                    }
                    else if (UITexto.text.Equals("3"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 45;
                        usuario_bismuto_restante = usuario_bismuto - precio_entrenamiento_bis;
                    }
                    else if (UITexto.text.Equals("4"))
                    {
                        usuario_bismuto = Int32.Parse(bis);
                        precio_entrenamiento_bis = 60;
                        usuario_bismuto_restante = usuario_bismuto - precio_entrenamiento_bis;
                    }
                }
            }
        }
        if (usuario_monedas_restantes >= 0 && usuario_bismuto_restante >= 0)
        {
            bis = usuario_bismuto_restante.ToString();
            titulotext = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
            titulotext.text = bis;
            variables_indestructibles.bismuto = bis;
            moneda = usuario_monedas_restantes.ToString();
            titulotext = GameObject.Find("cantidad").GetComponentInChildren<Text>();
            titulotext.text = moneda;
            variables_indestructibles.monedas[0] = moneda;
            titulotext = GameObject.Find("lblnoentrenamiento").GetComponentInChildren<Text>();
            int no_entrenamiento = Int32.Parse(titulotext.text);
            no_entrenamiento = no_entrenamiento + 1;
            titulotext.text = no_entrenamiento.ToString();
            Personajes[indicador, 6] = titulotext.text;
            variables_indestructibles.Personajes[indicador, 6] = Personajes[indicador,6];
            Debug.Log(variables_indestructibles.Personajes[indicador, 6]);
            archivo_CE.guardar_variables();
            reload();
            panel_confirmar.SetActive(false);
        }
        else
        {
        }
    }
    public void general(String num_cel)
    {
        UITexto = GameObject.Find("txtcompuesto"+num_cel).GetComponentInChildren<Text>();
        UIImage = GameObject.Find("imgcomp"+num_cel).GetComponentInChildren<Image>();
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
                    if (Personajes[i, 1].Equals("easy"))
                    {
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
                    if (Personajes[i, 1].Equals("Complex"))
                    {
                        if (UITexto.text.Equals("1"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "50000";
                        }
                        else if (UITexto.text.Equals("2"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "80000";
                        }
                        else if (UITexto.text.Equals("3"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "100000 10Bi";
                        }
                        else if (UITexto.text.Equals("4"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "120000 20Bi";
                        }
                    }
                    if (Personajes[i, 1].Equals("Hard"))
                    {
                        if (UITexto.text.Equals("1"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "125000 15Bi";
                        }
                        else if (UITexto.text.Equals("2"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "200000 30Bi";
                        }
                        else if (UITexto.text.Equals("3"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "400000 45Bi";
                        }
                        else if (UITexto.text.Equals("4"))
                        {
                            UITexto = GameObject.Find("lbl_precio").GetComponentInChildren<Text>();
                            UITexto.text = "500000 60Bi";
                        }
                    }
                }
            }
        }
    }
}
