using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class variables_indestructibles : MonoBehaviour
{
    // Start is called before the first frame update

    //archivo

    public static String Usuario;
    public static String[] level = new String[1];
    public static String[] monedas = new String[1];
    public static String[,] Personajes = new String[25, 8];
    public static String[,] Elementos = new String[11, 5];
    public static String[] Intentos_curas = new String[25];
    public static String bismuto;
    public static String experiencia;
    public static String nivel_organismo_jefes;
    public static String Sesion;
    public static String estructuracion;
    public static String[,] Elementos2 = new String[11, 3];
    public static String finished;
    public static String Arenas;
    public static String easter;
    public static String first;
    public static String mantenimient;
    //
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void estruct()
    {

    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
