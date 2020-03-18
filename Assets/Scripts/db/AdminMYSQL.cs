
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
public class AdminMYSQL : MonoBehaviour
{
    public Text Texto;
    public string datosConexion;
    public MySqlConnection conexion;

    // Start is called before the first frame update
    void Start()
    {

    }
    public MySqlConnection ConectarConServidorBaseDatos()
    {
        datosConexion = "Server=remotemysql.com"
      + ";Database=ftjULr1Omv"
      + ";Uid=ftjULr1Omv"
      + ";Pwd=dsKUdhYh0O"
      + ";";
        conexion = new MySqlConnection(datosConexion);
        try
        {
            conexion.Open();
            Debug.Log("Conexion con BD correcta nube");
            Texto.text = "Correct connection to db";
        }
        catch
        {
            conexion.Close();
            datosConexion = "Server= localhost"
      + ";Database= morbus"
      + ";Uid= root"
      + ";Pwd=" + ""
      + ";";
            conexion = new MySqlConnection(datosConexion);
            try
            {
                conexion.Open();
                Debug.Log("Conexion con BD correcta local");
                Texto.text = "Correct connection to db";
            }
            catch (MySqlException error)
            {
                conexion.Close();
                Debug.Log("Imposible conectar con BD morbus: " + error);
                Texto.text = "Can't connect to the db";
            }
        }
        return conexion;
    }
}