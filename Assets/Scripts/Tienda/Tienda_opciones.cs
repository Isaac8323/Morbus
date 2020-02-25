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
[System.Serializable]
public class Tienda_opciones : MonoBehaviour
{
    public GameObject paneldescrip,compra,desbloquear, tienda,cuadro_imagen, intercambiopanel;
    Image UIImage,Imagepanel;
    Text UITexto, titulotext;
    String[,] Personajes = new String[25, 7];
    String[,] Elementos= new String[25, 5];
    String[,] Personajes_que_tengo = new String[25,2];
    String leve,lv,nombre_intercambio;
    String  moneda;
    String bis, bis1;
    Archivos archivo_tienda;
    int pestañas = 0,nivel=0;
    // Start is called before the first frame update
    void Start()
    {
        
       archivo_tienda  = GameObject.Find("Tienda").GetComponent<Archivos>();
        archivo_tienda.Cargar_Tienda(Personajes, Elementos);
        bis = archivo_tienda.carga_bismuto(bis1);
        Debug.Log(Personajes[0, 2]);
        UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
        UITexto.text = archivo_tienda.carga_monedas(moneda);
        moneda = UITexto.text;
        UITexto = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
        UITexto.text = bis;
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
            paneldescrip.SetActive(true);
            desbloquear.SetActive(true);
            intercambiopanel.SetActive(true);
            UITexto = GameObject.Find("desbloquear").GetComponentInChildren<Text>();
            UITexto.text = null;
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            UITexto.text = null;
            UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
            UITexto.text = null;
            compra.SetActive(true);
            UITexto = GameObject.Find("compratext").GetComponentInChildren<Text>();
            UITexto.text = null;
            compra.SetActive(false);
            desbloquear.SetActive(false);
            paneldescrip.SetActive(false);
            intercambiopanel.SetActive(false);
            if (pestañas == 3)
            {
                personajes();
            }
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
         int x=0;
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
             UIImage = GameObject.Find("img" + i.ToString()).GetComponentInChildren<Image>();
             UIImage.sprite = Resources.Load<Sprite>(Personajes_que_tengo[i, 0].ToString()); 
             UITexto = GameObject.Find("nom" + i.ToString()).GetComponentInChildren<Text>();
             UITexto.text = Personajes_que_tengo[i,0];
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
    public void intercambiar()
    {
        UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
        UITexto.text = null;
        UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
        UITexto.text = null;
        for(int i=0; i<25; i++){
            if(nombre_intercambio.Equals(Personajes[i,0])){
                int cant =Int32.Parse(Personajes[i, 2]);
                int cantbi;
                cant = cant - 1;
                Personajes[i, 2] = cant.ToString();
                UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                moneda = UITexto.text;
                UITexto = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
                bis = UITexto.text;
                if(Personajes[i,1].Equals("easy")){
                    cant = Int32.Parse(moneda);
                    cant = cant + 50;
                    UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                    UITexto.text = cant.ToString();
                }
                if(Personajes[i,1].Equals("Complex")){
                    cant = Int32.Parse(moneda);
                    cant = cant + 250;
                    UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                    UITexto.text = cant.ToString();
                }
                if(Personajes[i,1].Equals("Hard")){
                    cant = Int32.Parse(moneda);
                    cant = cant + 500;
                    cantbi = Int32.Parse(bis);
                    cantbi = cantbi + 1;
                    UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                    UITexto.text = cant.ToString();
                    UITexto = GameObject.Find("cantidad_bi").GetComponentInChildren<Text>();
                    UITexto.text = cantbi.ToString();
                    variables_indestructibles.bismuto = cantbi.ToString();
                }
                variables_indestructibles.monedas[0] = cant.ToString();
                variables_indestructibles.Personajes[i, 2] = Personajes[i, 2];
                intercambio();
                archivo_tienda.guardar_variables();
            }
        }
    }
    public void Volver()
    {
        SceneManager.LoadScene("Mapajuego");
    }
    public void comprar()
    {        
        int objeto_comprar, dinero_actual;
        String titmin,titmax;
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
                titmin = titulotext.text.ToLower();
                titmax = titulotext.text;
                Debug.Log(titmin);
                Debug.Log(titmax);
                for (int i = 0; i < 11; i++)
                {
                    if (titmax.Equals(Elementos[i,0]))
                    {
                        int suma_de_cura;
                       suma_de_cura = Int32.Parse(Elementos[i, 1]);
                        suma_de_cura = suma_de_cura + 1;
                        Elementos[i, 1] = suma_de_cura.ToString();
                        Debug.Log("entre elementos");
                        Debug.Log(Elementos[i, 1]);
                        variables_indestructibles.Elementos[i, 1] = suma_de_cura.ToString();
                        i = 11;
                    }
                }
                for (int i = 0; i < 25; i++)
                {
                    if (titmin.Equals(Personajes[i,0]))
                    {
                        int suma_de_cura;
                        suma_de_cura=Int32.Parse(Personajes[i,2]);
                        suma_de_cura = suma_de_cura+1;
                        Personajes[i,2]= suma_de_cura.ToString();
                        Debug.Log("entre curas" + Personajes[i, 0] + Personajes[i, 2]);
                        variables_indestructibles.Personajes[i, 2] = suma_de_cura.ToString();
                        i = 25;
                    }
                }
                dinero_actual = dinero_actual - objeto_comprar;
                variables_indestructibles.monedas[0] = dinero_actual.ToString();
                UITexto = GameObject.Find("cantidad").GetComponentInChildren<Text>();
                UITexto.text = dinero_actual.ToString();
                archivo_tienda.guardar_variables();
            }
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[0, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[0, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[0, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom0").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;

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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[1, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[1, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[1, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom1").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[2, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[2, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[2, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom2").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[3, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[3, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[3, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom3").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
                    UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[4, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[4, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[4, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom4").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[5, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[5, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[5, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom5").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[6, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[6, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[6, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom6").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[7, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[7, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[7, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom7").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[8, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[8, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[8, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom8").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[9, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[9, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[9, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom9").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
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
            UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[10, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[10, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[10, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom10").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda11()
    {
        if (pestañas == 3)
        {
                        UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[11, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[11, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[11, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom11").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda12()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[12, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[12, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[12, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom12").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda13()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[13, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[13, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[13, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom13").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda14()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[14, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[14, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[14, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom14").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda15()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[15, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[15, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[15, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom15").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda16()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[16, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[16, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[16, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom16").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda17()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[17, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[17, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[17, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom17").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda18()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[18, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[18, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[18, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom18").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda19()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[19, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[19, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[19, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom19").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda20()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[20, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[20, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[20, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom20").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda21()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[21, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[21, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[21, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom21").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda22()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[22, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[22, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[22, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom22").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda23()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[23, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[23, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[23, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom23").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
    public void celda24()
    {
        if (pestañas == 3)
        {
                      UITexto = GameObject.Find("texto_monedas").GetComponentInChildren<Text>();
            if (Personajes_que_tengo[24, 1].Equals("easy"))
            {
                UITexto.text = "50 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[24, 1].Equals("Complex"))
            {
                UITexto.text = "250 monedas ";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = null;
            }
            else if (Personajes_que_tengo[24, 1].Equals("Hard"))
            {
                UITexto.text = "500 monedas";
                UITexto = GameObject.Find("texto_bi").GetComponentInChildren<Text>();
                UITexto.text = "1 Bi";
            }
            UITexto = GameObject.Find("nom24").GetComponentInChildren<Text>();
            nombre_intercambio = UITexto.text;
        }
    }
}
