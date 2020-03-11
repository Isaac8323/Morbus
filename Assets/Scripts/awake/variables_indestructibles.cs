using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class variables_indestructibles : MonoBehaviour
{
    // Start is called before the first frame update

    public static String estructuracion;
    //archivo
    public static String Usuario;
    public static String[] level = new String[1];
    public static String[] monedas = new String[1];
    public static String[,] Personajes = new String[25, 8];
    public static String[,] Elementos = new String[11, 5];
    public static String bismuto;
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
