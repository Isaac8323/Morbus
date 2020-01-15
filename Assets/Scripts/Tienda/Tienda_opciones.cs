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
    public GameObject paneldescrip,compra;
    Image UIImage,Imagepanel;
    Text UITexto, titulotext;
    String[,] Personajes = new String[25, 6];
    String[,] Elementos= new String[25, 5];
    String[,] Personajes_que_tengo = new String[25,2];
    String leve;
    String  moneda;
    int pestañas = 0;
    // Start is called before the first frame update
    void Start()
    {
        Archivos archivo_tienda = GameObject.Find("Tienda").GetComponent<Archivos>();
        archivo_tienda.Borrar();
        archivo_tienda.Crear();
        archivo_tienda.Cargar_Tienda(Personajes, Elementos);
        archivo_tienda.carga_pendejo(moneda , leve );
        personajes();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void cerrarpanel()
    {
        paneldescrip.SetActive(false);
    }
    public void personajes()
    {
 
            UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
         //   UITexto.text = moneda.ToString();
            limpiarceldas();
            UIImage = GameObject.Find("Image0").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>("aspirina");
            UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
            UITexto.text = "Aspirina";
            UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
            UITexto.text = Personajes[0, 5];

            UIImage = GameObject.Find("Image1").GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>("paracetamol");
            UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
            UITexto.text = "Paracetamol";
            UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
            UITexto.text = Personajes[1, 5];

            UIImage = GameObject.Find("Image2").GetComponentInChildren<Image>();
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
            pestañas = 1;
        
    }
    public void elementos()
    {
        limpiarceldas();
        for (int i = 0; i <= 10; i++ )
        {
            UITexto = GameObject.Find("Elemento" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = Elementos[i, 4];
            UITexto = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = Elementos[i, 0];
            UITexto = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = Elementos[i, 3];
        }
        pestañas = 2;
    }
    public void limpiarceldas()
    {
        for (int i = 0; i <= 10; i++)
        {
            UITexto = GameObject.Find("Elemento" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = null;

        }
        for (int i = 0; i <= 24; i++)
        {
            UITexto = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = null;
            UITexto = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = null;
            UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
            UIImage.sprite = null;
        }
    }
    public void intercambio()
    {
        int x=0;
        limpiarceldas();
        for (int i = 0; i < 25; i++ ){
            if (!Personajes[i, 2].Equals("0"))
            {
                Personajes_que_tengo[x,0] = Personajes[i, 0];
                Personajes_que_tengo[x, 1] = Personajes[i, 1];
                x++;
            }
        }
        for (int i = 0; i < x; i++)
        {
            UIImage = GameObject.Find("Image" + i.ToString()).GetComponentInChildren<Image>();
            UIImage.sprite = Resources.Load<Sprite>(Personajes_que_tengo[i, 0].ToString()); 
            UITexto = GameObject.Find("Nombre" + i.ToString()).GetComponentInChildren<Text>();
            UITexto.text = Personajes_que_tengo[i,0];
            UITexto = GameObject.Find("Text" + i.ToString()).GetComponentInChildren<Text>();
            if (Personajes_que_tengo[i, 1].Equals("easy"))
            {
                UITexto.text = "50";
            }
            else if (Personajes_que_tengo[i, 1].Equals("Complex"))
            {
                UITexto.text = "250";
            }
            else  if (Personajes_que_tengo[i, 1].Equals("Hard"))
            {
                UITexto.text = "500 1Bi";
            }
        }
            pestañas = 3;
    }
    public void limpiar_panel()
    {
        UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
        UIImage.sprite=null;
         UITexto = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
         UITexto.text = null;
         UITexto = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
         UITexto.text = null;
         UITexto = GameObject.Find("fototext").GetComponentInChildren<Text>();
         UITexto.text = null;
    }
    public void celda0()
    {
        paneldescrip.SetActive(true);
        limpiar_panel();
        if (pestañas == 1)
        {
            UIImage = GameObject.Find("Image0").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 2)
        {
            UITexto = GameObject.Find("Elemento0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda1()
    {
        paneldescrip.SetActive(true);
        limpiar_panel();
        if (pestañas == 1)
        {
            UIImage = GameObject.Find("Image1").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 2)
        {
            UITexto = GameObject.Find("Elemento1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda2()
    {
        paneldescrip.SetActive(true);
        limpiar_panel();
        if (pestañas == 1)
        {
            UIImage = GameObject.Find("Image2").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 2)
        {
            UITexto = GameObject.Find("Elemento2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda3()
    {
        paneldescrip.SetActive(true);
        limpiar_panel();
        if (pestañas == 1)
        {
            UIImage = GameObject.Find("Image3").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 2)
        {
            UITexto = GameObject.Find("Elemento3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda4()
    {
        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda5()
    {

        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda6()
    {

        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento6").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre6").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text6").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda7()
    {


        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento7").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre7").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text7").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda8()
    {

        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento8").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre8").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text8").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda9()
    {

        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento9").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre9").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text9").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda10()
    {

        if (pestañas == 2)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            UITexto = GameObject.Find("Elemento10").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Nombre10").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text10").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            compra.SetActive(true);
        }
        if (pestañas == 3)
        {
        }
    }
    public void celda11()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda12()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda13()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda14()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda15()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda16()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda17()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda18()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda19()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda20()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda21()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda22()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda23()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
    public void celda24()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
        }
    }
}
