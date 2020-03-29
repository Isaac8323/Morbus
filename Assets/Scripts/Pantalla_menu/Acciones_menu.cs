using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Acciones_menu : MonoBehaviour
{
    public GameObject menu_principal, panel_registro, panel_iniciosesion, soundtrack;
    public InputField Inputfield_usuario, Inputfield_contraseña, Inputfield_conf_contraseña, Inputfield_ini_us, Inputfield_ini_con;
    public MySqlConnection conn;
    public Text errores;
    public Text  user_loged;
  //  String bitmap2;
    Archivos archiv;

    void Start()
    {
        AdminMYSQL adminmysql = GameObject.Find("Administrador_de_bd").GetComponent<AdminMYSQL>();
        conn = adminmysql.ConectarConServidorBaseDatos();
        archiv = GameObject.Find("Administrador_de_bd").GetComponent<Archivos>();
        archiv.Crear();
        archiv.cargar_variables();
    //    bitmap2 = archiv.filetoarraybit();
        /*ThreadStart delegado = new ThreadStart(CorrerProceso); 
        Thread hilo = new Thread(delegado); 
        hilo.Start();
        soundtrack.GetComponent<AudioSource>().Play();*/
    }
    // MENU
    public void InicializarPanelRegistro()
    {
        Inputfield_usuario.text = "";
        Inputfield_contraseña.text = "";
        Inputfield_conf_contraseña.text = "";
        panel_registro.SetActive(true);
        menu_principal.SetActive(false);
    }
    public void InicializarPanelInicioSesion()
    {
        Inputfield_ini_us.text = "";
        Inputfield_ini_con.text = "";
        panel_iniciosesion.SetActive(true);
        menu_principal.SetActive(false);
    }
    public void Salir_Windows()
    {
        Application.Quit(); //Sale de la aplicacion cuando se ejecute en la computadora mas no en la prueba de Unity
    }
    //BASE DE DATOS
    public void Iniciar_sesion()
    {
        string usuario, contraseña;
        usuario = Inputfield_ini_us.text;
        contraseña = Inputfield_ini_con.text;
        Inputfield_ini_us.text = "";
        Inputfield_ini_con.text = "";
        MySqlDataReader select2;
        MySqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM usuario WHERE nombre_usuario = '" + usuario + "';";
        select2 = cmd.ExecuteReader();
        if (contraseña != "" && usuario != "")
        {
            if (select2.HasRows)
            {
                select2.Close();
                MySqlDataReader select3;
                cmd.CommandText = "SELECT * FROM usuario WHERE password_usuario = '" + contraseña + "';";
                select3 = cmd.ExecuteReader();
                if (select3.HasRows)
                {
                    select3.Close();
                    Debug.Log("si esta");
                    user_loged.text = usuario;
                //    escena();
                }
                else
                {
                    Debug.Log("No esta we");
                    select3.Close();
                    Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
                    errores.text = "Usuario o contraseña incorrectos.";
                    alert.Alerta_inicio_sesion_A();
                }
            }
            else
            {
                select2.Close();
                Debug.Log("no esta we");
                Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
                errores.text = "Usuario o contraseña incorrectos.";
                alert.Alerta_inicio_sesion_A();
            }
        }
        else
        {
            select2.Close();
            Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
            errores.text = "Campo/s vacios ";
            alert.Alerta_inicio_sesion_A();
        }
    }

    public void escena()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Registrar()
    {
        string usuario, contraseña, conf_contraseña;
        string repetido;
        usuario = Inputfield_usuario.text;
        contraseña = Inputfield_contraseña.text;
        conf_contraseña = Inputfield_conf_contraseña.text;
        Inputfield_usuario.text = "";
        Inputfield_contraseña.text = "";
        Inputfield_conf_contraseña.text = "";
        if (contraseña != "" && usuario != "")
        {
            if (contraseña != conf_contraseña)
            {
                Debug.Log("Contraseñas diferentes");
                errores.text = "Contraseñas diferentes";
                Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
                alert.Alerta_inicio_sesion_A();
            }
            else
            {
                MySqlDataReader select;
                string comando = "SELECT nombre_usuario FROM usuario WHERE nombre_usuario = '" + usuario + "';";
                MySqlCommand cmd = new MySqlCommand(comando, conn);
                select = cmd.ExecuteReader();
                if (select.HasRows)
                {
                    select.Close();
                    repetido = "si esta";
                }
                else
                {
                    select.Close();
                    repetido = "no esta we";
                }
                MySqlDataReader select1;
                cmd.CommandText = "SELECT password_usuario FROM usuario WHERE password_usuario = '" + contraseña + "';";
                select1 = cmd.ExecuteReader();
                if (select1.HasRows)
                {
                    select1.Close();
                    repetido = "si esta";
                }
                else
                {
                    select1.Close();
                }
                if (repetido == "si esta")
                {
                    Debug.Log("ya te ganaron ese usuario o contrasena karnal");
                    errores.text = "Usuario o conraseña en uso";
                    Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
                    alert.Alerta_inicio_sesion_A();
                }
                else
                {
                    cmd.CommandText = "insert into usuario values ( 0,'" + usuario + "','" + contraseña + "');"; 
                    cmd.ExecuteNonQuery();
                    int id_user=0;
                    MySqlDataReader select11;
                    cmd.CommandText = "SELECT id_usuario FROM usuario WHERE nombre_usuario = '" + usuario + "';";
                    select11 = cmd.ExecuteReader();
                    if (select11.HasRows)
                    {
                        while (select11.Read())
                        {
                             id_user = Int32.Parse(select11["id_usuario"].ToString());
                            Debug.Log(id_user.ToString());

                        }
                    }
                    select11.Close();
                    for (int i = 0; i < 25; i++)
                    {
                        cmd.CommandText = "insert into personaje values ( 0," + id_user + ", '" + variables_indestructibles.Personajes[i, 0] + "',1,0);";
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "insert into estadisticas values ( 0," + id_user + ",1,0,0,0,1,0);";
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < 11; i++)
                    {
                        cmd.CommandText = "insert into elementos values ( 0," + id_user + ",'" + variables_indestructibles.Elementos[i, 0] + "',0);";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        else
        {
            errores.text = "Campo/s vacios";
            Alertdialog_menu alert = GameObject.Find("Administrador_de_bd").GetComponent<Alertdialog_menu>();
            alert.Alerta_inicio_sesion_A();
        }
    }
    public void Continuar()
    {
     /*                   MySqlDataReader select5;
                string comando = "SELECT archiv FROM usuarios WHERE usuario = '666';";
                MySqlCommand cmd = new MySqlCommand(comando, conn);
                select5 = cmd.ExecuteReader();
                if (select5.HasRows)
                {
                    while (select5.Read()) 
                    {
                        bitmap2 = select5["archiv"].ToString();
                    }
                }
                select5.Close();
        archiv.Creararchivodebd(bitmap2);*/
        SceneManager.LoadScene("Tutorial");
    }
}