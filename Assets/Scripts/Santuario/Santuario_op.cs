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
public class Santuario_op : MonoBehaviour
{
    // Start is called before the first frame update
  public  GameObject empezar_buton, confirmacion;
  Image UIImage, Imagepanel;
  Text UITexto, titulotext;
  String[,] Personajes = new String[25, 6];
  String[,] Elementos = new String[25, 5];
  Archivos archivo_santuario;
  String bis,bis1;
  public Text Tiempotext;
  public float tiemp ;
    int startTime;
    public Animator anim;
    
    void Start()
    {
        archivo_santuario = GameObject.Find("Santuario").GetComponent<Archivos>();
//   archivo_santuario.Borrar();
  //      archivo_santuario.Crear();
        archivo_santuario.Cargar_Tienda(Personajes, Elementos);
        bis = archivo_santuario.carga_bismuto(bis1);
        UITexto = GameObject.Find("bismuto").GetComponentInChildren<Text>();
        UITexto.text = bis+ " Bi";
        Debug.Log("entre");
        Debug.Log(Personajes[19, 2]);
        //var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        //videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime == 1)
        {
                tiemp -= Time.deltaTime;
                Tiempotext.text = "" + tiemp.ToString("f0");
                if (tiemp <= 1)
                {
                    startTime = 0;
                    Tiempotext.text = "";
                    tiemp = 30;
                    anim.SetBool("isTransacting", false);
                }
        }
    }
    public void empezar()
    {
        if (startTime != 1)
        {
            int x = 1;
            empezar_buton.SetActive(true);
            for (int i = 20; i < 25; i++)
            {
                if (!Personajes[i, 2].Equals("0"))
                {
                    UIImage = GameObject.Find("imgcomp" + x.ToString()).GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0]);
                    UITexto = GameObject.Find("txtcompuesto" + x.ToString()).GetComponentInChildren<Text>();
                    UITexto.text = Personajes[i, 0];
                    UITexto = GameObject.Find("txtcant" + x.ToString()).GetComponentInChildren<Text>();
                    UITexto.text = Personajes[i, 2] + " unidades";
                    x++;
                }
            }
        }
    }
    public void voler()
    {
        if (startTime != 1)
        {
            SceneManager.LoadScene("Mapajuego");
        }
    }
    public void cerrar_paneles()
    {
        empezar_buton.SetActive(true);
        int x = 1;
        for (int i = 20; i < 25; i++)
        {

                UIImage = GameObject.Find("imgcomp" + x.ToString()).GetComponentInChildren<Image>();
                UIImage.sprite = null;
                UITexto = GameObject.Find("txtcompuesto" + x.ToString()).GetComponentInChildren<Text>();
                UITexto.text = null;
                UITexto = GameObject.Find("txtcant" + x.ToString()).GetComponentInChildren<Text>();
                UITexto.text = null;
                x++;
            
        }
        empezar_buton.SetActive(false);
        confirmacion.SetActive(false);
    }
    public void cerrar_confirmacion()
    {
        confirmacion.SetActive(false);
    }
    public void proceder()
    {
        anim.SetBool("isTransacting", true);
        titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
        for (int i = 20; i < 25; i++)
        {
            if ((titulotext.text).Equals(Personajes[i, 0]))
            { 
                int decremento;
                decremento = Int32.Parse(Personajes[i, 2]);
                decremento = decremento - 1;
                Personajes[i, 2] = decremento.ToString();
                variables_indestructibles.Personajes[i, 2] = Personajes[i, 2];
                Debug.Log(bis);
                decremento = Int32.Parse(bis);
                decremento = decremento + 15;
                bis = decremento.ToString();
                variables_indestructibles.bismuto = bis;
                UITexto = GameObject.Find("bismuto").GetComponentInChildren<Text>();
                UITexto.text = bis+" Bi";
                archivo_santuario.guardar_variables();
                titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
                titulotext.text= Personajes[i,2]+" unidades";
                i = 25;
            }
        }
        startTime = 1;
    }
    public void tim()
    {
    }
    public void celda0()
    {
        UITexto = GameObject.Find("txtcompuesto1").GetComponentInChildren<Text>();
        if (!(UITexto.text).Equals(""))
        {
            confirmacion.SetActive(true);
            UIImage = GameObject.Find("imgcomp1").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("txtcompuesto1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("txtcant1").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
        
    }
    public void celda1()
    {
        UITexto = GameObject.Find("txtcompuesto2").GetComponentInChildren<Text>();
        if (!(UITexto.text).Equals(""))
        {
            confirmacion.SetActive(true);
            UIImage = GameObject.Find("imgcomp2").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("txtcompuesto2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("txtcant2").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
    }
    public void celda2()
    {
        UITexto = GameObject.Find("txtcompuesto3").GetComponentInChildren<Text>();
        if (!(UITexto.text).Equals(""))
        {
            confirmacion.SetActive(true);
            UIImage = GameObject.Find("imgcomp3").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("txtcompuesto3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("txtcant3").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
    }
    public void celda3()
    {
        UITexto = GameObject.Find("txtcompuesto4").GetComponentInChildren<Text>();
        if (!(UITexto.text).Equals(""))
        {
            confirmacion.SetActive(true);
            UIImage = GameObject.Find("imgcomp4").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("txtcompuesto4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("txtcant4").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
    }
    public void celda4()
    {
        UITexto = GameObject.Find("txtcompuesto5").GetComponentInChildren<Text>();
        if (!(UITexto.text).Equals(""))
        {
            confirmacion.SetActive(true);
            UIImage = GameObject.Find("imgcomp5").GetComponentInChildren<Image>();
            Imagepanel = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
            Imagepanel.sprite = UIImage.sprite;
            UITexto = GameObject.Find("txtcompuesto5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
            UITexto = GameObject.Find("txtcant5").GetComponentInChildren<Text>();
            titulotext = GameObject.Find("Textdescripcion").GetComponentInChildren<Text>();
            titulotext.text = UITexto.text;
        }
    }
}
