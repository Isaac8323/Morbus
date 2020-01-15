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
    public GameObject paneldescrip,compra,desbloquear, tienda,cuadro_imagen, intercambiopanel;
    Image UIImage,Imagepanel;
    Text UITexto, titulotext;
    String[,] Personajes = new String[25, 6];
    String[,] Elementos= new String[25, 5];
    String[,] Personajes_que_tengo = new String[25,2];
    String leve,lv;
    String  moneda;
    int pestañas = 0,nivel=0;
    // Start is called before the first frame update
    void Start()
    {
        Archivos archivo_tienda = GameObject.Find("Tienda").GetComponent<Archivos>();
        archivo_tienda.Borrar();
        archivo_tienda.Crear();
        archivo_tienda.Cargar_Tienda(Personajes, Elementos);
        UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
        UITexto.text = archivo_tienda.carga_monedas(moneda);
        moneda = UITexto.text;
        String leve = archivo_tienda.carga_level(lv);
        nivel = Int32.Parse(leve);
        personajes();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void cerrarpanel()
    {
        try
        {
            desbloquear.SetActive(true);
            UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
            UITexto.text = null;
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = null;
            compra.SetActive(false);
            desbloquear.SetActive(false);
            paneldescrip.SetActive(false);
        }
        catch (Exception e)
        {

        }
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

    public void closeIntercambio()
    {
        intercambiopanel.gameObject.SetActive(false);
    }

    public void intercambio()
    {
        intercambiopanel.gameObject.SetActive(true);
        /*
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
                 
        pestañas = 3;*/
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

    public void comprar()
    {        
        int objeto_comprar, dinero_actual;
        String tit;
        UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
        if (UITexto.text.Equals("Comprar"))
        {
            UITexto = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            objeto_comprar = Int32.Parse(UITexto.text);
            UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
            dinero_actual = Int32.Parse(UITexto.text);
            if ((dinero_actual- objeto_comprar) >= 0)
            {
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                tit = titulotext.text;
                Debug.Log(tit);
                for (int i = 0; i < 11; i++)
                {
                    if (tit.Equals(Elementos[i,0]))
                    {
                        int suma_de_cura;
                       suma_de_cura = Int32.Parse(Elementos[i, 1]);
                        suma_de_cura = suma_de_cura + 1;
                        Elementos[i, 1] = suma_de_cura.ToString();
                        Debug.Log("entre elementos");
                        Debug.Log(Elementos[i, 1]);
                        i = 11;
                    }
                }
                for (int i = 0; i < 25; i++)
                {
                    if (tit.Equals(Personajes[i,0]))
                    {
                        int suma_de_cura;
                        suma_de_cura=Int32.Parse(Personajes[i,2]);
                        suma_de_cura = suma_de_cura+1;
                        Personajes[i,2]= suma_de_cura.ToString();
                        Debug.Log("entre curas");
                        Debug.Log(Personajes[i, 2]);
                        i = 25;
                    }
                }
                dinero_actual = dinero_actual - objeto_comprar;
                UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                UITexto.text = dinero_actual.ToString();
            }
        }
        else if (UITexto.text.Equals("Intercambiar"))
        {
        }
    }
    public void celda0()
    {
        if (pestañas == 1)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Comprar";
            UIImage = GameObject.Find("Image0").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
        if (pestañas == 2)
        {
            if (nivel > 0)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 1";
                UITexto = GameObject.Find("Elemento0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            /*
            UIImage = GameObject.Find("Image0").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text0").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;*/
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text="Intercambiar";
        }
    }
    public void celda1()
    {
        if (pestañas == 1)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Comprar";
            UIImage = GameObject.Find("Image1").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
        if (pestañas == 2)
        {
            if (nivel > 0)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
     
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 1";
                UITexto = GameObject.Find("Elemento1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image1").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda2()
    {
        if (pestañas == 1)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Comprar";
            UIImage = GameObject.Find("Image2").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
         
        }
        if (pestañas == 2)
        {
            if (nivel > 0)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 1";
                UITexto = GameObject.Find("Elemento2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image2").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda3()
    {

        if (pestañas == 1)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Comprar";
            UIImage = GameObject.Find("Image3").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
        if (pestañas == 2)
        {
            if (nivel > 0)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 1";
                UITexto = GameObject.Find("Elemento3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image3").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda4()
    {
        if (pestañas == 2)
        {
            if (nivel > 0)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 1";
                UITexto = GameObject.Find("Elemento4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text4").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image4").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda5()
    {

        if (pestañas == 2)
        {
            if (nivel > 5)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 6";
                UITexto = GameObject.Find("Elemento5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text5").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image5").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda6()
    {

        if (pestañas == 2)
        {
            if (nivel > 5)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;

            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 6";
                UITexto = GameObject.Find("Elemento6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text6").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image6").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre6").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text6").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda7()
    {


        if (pestañas == 2)
        {
            if (nivel > 5)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 6";
                UITexto = GameObject.Find("Elemento7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text7").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image7").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre7").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text7").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda8()
    {

        if (pestañas == 2)
        {
            if (nivel > 5)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 6";
                UITexto = GameObject.Find("Elemento8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text8").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image8").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre8").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text8").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda9()
    {

        if (pestañas == 2)
        {
            if (nivel > 7)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 8";
                UITexto = GameObject.Find("Elemento9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text9").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image9").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre9").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text9").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda10()
    {

        if (pestañas == 2)
        {
            if (nivel > 7)
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                compra.SetActive(true);
                UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
                UITexto.text = "Comprar";
                UITexto = GameObject.Find("Elemento10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
            else
            {
                paneldescrip.SetActive(true);
                limpiar_panel();
                desbloquear.SetActive(true);
                UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
                UITexto.text = "Desbloqueable a partir del nivel 8";
                UITexto = GameObject.Find("Elemento10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("fototext").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Nombre10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
                UITexto = GameObject.Find("Text10").GetComponentInChildren<Text>();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text = UITexto.text;
            }
        }
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image10").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre10").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text10").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda11()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image11").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre11").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text11").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda12()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image12").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre12").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text12").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda13()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image13").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre13").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text13").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda14()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image14").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre14").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text14").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda15()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image15").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre15").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text15").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda16()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image16").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre16").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text16").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda17()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image17").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre17").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text17").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda18()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image18").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre18").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text18").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda19()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image19").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre19").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text19").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda20()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image20").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre20").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text20").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda21()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image21").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre21").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text21").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda22()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image22").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre22").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text22").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda23()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image23").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre23").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text23").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
    public void celda24()
    {
        if (pestañas == 3)
        {
            paneldescrip.SetActive(true);
            limpiar_panel();
            compra.SetActive(true);
            UIImage = GameObject.Find("Image24").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("Nombre24").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("Text24").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text ;
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = "Intercambiar";
        }
    }
}
