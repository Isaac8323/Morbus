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
public class Botones_almacen : MonoBehaviour
{
    public GameObject errorPersonaje;
   //Externo bd o archivo {
    public MySqlConnection conn1;
    public Text botontexto;
    BinaryFormatter fb;
    FileStream Informacion;
    DatosdeJuego Datos;
    //}
    //gameobject del buscador y recursos del buscador{
    public InputField serch;
    public GameObject pan;
    GameObject whiteboton;
    String Usuario, buscador_perso;
    String[,] Personajes = new String[25, 5];
    String[] non = new String[6];
    //}
    //filtros{
    Image UIImage;
    Text cantidad,nombre;
  public  GameObject panelcoleccion;
    int panelcolcc=0;
    //}
    //coleccion{
    int pos=0;
//}
    //descripciones{
    public GameObject paneldescrip;
    String[,] verificadores = new String[25,3];
//}
    void Start()
    {
        //     AdminMYSQL adminmysql = GameObject.Find("Almacen").GetComponent<AdminMYSQL>();
        //    conn1 = adminmysql.ConectarConServidorBaseDatos();
        Archivos archivo_almacen= GameObject.Find("Almacen").GetComponent<Archivos>();
        archivo_almacen.Cargar_Almacen(Usuario,Personajes);
        personajes();
    }
    void Update()
    {

    }
    //Autocompletado:
    public void boton1()
    {
        serch.text = non[0];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void boton2()
    {

        serch.text = non[1];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void boton3()
    {

        serch.text = non[2];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void boton4()
    {

        serch.text = non[3];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void boton5()
    {

        serch.text = non[4];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void boton6()
    {

        serch.text = non[5];
        pan.SetActive(false);
        buscador_personaje();
    }
    public void buscador()
    {
        string busc = serch.text;
        int contadorboron = 1, contador = 1;
        if (busc == "")
        {
            pan.SetActive(false);
        }
        else
        {
            errorPersonaje.SetActive(false);
            pan.SetActive(true);
            for (; contadorboron <= 6; contadorboron++)
            {

                whiteboton = GameObject.Find("" + contadorboron.ToString()); 
                if (whiteboton != null)
                {
                    non[contadorboron - 1] = "";
                    whiteboton.GetComponentInChildren<Text>().text = "";

                }
            }
            for (int i = 0; i < 25; i++)
            {
                if (busc.Length > Personajes[i, 0].Length)
                {
                }
                else
                {
                    int longitud = busc.Length;
                    if (Personajes[i, 0].Substring(0, longitud).Equals(busc))
                    {
                        whiteboton = GameObject.Find("" + contador.ToString());

                        Debug.Log(Personajes[i, 0]);
                        String YACARAJO = Personajes[i, 0];
                        whiteboton.GetComponentInChildren<Text>().text = YACARAJO;
                        non[contador - 1] = YACARAJO;
                        contador++;
                    }
                    
                }
            }
        
        }
    }
    public void buscador_personaje()
    {
        limpiarverificadores();
        buscador_perso = serch.text;
        int o = 0,mensj=0;
        limpiarpanelpersonajes();
        for (int i = 0; i < 25; i++)
        {
            if (buscador_perso == Personajes[i, 0])
            {
                if (buscador_perso == "sulfasalazina")
                {
                    if (Personajes[i, 2] == "0")
                    {
                        UIImage = GameObject.Find("Image" + o.ToString()).GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                        cantidad = GameObject.Find("Text" + o.ToString()).GetComponentInChildren<Text>();
                        verificadores[o, 0] = Personajes[i, 0];
                        verificadores[o, 1] = Personajes[i, 3];
                        verificadores[o, 2] = Personajes[i, 0];
                        nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                        nombre.text = Personajes[i, 0];
                    }
                    else
                    {
                        UIImage = GameObject.Find("Image" + o.ToString()).GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                        cantidad = GameObject.Find("Text" + o.ToString()).GetComponentInChildren<Text>();
                        cantidad.text = Personajes[i, 2];
                        verificadores[o, 0] = Personajes[i, 0];
                        verificadores[o, 1] = Personajes[i, 3];
                        verificadores[o, 2] = Personajes[i, 0];
                        nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                        nombre.text = Personajes[i, 0];
                    }
                    if (o == 1)
                    {
                        if (Personajes[i, 2] == "0")
                        {
                            UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                            cantidad.text = Personajes[i, 2];
                            verificadores[o, 0] = Personajes[i, 0];
                            verificadores[o, 1] = Personajes[i, 3];
                            verificadores[o, 2] = Personajes[i, 0];
                            nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                            nombre.text = Personajes[i, 0];
                        }
                        else
                        {
                            UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0].ToString());
                            cantidad.text = Personajes[i, 2];
                            verificadores[o, 0] =  Personajes[i, 0];
                            verificadores[o, 1] = Personajes[i, 3];
                            verificadores[o, 2] = Personajes[i, 0];
                            nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                            nombre.text = Personajes[i, 0];
                        }
                    }
                    o++;
                }
                else
                {
                    if (Personajes[i, 2] == "0")
                    {
                        UIImage = GameObject.Find("Image" + o.ToString()).GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                        cantidad = GameObject.Find("Text" + o.ToString()).GetComponentInChildren<Text>();
                        nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                        nombre.text = Personajes[i, 0];
                        verificadores[o, 0] = Personajes[i, 0];
                        verificadores[o, 1] = Personajes[i, 3];
                        verificadores[o, 2] = Personajes[i, 0];
                    }
                    else
                    {
                        UIImage = GameObject.Find("Image" + o.ToString()).GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                        cantidad = GameObject.Find("Text" + o.ToString()).GetComponentInChildren<Text>();
                        nombre = GameObject.Find("Nombre" + o.ToString()).GetComponentInChildren<Text>();
                        nombre.text = Personajes[i, 0];
                        verificadores[o, 0] = Personajes[i, 0];
                        verificadores[o, 1] = Personajes[i, 3];
                        verificadores[o, 2] = Personajes[i, 0];
                    }
                }
                mensj++;
                cantidad.text = null;
            }
            
        }
        if(mensj<=0){
        Thread.Sleep(1000);
        errorPersonaje.SetActive(true);
        pan.SetActive(false);
    }
    }
    //
    //Personajes:
    public void limpiarverificadores()
    {
        for (int rep = 0; rep < 3; rep++)
        {
            for (int i = 0; i < 25; i++)
            {
                verificadores[i, rep] = "";
            }
        }
    }
    public void personajes()
    {
        limpiarverificadores();
        for (int i = 0; i < 25; i++)
        {
            if (i == 22)
            {
                if (Personajes[i, 2] == "0")
                {
                    UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                    nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[i, 0] =  Personajes[i, 0];
                    verificadores[i, 1] = Personajes[i, 3];
                    verificadores[i, 2] = Personajes[i, 0];
                }
                else{
                UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0].ToString());
                cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                verificadores[i, 0] = Personajes[i, 0];
                verificadores[i, 1] = Personajes[i, 3];
                verificadores[i, 2] = Personajes[i, 0];
                    }
            }
            else
            {
                if (Personajes[i, 2] == "0")
                {
                    UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                    nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[i, 0] = Personajes[i, 0];
                    verificadores[i, 1] = Personajes[i, 3];
                    verificadores[i, 2] = Personajes[i, 0];  
                }
                else
                {
                    UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                    nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[i, 0] = Personajes[i, 0];
                    verificadores[i, 1] = Personajes[i, 3];
                    verificadores[i, 2] = Personajes[i, 0];
                }
            }
            cantidad.text = null;
        }
        
    }
    //
    public void limpiarpanelpersonajes()
    {
        for (int i = 0; i < 25; i++)
        {
            UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(null);
            cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
            nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
            nombre.text = null;
            cantidad.text = null;
        }
    }
    //filtro;
    public void filtropan()
    {
        if (panelcolcc == 1)
        {
            panelcoleccion.SetActive(false);
            panelcolcc = 0;
        }
        else
        {
            panelcoleccion.SetActive(true);
            panelcolcc = 1;
        }
    }
    public void filtroeasy()
    {
        limpiarpanelpersonajes();
        limpiarverificadores();
        for (int i = 0; i < 7; i++)
        {
            if (Personajes[i, 2] == "0")
            {
                UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                nombre.text = Personajes[i, 0];
                verificadores[i, 0] = Personajes[i, 0];
                verificadores[i, 1] = Personajes[i, 3];
                verificadores[i, 2] = Personajes[i, 0];
            }
            else
            {
                UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
                cantidad.text = Personajes[i, 2];
                nombre = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
                nombre.text = Personajes[i, 0];
                verificadores[i, 0] = Personajes[i, 0];
                verificadores[i, 1] = Personajes[i, 3];
                verificadores[i, 2] = Personajes[i, 0];
            }
            cantidad.text = null;
        }
        panelcoleccion.SetActive(false);
        panelcolcc = 0;
    }
    public void filtrocomplex()
    {
        limpiarpanelpersonajes();
        limpiarverificadores();
        int position = 0;
        for (int i = 7; i < 20; i++)
        {
            if (Personajes[i, 2] == "0")
            {
                UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                nombre.text = Personajes[i, 0];
                verificadores[position, 0] = Personajes[i, 0];
                verificadores[position, 1] = Personajes[i, 3];
                verificadores[position, 2] = Personajes[i, 0];
               
            }
            else
            {
                UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                cantidad.text = Personajes[i, 2];
                nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                nombre.text = Personajes[i, 0];
                verificadores[position, 0] = Personajes[i, 0];
                verificadores[position, 1] = Personajes[i, 3];
                verificadores[position, 2] = Personajes[i, 0];
            }
            position++;
            cantidad.text = null;
        }
        panelcoleccion.SetActive(false);
        panelcolcc = 0;
    }
    public void filtrohard()
    {
        limpiarpanelpersonajes();
        limpiarverificadores();
        int position = 0;
        for (int i = 20; i < 25; i++)
        {
            if(i==22){
                if (Personajes[i, 2] == "0")
                {
                    UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                    nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[position, 0] = Personajes[i, 0];
                    verificadores[position, 1] = Personajes[i, 3];
                    verificadores[position, 2] = Personajes[i, 0];
                }
                else
                {
                    UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>( Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                    cantidad.text = Personajes[i, 2];
                    nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[position, 0] =  Personajes[i, 0];
                    verificadores[position, 1] = Personajes[i, 3];
                    verificadores[position, 2] = Personajes[i, 0];
                }
            }
            else{
                if (Personajes[i, 2] == "0")
                {
                    UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("g" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                    nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[position, 0] = Personajes[i, 0];
                    verificadores[position, 1] = Personajes[i, 3];
                    verificadores[position, 2] = Personajes[i, 0];
                }
                else
                {
                    UIImage = GameObject.Find("Image" + position.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + position.ToString()).GetComponentInChildren<Text>();
                    cantidad.text = Personajes[i, 2];
                    nombre = GameObject.Find("Nombre" + position.ToString()).GetComponentInChildren<Text>();
                    nombre.text = Personajes[i, 0];
                    verificadores[position, 0] = Personajes[i, 0];
                    verificadores[position, 1] = Personajes[i, 3];
                    verificadores[position, 2] = Personajes[i, 0];
                }
            }
            position++;
            cantidad.text = null;
        }
        panelcoleccion.SetActive(false);
        panelcolcc = 0;
    }
    //
    //Coleccion:
    public void coleccion()
    {
        pos = 0;
        limpiarpanelpersonajes();
        limpiarverificadores();
        for (int i = 0; i < 25; i++)
        {
            cantidad = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
            if (Personajes[i, 2] != "0")
            {
                if (i == 22)
                {
                    UIImage = GameObject.Find("Image" + pos.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>( Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + pos.ToString()).GetComponentInChildren<Text>();
                    cantidad.text = Personajes[i, 2];
                    verificadores[pos, 0] = Personajes[i, 0];
                    verificadores[pos, 1] = Personajes[i, 3];
                    verificadores[pos, 2] = Personajes[i, 0];
                }
                else
                {
                    UIImage = GameObject.Find("Image" + pos.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>("" + Personajes[i, 0].ToString());
                    cantidad = GameObject.Find("Text" + pos.ToString()).GetComponentInChildren<Text>();
                    cantidad.text = Personajes[i, 2];
                    verificadores[pos, 0] = Personajes[i, 0];
                    verificadores[pos, 1] = Personajes[i, 3];
                    verificadores[pos, 2] = Personajes[i, 0];
                }
                nombre = GameObject.Find("Nombre" + pos.ToString()).GetComponentInChildren<Text>();
                nombre.text = Personajes[i, 0];
                pos++;
            }
        }
    }
    //
    //onclickceldas
    public void celda0() {
        paneldescrip.SetActive(true);
        if (verificadores[0, 0] == "")
        {
        }
        else
        {
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[0, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[0, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[0, 2];
        }
    }
    public void cerrarpanel()
    {
        paneldescrip.SetActive(false);
    }
    public void celda1()
    {
        if (verificadores[1, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[1, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[1, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[1, 2];
        }
    }
    public void celda2()
    {
        if (verificadores[2, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[2, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[2, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[2, 2];
        }
    }
    public void celda3()
    {
        if (verificadores[3, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[3, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[3, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[3, 2];
        }
    }
    public void celda4()
    {
        if (verificadores[4, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[4, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[4, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[4, 2];
        }
    }
    public void celda5()
    {
        if (verificadores[5, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[5, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[5, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[5, 2];
        }
    }
    public void celda6()
    {
        if (verificadores[6, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[6, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[6, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[6, 2];
        }
    }
    public void celda7()
    {
        if (verificadores[7, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[7, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[7, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[7, 2];
        }
    }
    public void celda8()
    {
        if (verificadores[8, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[8, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[8, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[8, 2];
        }
    }
    public void celda9()
    {
        if (verificadores[9, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[9, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[9, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[9, 2];
        }
    }
    public void celda10()
    {
        if (verificadores[10, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[10, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[10, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[10, 2];
        }
    }
    public void celda11()
    {
        if (verificadores[11, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[11, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[11, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[11, 2];
        }
    }
    public void celda12()
    {
        if (verificadores[12, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[12, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[12, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[12, 2];
        }
    }
    public void celda13()
    {
        if (verificadores[13, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[13, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[13, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[13, 2];
        }
    }
    public void celda14()
    {
        if (verificadores[14, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[14, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[14, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[14, 2];
        }
    }
    public void celda15()
    {
        if (verificadores[15, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[15, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[15, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[15, 2];
        }
    }
    public void celda16()
    {
        if (verificadores[16, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[16, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[16, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[16, 2];
        }
    }
    public void celda17()
    {
        if (verificadores[17, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[17, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[17, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[17, 2];
        }
    }
    public void celda18()
    {
        if (verificadores[18, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[18, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[18, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[18, 2];
        }
    }
    public void celda19()
    {
        if (verificadores[19, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[19, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[19, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[19, 2];
        }
    }
    public void celda20()
    {
        if (verificadores[20, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[20, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[20, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[20, 2];
        }
    }
    public void celda21()
    {
        if (verificadores[21, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[21, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[21, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[21, 2];
        }
    }
    public void celda22()
    {
        if (verificadores[22, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[22, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[22, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[22, 2];
        }
    }
    public void celda23()
    {
        if (verificadores[23, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[23, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[23, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[23, 2];
        }
    }
    public void celda24()
    {
        if (verificadores[24, 0] == "")
        {
        }
        else
        {
            paneldescrip.SetActive(true);
            UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(verificadores[24, 0]);
            cantidad = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            cantidad.text = verificadores[24, 1];
            cantidad = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            cantidad.text = verificadores[24, 2];
        }
    }
    //
    public void mapainicial()
    {
        SceneManager.LoadScene("Mapajuego");
    }
}
  
