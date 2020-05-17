using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;
public class botones_laboratorio : MonoBehaviour
{
    int suma = 1;
    BinaryFormatter fb;
    FileStream Informacion;
    DatosdeJuego Datos;
    String[,] Personajes = new String[25, 8];
    String[,] Elementos = new String[11, 5];
    String[,] Elementos2 = new String[11, 3];
    String[,] verificadores = new String[11, 4];
    String[,] plussless = new String[11, 2];
    public String cargarformula;
    Text celdas_elementos_adquiridos, add, totalelemtnos_panel_seleccion, cantidad_panel_seleccionados, texto_alerta;
    public GameObject panel_elementos_seleccion, LoadPanel, Alerta_a, panel_confirmacion_final, SelectPanel, alerta_sulfa;
    Text elementin;
    Image UIImage;
    Text[] element = new Text[11];
    int tefaltamas = 0, tesobran = 0;
    int[] elemento = new int[11];
    int[] conjunto = new int[25];
    int num_of_scene = 0;
    string dest;
    Archivos archivo_almacen;
    // Start is called before the first frame update
    void Start()
    {
        archivo_almacen = GameObject.Find("Laboratorio").GetComponent<Archivos>();
        archivo_almacen.Cargar_Tienda(Personajes, Elementos);
        archivo_almacen.cargar_variables();
        ElementrosAdquiridos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLab()
    {
        SelectPanel.SetActive(true);
    }

    public void cerrar_panel_alerta_a()
    {
        Alerta_a.SetActive(false);
    }
    public void ElementrosAdquiridos()
    {
        int posicion = 1;
        for (int i = 0; i < 11; i++)
        {
            if (Elementos[i, 1] != "0")
            {
                celdas_elementos_adquiridos = GameObject.Find("txtelemento" + posicion.ToString()).GetComponentInChildren<Text>();
                celdas_elementos_adquiridos.text = Elementos[i, 4];
                verificadores[posicion - 1, 0] = Elementos[i, 4];
                celdas_elementos_adquiridos = GameObject.Find("textnombre_elemento" + posicion.ToString()).GetComponentInChildren<Text>();
                celdas_elementos_adquiridos.text = Elementos[i, 0];
                verificadores[posicion - 1, 1] = Elementos[i, 0];
                verificadores[posicion - 1, 2] = Elementos[i, 1];
                verificadores[posicion - 1, 3] = Elementos[i, 2];
                posicion++;
            }
        }
    }
    public void plus()
    {
        int i = 1, restaelementospanelselecion = 0, sumapanelseleccionados = 0, busqueda = 0;
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        totalelemtnos_panel_seleccion = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        if (totalelemtnos_panel_seleccion.text.Equals("0"))
        {
            Debug.Log("Nel perro");
        }
        else
        {
            for (int o = 0; o < 11; o++)
            {
                add = GameObject.Find("txtdestino" + i.ToString()).GetComponentInChildren<Text>();
                if (add.text.Equals(""))
                {
                    add.text = celdas_elementos_adquiridos.text;
                    celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
                    add = GameObject.Find("textnombre_destino" + i.ToString()).GetComponentInChildren<Text>();
                    add.text = celdas_elementos_adquiridos.text;
                    cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i.ToString()).GetComponentInChildren<Text>();
                    if (cantidad_panel_seleccionados.text.Equals(""))
                    {
                        dest = "0";
                    }
                    else
                    {
                        dest = cantidad_panel_seleccionados.text;
                    }
                    sumapanelseleccionados = Int16.Parse(dest);
                    sumapanelseleccionados++;
                    cantidad_panel_seleccionados.text = sumapanelseleccionados.ToString();
                    for (; busqueda < 11; busqueda++)
                    {
                        if (add.text.Equals(Elementos[busqueda, 0]))
                        {
                            restaelementospanelselecion = Int16.Parse(Elementos[busqueda, 1]);
                            restaelementospanelselecion = restaelementospanelselecion - 1;
                            Elementos[busqueda, 1] = restaelementospanelselecion.ToString();
                            totalelemtnos_panel_seleccion = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
                            totalelemtnos_panel_seleccion.text = Elementos[busqueda, 1];
                            ElementrosAdquiridos();
                        }
                    }


                    o = 11;
                }
                else if (add.text.Equals(celdas_elementos_adquiridos.text))
                {
                    cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i.ToString()).GetComponentInChildren<Text>();
                    sumapanelseleccionados = Int16.Parse(cantidad_panel_seleccionados.text);
                    sumapanelseleccionados++;
                    cantidad_panel_seleccionados.text = sumapanelseleccionados.ToString();
                    for (; busqueda < 10; busqueda++)
                    {
                        if (add.text.Equals(Elementos[busqueda, 4]))
                        {
                            restaelementospanelselecion = Int16.Parse(Elementos[busqueda, 1]);
                            restaelementospanelselecion = restaelementospanelselecion - 1;
                            Elementos[busqueda, 1] = restaelementospanelselecion.ToString();
                            totalelemtnos_panel_seleccion = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
                            totalelemtnos_panel_seleccion.text = Elementos[busqueda, 1];
                            ElementrosAdquiridos();
                        }
                    }
                    o = 11;
                }
                i++;
            }
        }
    }
    public void less()
    {
        int i = 1, restaelementospanelselecion = 1, sumapanelseleccionados = 1, busqueda = 0;
        for (int o = 0; o < 11; o++)
        {
            celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
            totalelemtnos_panel_seleccion = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
            add = GameObject.Find("txtdestino" + i.ToString()).GetComponentInChildren<Text>();
            if (add.text.Equals(celdas_elementos_adquiridos.text))
            {

                cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i.ToString()).GetComponentInChildren<Text>();
                sumapanelseleccionados = Int16.Parse(cantidad_panel_seleccionados.text);
                if (sumapanelseleccionados == 0)
                {
                }
                else
                {
                    sumapanelseleccionados--;
                    cantidad_panel_seleccionados.text = sumapanelseleccionados.ToString();

                    for (; busqueda < 11; busqueda++)
                    {
                        add = GameObject.Find("textnombre_destino" + i.ToString()).GetComponentInChildren<Text>();
                        if (add.text.Equals(Elementos[busqueda, 0]))
                        {
                            restaelementospanelselecion = Int16.Parse(Elementos[busqueda, 1]);
                            restaelementospanelselecion = restaelementospanelselecion + 1;
                            Elementos[busqueda, 1] = restaelementospanelselecion.ToString();
                            totalelemtnos_panel_seleccion = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
                            totalelemtnos_panel_seleccion.text = Elementos[busqueda, 1];
                            ElementrosAdquiridos();

                        }
                    }
                    if (sumapanelseleccionados == 0)
                    {
                        add = GameObject.Find("txtdestino" + i.ToString()).GetComponentInChildren<Text>();
                        add.text = null;
                        add = GameObject.Find("textnombre_destino" + i.ToString()).GetComponentInChildren<Text>();
                        add.text = null;
                        add = GameObject.Find("txtcantidad_destino" + i.ToString()).GetComponentInChildren<Text>();
                        add.text = "0";
                        actualizacion_elementos_select();
                    }
                }
                o = 11;
            }
            i++;
        }

    }
    public void actualizacion_elementos_select()
    {
        for (int i = 1; i < 12; i++)
        {
            celdas_elementos_adquiridos = GameObject.Find("txtdestino" + i.ToString()).GetComponentInChildren<Text>();
            int position = i + 1;
            if (position == 12)
            {
            }
            else
            {
                add = GameObject.Find("txtdestino" + position.ToString()).GetComponentInChildren<Text>();

                if (celdas_elementos_adquiridos.text.Equals("") && add.text != "")
                {
                    celdas_elementos_adquiridos.text = add.text;
                    add.text = null;
                    celdas_elementos_adquiridos = GameObject.Find("textnombre_destino" + i.ToString()).GetComponentInChildren<Text>();
                    add = GameObject.Find("textnombre_destino" + position.ToString()).GetComponentInChildren<Text>();
                    celdas_elementos_adquiridos.text = add.text;
                    add.text = null;
                    add = GameObject.Find("txtcantidad_destino" + position.ToString()).GetComponentInChildren<Text>();
                    celdas_elementos_adquiridos = GameObject.Find("txtcantidad_destino" + i.ToString()).GetComponentInChildren<Text>();
                    celdas_elementos_adquiridos.text = add.text;
                    add.text = "0";
                }
            }
        }
    }
    public void activarpanel()
    {
        panel_elementos_seleccion.SetActive(true);
    }
    public void desactivarpanel()
    {
        SelectPanel.SetActive(false);
        panel_elementos_seleccion.SetActive(false);
        panel_confirmacion_final.SetActive(false);
        Alerta_a.SetActive(false);
    }
    public void ElementrosAdquirido_Celda1()
    {

        activarpanel();

        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[0, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[0, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[0, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[0, 3];
    }
    public void ElementrosAdquirido_Celda2()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[1, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[1, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[1, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[1, 3];
    }
    public void ElementrosAdquirido_Celda3()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[2, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[2, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[2, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[2, 3];
    }
    public void ElementrosAdquirido_Celda4()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[3, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[3, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[3, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[3, 3];
    }
    public void ElementrosAdquirido_Celda5()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[4, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[4, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[4, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[4, 3];
    }
    public void ElementrosAdquirido_Celda6()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[5, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[5, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[5, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[5, 3];
    }
    public void ElementrosAdquirido_Celda7()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[6, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[6, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[6, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[6, 3];
    }
    public void ElementrosAdquirido_Celda8()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[7, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[7, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[7, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[7, 3];
    }
    public void ElementrosAdquirido_Celda9()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[8, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[8, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[8, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[8, 3];
    }
    public void ElementrosAdquirido_Celda10()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[9, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[9, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[9, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[9, 3];
    }
    public void ElementrosAdquirido_Celda11()
    {
        activarpanel();
        celdas_elementos_adquiridos = GameObject.Find("texto_elementoselect").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[10, 0];
        celdas_elementos_adquiridos = GameObject.Find("Text_panel_seleccion").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[10, 1];
        celdas_elementos_adquiridos = GameObject.Find("total_seleccionados").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[10, 2];
        celdas_elementos_adquiridos = GameObject.Find("descripcion_elemento").GetComponentInChildren<Text>();
        celdas_elementos_adquiridos.text = verificadores[10, 3];
    }
    public void sulfa()
    {
        num_of_scene = 14;
        variables_indestructibles.estructuracion = "Sulfasalazina";
        alerta_sulfa.SetActive(false);
        archivo_almacen.guardar_variables();
        img_text_p_confirmacion();
    }
    public void h_sulfa()
    {
        num_of_scene = 22;
        variables_indestructibles.estructuracion = "H_Sulfasalazina";
        alerta_sulfa.SetActive(false);
        archivo_almacen.guardar_variables();
        img_text_p_confirmacion();
    }
    public void img_text_p_confirmacion()
    {
        String nameofcura = variables_indestructibles.estructuracion.ToLower();
        for (int i = 0; i < 25; i++)
        {
            if (Personajes[i, 0].Equals(nameofcura))
            {
                int niv = Int32.Parse(variables_indestructibles.level[0]);
                if (variables_indestructibles.Personajes[i, 1].Equals("easy"))
                {
                    panel_confirmacion_final.SetActive(true);
                    celdas_elementos_adquiridos = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                    celdas_elementos_adquiridos.text = variables_indestructibles.estructuracion.ToLower();
                    UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
                    UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0].ToString());
                }
                if (variables_indestructibles.Personajes[i, 1].Equals("Complex"))
                {
                    if (niv >= 6)
                    {
                        panel_confirmacion_final.SetActive(true);
                        celdas_elementos_adquiridos = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                        celdas_elementos_adquiridos.text = variables_indestructibles.estructuracion.ToLower();
                        UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0].ToString());
                    }
                    else
                    {
                        Alerta_a.SetActive(true);
                        texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
                        texto_alerta.text = "Nivel insuficiente para crear personaje Complex";
                    }
                }
                if (variables_indestructibles.Personajes[i, 1].Equals("Hard"))
                {
                    if (niv >= 8)
                    {
                        panel_confirmacion_final.SetActive(true);
                        celdas_elementos_adquiridos = GameObject.Find("Texttitulo").GetComponentInChildren<Text>();
                        celdas_elementos_adquiridos.text = variables_indestructibles.estructuracion.ToLower();
                        UIImage = GameObject.Find("Imagedescripcion").GetComponentInChildren<Image>();
                        UIImage.sprite = Resources.Load<Sprite>(Personajes[i, 0].ToString());
                    }
                    else
                    {
                        Alerta_a.SetActive(true);
                        texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
                        texto_alerta.text = "Nivel insuficiente para crear personaje Hard";
                    }
                }
            }
        }
    }
    public void siguiente()
    {
        String[] bandera_de_elementos = new String[25];
        for (int recorrdio = 0; recorrdio < 25; recorrdio++)
        {
            bandera_de_elementos[recorrdio] = "Este si";
            conjunto[recorrdio] = 0;
        }
        for (int recorrdio = 0; recorrdio < 11; recorrdio++)
        {
            element[recorrdio] = null;
            elemento[recorrdio] = 0;
        }
        for (int x = 0; x < 3; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                variables_indestructibles.Elementos2[i, x] = "";
                archivo_almacen.guardar_variables();
            }
        }
        int contador = 0;
        int i2 = 0, index = 0, vacio = 0;
        for (int i3 = 1; i3 < 12; i3++)
        {
            element[i2] = GameObject.Find("txtdestino" + i3.ToString()).GetComponentInChildren<Text>();
            variables_indestructibles.Elementos2[i2, 0] = element[i2].text;
            cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i3.ToString()).GetComponentInChildren<Text>();
            if (cantidad_panel_seleccionados.text.Equals("") || cantidad_panel_seleccionados.text.Equals("0"))
            {
                cantidad_panel_seleccionados.text = "0";
                vacio++;
                Debug.Log(vacio.ToString());
            }
            elemento[i2] = Int16.Parse(cantidad_panel_seleccionados.text.ToString());
            variables_indestructibles.Elementos2[i2, 1] = elemento[i2].ToString();
            if (bandera_de_elementos[0] == "Este si")
            {
                if (element[i2].text != ("C") && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != (""))
                {
                    bandera_de_elementos[0] = "Este no";
                    contador++;
                }
                if (vacio >= 9)
                {
                    bandera_de_elementos[0] = "Este no";
                }
            }
            if (bandera_de_elementos[1] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[1] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[1] = "Este no";
                }
            }
            if (bandera_de_elementos[2] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[2] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[2] = "Este no";
                }
            }
            if (bandera_de_elementos[3] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "Cl" && element[i2].text != "")
                {
                    bandera_de_elementos[3] = "Este no";
                    contador++;
                }
                if (vacio >= 6)
                {
                    bandera_de_elementos[3] = "Este no";
                }
            }
            if (bandera_de_elementos[4] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "B" && element[i2].text != "")
                {
                    bandera_de_elementos[4] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[4] = "Este no";
                }
            }
            if (bandera_de_elementos[5] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[5] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[5] = "Este no";
                }
            }
            if (bandera_de_elementos[6] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[6] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[6] = "Este no";
                }
            }
            if (bandera_de_elementos[7] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[7] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[7] = "Este no";
                }
            }
            if (bandera_de_elementos[8] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[8] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[8] = "Este no";
                }
            }
            if (bandera_de_elementos[9] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[9] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[9] = "Este no";
                }
            }
            if (bandera_de_elementos[10] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "F" && element[i2].text != "")
                {
                    bandera_de_elementos[10] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[10] = "Este no";
                }
            }
            if (bandera_de_elementos[11] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[11] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[11] = "Este no";
                }
            }
            if (bandera_de_elementos[12] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "Cl" && element[i2].text != "")
                {
                    bandera_de_elementos[12] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[12] = "Este no";
                }
            }
            if (bandera_de_elementos[13] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[13] = "Este no";
                    contador++;
                }
                if (vacio >= 9)
                {
                    bandera_de_elementos[13] = "Este no";
                }
            }
            if (bandera_de_elementos[14] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[14] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[14] = "Este no";
                }
            }
            if (bandera_de_elementos[15] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[15] = "Este no";
                    contador++;
                }
                if (vacio >= 9)
                {
                    bandera_de_elementos[15] = "Este no";
                }
            }
            if (bandera_de_elementos[16] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[16] = "Este no";
                    contador++;
                }
                if (vacio >= 9)
                {
                    bandera_de_elementos[16] = "Este no";
                }
            }
            if (bandera_de_elementos[17] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[17] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[17] = "Este no";
                }
            }
            if (bandera_de_elementos[18] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[18] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[18] = "Este no";
                }
            }
            if (bandera_de_elementos[19] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[19] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[19] = "Este no";
                }
            }
            if (bandera_de_elementos[20] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != "")
                {
                    bandera_de_elementos[20] = "Este no";
                    contador++;
                }
                if (vacio >= 9)
                {
                    bandera_de_elementos[20] = "Este no";
                }
            }
            if (bandera_de_elementos[21] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "Cl" && element[i2].text != "")
                {
                    bandera_de_elementos[21] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[21] = "Este no";
                }
            }
            if (bandera_de_elementos[22] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "S" && element[i2].text != "")
                {
                    bandera_de_elementos[22] = "Este no";
                    contador++;
                }
                if (vacio >= 7)
                {
                    bandera_de_elementos[22] = "Este no";
                }
            }
            if (bandera_de_elementos[23] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "O" && element[i2].text != "F" && element[i2].text != "")
                {
                    bandera_de_elementos[23] = "Este no";
                    contador++;
                }
                if (vacio >= 8)
                {
                    bandera_de_elementos[23] = "Este no";
                }
            }
            if (bandera_de_elementos[24] == "Este si")
            {
                if (element[i2].text != "C" && element[i2].text != "H" && element[i2].text != "N" && element[i2].text != "O" && element[i2].text != "Co" && element[i2].text != "P" && element[i2].text != "")
                {
                    bandera_de_elementos[24] = "Este no";
                    contador++;
                }
                if (vacio >= 6)
                {
                    bandera_de_elementos[24] = "Este no";
                    Debug.Log("no se pudo compa");
                }
            }
            i2++;
        }
        if (contador == 25)
        {
            Debug.Log("Ninguna formula puede crearce con estos elementos");
            Alerta_a.SetActive(true);
            texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
            texto_alerta.text = "Ninguna formula puede crearce con estos elementos";
        }
        else
        {
            if (bandera_de_elementos[0].Equals("Este si"))
            {
                index = 0;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[1].Equals("Este si"))
            {
                index = 1;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[2].Equals("Este si"))
            {
                index = 2;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[3].Equals("Este si"))
            {
                index = 3;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[4].Equals("Este si"))
            {
                index = 4;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[5].Equals("Este si"))
            {
                index = 5;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[6].Equals("Este si"))
            {
                index = 6;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[7].Equals("Este si"))
            {
                index = 7;
                Desifrocompuesto(index);

            }
            if (bandera_de_elementos[8].Equals("Este si"))
            {
                index = 8;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[9].Equals("Este si"))
            {
                index = 9;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[10].Equals("Este si"))
            {
                index = 10;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[11].Equals("Este si"))
            {
                index = 11;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[12].Equals("Este si"))
            {
                index = 12;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[13].Equals("Este si"))
            {
                index = 13;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[14].Equals("Este si"))
            {
                index = 14;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[15].Equals("Este si"))
            {
                index = 15;
                Desifrocompuesto(index);

            }
            if (bandera_de_elementos[16].Equals("Este si"))
            {
                index = 16;
                Desifrocompuesto(index);

            }
            if (bandera_de_elementos[17].Equals("Este si"))
            {
                index = 17;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[18].Equals("Este si"))
            {
                index = 18;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[19].Equals("Este si"))
            {
                index = 19;
                Desifrocompuesto(index);

            }
            if (bandera_de_elementos[20].Equals("Este si"))
            {
                index = 20;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[21].Equals("Este si"))
            {
                index = 21;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[22].Equals("Este si"))
            {
                index = 22;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[23].Equals("Este si"))
            {
                index = 23;
                Desifrocompuesto(index);
            }
            if (bandera_de_elementos[24].Equals("Este si"))
            {
                index = 24;
                Desifrocompuesto(index);

            }

            archivo_almacen = GameObject.Find("Laboratorio").GetComponent<Archivos>();
            if (conjunto[0] == 3)
            {
                Debug.Log("Aspirina");
                num_of_scene = 0;
                variables_indestructibles.estructuracion = "Aspirina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[1] == 4)
            {
                Debug.Log("Paracetamol");
                num_of_scene = 1;
                variables_indestructibles.estructuracion = "Paracetamol";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[2] == 5)
            {
                Debug.Log("Amoxicilina");
                num_of_scene = 2;
                variables_indestructibles.estructuracion = "Amoxicilina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[3] == 6)
            {
                Debug.Log("Cloxacilina");
                num_of_scene = 3;
                variables_indestructibles.estructuracion = "Cloxacilina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[4] == 5)
            {
                Debug.Log("Bortezomib");
                num_of_scene = 4;
                variables_indestructibles.estructuracion = "Bortezomib";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[5] == 4)
            {
                Debug.Log("Lenalidomida");
                num_of_scene = 5;
                variables_indestructibles.estructuracion = "Lenalidomida";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[6] == 4)
            {
                Debug.Log("Vorinostat");
                num_of_scene = 6;
                variables_indestructibles.estructuracion = "Vorinostat";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[7] == 4)
            {
                Debug.Log("Clavulanato");
                num_of_scene = 7;
                variables_indestructibles.estructuracion = "Clavulanato";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[8] == 5)
            {
                Debug.Log("Penicilina");
                num_of_scene = 8;
                variables_indestructibles.estructuracion = "Penicilina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[9] == 4)
            {
                Debug.Log("Eritromicina");
                num_of_scene = 9;
                variables_indestructibles.estructuracion = "Eritromicina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[10] == 5)
            {
                Debug.Log("Levofloxacino");
                num_of_scene = 10;
                variables_indestructibles.estructuracion = "Levofloxacino";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[11] == 4)
            {
                Debug.Log("Betanecol");
                num_of_scene = 11;
                variables_indestructibles.estructuracion = "Betanecol";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[12] == 5)
            {
                Debug.Log("Metoclopramida");
                num_of_scene = 12;
                variables_indestructibles.estructuracion = "Metoclopramida";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[13] == 3)
            {
                Debug.Log("Ibuprofeno");
                num_of_scene = 13;
                variables_indestructibles.estructuracion = "Ibuprofeno";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[14] == 5)
            {
                int niv = Int32.Parse(variables_indestructibles.level[0]);
                if (niv >= 8)
                {
                    alerta_sulfa.SetActive(true);
                }
                else
                {
                    Debug.Log("Sulfasalazina");
                    num_of_scene = 14;
                    variables_indestructibles.estructuracion = "Sulfasalazina";
                    archivo_almacen.guardar_variables();
                    img_text_p_confirmacion();
                }
            }
            else if (conjunto[15] == 3)
            {
                Debug.Log("Prednisona");
                num_of_scene = 15;
                variables_indestructibles.estructuracion = "Prednisona";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[16] == 3)
            {
                Debug.Log("Cortisol");
                num_of_scene = 16;
                variables_indestructibles.estructuracion = "Cortisol";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[17] == 5)
            {
                Debug.Log("Ampicilina");
                num_of_scene = 17;
                variables_indestructibles.estructuracion = "Ampicilina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[18] == 5)
            {
                Debug.Log("Piperacilina");
                num_of_scene = 18;
                variables_indestructibles.estructuracion = "Piperacilina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[19] == 5)
            {
                Debug.Log("Tazobactam");
                num_of_scene = 19;
                variables_indestructibles.estructuracion = "Tazobactam";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[20] == 3)
            {
                Debug.Log("Metilprednisolona");
                num_of_scene = 20;
                variables_indestructibles.estructuracion = "Metilprednisolona";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[21] == 5)
            {
                Debug.Log("Hidroxicloroquina");
                num_of_scene = 21;
                variables_indestructibles.estructuracion = "Hidroxicloroquina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[22] == 5)
            {
                Debug.Log("H_Sulfasalazina");
                num_of_scene = 22;
                variables_indestructibles.estructuracion = "H_Sulfasalazina";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[23] == 4)
            {
                Debug.Log("Dexametasona");
                num_of_scene = 23;
                variables_indestructibles.estructuracion = "Dexametasona";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (conjunto[24] == 6)
            {
                Debug.Log("Vitamina B12");
                num_of_scene = 24;
                variables_indestructibles.estructuracion = "Vitamina B12";
                archivo_almacen.guardar_variables();
                img_text_p_confirmacion();
            }
            else if (tesobran == tefaltamas)
            {
                Debug.Log("tienes elementos con cantidades mayores y menores a la necesaria");
                Alerta_a.SetActive(true);
                texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
                texto_alerta.text = "Formula incompleta o cantidades de elementos mayores/menores a los necesarios";
                tefaltamas = 0;
                tesobran = 0;
                for (int i3 = 1; i3 < 12; i3++)
                {
                    element[i3 - 1] = GameObject.Find("txtdestino" + i3.ToString()).GetComponentInChildren<Text>();
                    cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i3.ToString()).GetComponentInChildren<Text>();
                    if (cantidad_panel_seleccionados.text.Equals("") || cantidad_panel_seleccionados.text.Equals("0"))
                    {
                        cantidad_panel_seleccionados.text = "";
                    }
                }
            }
            else if (tefaltamas < tesobran)
            {
                Debug.Log("Tienes una cantidad de elementos necesarios mayor a la requerida " + tesobran + " " + tefaltamas);
                Alerta_a.SetActive(true);
                texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
                texto_alerta.text = "Tienes una cantidad de elementos necesarios mayor a la requerida ";
                tefaltamas = 0;
                tesobran = 0;
                for (int i3 = 1; i3 < 12; i3++)
                {
                    element[i3 - 1] = GameObject.Find("txtdestino" + i3.ToString()).GetComponentInChildren<Text>();
                    cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i3.ToString()).GetComponentInChildren<Text>();
                    if (cantidad_panel_seleccionados.text.Equals("") || cantidad_panel_seleccionados.text.Equals("0"))
                    {
                        cantidad_panel_seleccionados.text = "";
                    }
                }
            }
            else if (tesobran < tefaltamas)
            {
                Debug.Log("Tienes una cantidad de elementos necesarios menor a la requerida " + tefaltamas + " " + tesobran);
                Alerta_a.SetActive(true);
                texto_alerta = GameObject.Find("us/pass/incorrectos").GetComponentInChildren<Text>();
                texto_alerta.text = "Tienes una cantidad de elementos necesarios menor a la requerida ";
                tefaltamas = 0;
                tesobran = 0;
                for (int i3 = 1; i3 < 12; i3++)
                {
                    element[i3 - 1] = GameObject.Find("txtdestino" + i3.ToString()).GetComponentInChildren<Text>();
                    cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + i3.ToString()).GetComponentInChildren<Text>();
                    if (cantidad_panel_seleccionados.text.Equals("") || cantidad_panel_seleccionados.text.Equals("0"))
                    {
                        cantidad_panel_seleccionados.text = "";
                    }
                }
            }
        }

    }

    public void Desifrocompuesto(int index)
    {
        for (int recorrido = 0; recorrido < 11; recorrido++)
        {
            if (index == 0)
            {

                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 9)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 9)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 9)
                    {
                        tefaltamas++;
                    }
                    Debug.Log("entre a index 0");
                }
                else if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 8)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 8)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 8)
                    {
                        tefaltamas++;
                    }
                }
                else if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 1)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 8)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 8)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 8)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 9)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 9)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 9)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 2)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 16)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 16)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 16)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 19)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 19)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 19)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 3)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 19)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 19)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 19)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("Cl"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 4)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 19)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 19)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 19)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 25)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 25)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 25)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("B"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 5)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 13)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 13)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 13)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 13)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 13)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 13)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 6)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 20)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 20)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 20)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 7)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 8)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 8)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 8)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 9)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 9)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 9)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 8)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 16)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 16)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 16)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 9)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 37)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 37)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 37)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 67)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 67)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 67)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 13)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 13)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 13)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 10)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 20)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 20)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 20)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("F"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 11)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 7)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 7)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 7)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 17)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 17)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 17)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 12)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 22)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 22)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 22)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("Cl"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 13)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 13)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 13)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 13)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 2)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 2)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 2)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 14)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 15)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 21)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 21)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 21)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 26)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 26)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 26)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 16)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 21)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 21)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 21)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 30)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 30)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 30)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 17)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 16)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 16)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 16)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 19)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 19)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 19)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 18)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 23)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 23)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 23)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 27)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 27)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 27)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 7)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 7)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 7)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 19)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 10)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 10)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 10)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 12)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 12)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 12)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 20)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 22)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 22)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 22)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 30)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 30)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 30)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 21)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 26)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 26)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 26)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("Cl"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 3)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 3)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 3)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 22)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 18)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 18)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 18)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 4)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 4)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 4)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("S"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 23)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 22)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 22)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 22)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 29)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 29)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 29)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("F"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 5)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 5)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 5)
                    {
                        tefaltamas++;
                    }
                }
            }
            if (index == 24)
            {
                if (element[recorrido].text.Equals("C"))
                {
                    if (elemento[recorrido] == 63)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 63)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 63)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("H"))
                {
                    if (elemento[recorrido] == 88)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 88)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 88)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("Co"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("N"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("O"))
                {
                    if (elemento[recorrido] == 14)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 14)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 14)
                    {
                        tefaltamas++;
                    }
                }
                if (element[recorrido].text.Equals("P"))
                {
                    if (elemento[recorrido] == 1)
                    {
                        conjunto[index]++;
                    }
                    else if (elemento[recorrido] > 1)
                    {
                        tesobran++;
                    }
                    else if (elemento[recorrido] < 1)
                    {
                        tefaltamas++;
                    }
                }
            }
        }
    }
    public void Mapa()
    {
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }
    public void proceder_to_estruct()
    {
        panel_confirmacion_final.SetActive(false);
        LoadScene.sceneToLoad = "Estruct" + num_of_scene.ToString();
        LoadPanel.SetActive(true);
    }
}



/*
for ( o = 1; o < 11; o++)
{
cantidad_panel_seleccionados = GameObject.Find("txtcantidad_destino" + o.ToString()).GetComponentInChildren<Text>();
celdas_elementos_adquiridos = GameObject.Find("txtdestino" + o.ToString()).GetComponentInChildren<Text>();
hidrogeno = Int16.Parse(cantidad_panel_seleccionados.text);
if (celdas_elementos_adquiridos.text.Equals("N") && hidrogeno >= 4)
{
contador++;
}
if (celdas_elementos_adquiridos.text.Equals("O") && hidrogeno >= 5)
{
contador++;
}
if (celdas_elementos_adquiridos.text.Equals("S") && hidrogeno >= 1)
{
contador++;
}
if (celdas_elementos_adquiridos.text != "N" || celdas_elementos_adquiridos.text != "O" || celdas_elementos_adquiridos.text != "S" || celdas_elementos_adquiridos.text!="C" || celdas_elementos_adquiridos.text!="H")
{
contador = 0;
Debug.Log("Elemento no correspondiente a la formula");
o = 11;
}
}
contador++;
if (contador == 4)
{
dexametasona = 11;
o = 11;
}
}
if (celdas_elementos_adquiridos.text.Equals("H") && hidrogeno >= 26)
{
for ( o = 1; o < 11; o++)
{

}
contador++;
}
}*/