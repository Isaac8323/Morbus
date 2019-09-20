using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
public class AdminMYSQL : MonoBehaviour
{
    public string servidorBaseDatos;
    public string nombreBaseDatos;
    public string usuarioBaseDatos;
    public string contraseñaBaseDatos;
    public Text Texto;
    public string datosConexion;
    public MySqlConnection conexion;

    // Start is called before the first frame update
    void Start()
    {

    }
    public MySqlConnection ConectarConServidorBaseDatos()
    {
        datosConexion = "Server=" + servidorBaseDatos
              + ";Database=" + nombreBaseDatos
              + ";Uid=" + usuarioBaseDatos
              + ";Pwd=" + ""
              + ";";
        conexion = new MySqlConnection(datosConexion);
        try
        {
            conexion.Open();
            Debug.Log("Conexion con BD correcta");
            Texto.text = "BD correcta";
        }
        catch(MySqlException error){
            Debug.Log("Imposible conectar con BD morbus: " + error);
            Texto.text = "ERROR BD";
        }
        return conexion;
    }
}
