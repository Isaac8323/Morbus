using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Threading;
public class Acciones_menu : MonoBehaviour
{
    public GameObject menu_principal, panel_registro, panel_iniciosesion, soundtrack;
    public InputField Inputfield_usuario, Inputfield_contraseña, Inputfield_conf_contraseña, Inputfield_ini_us, Inputfield_ini_con;
    public MySqlConnection conn;
    public Text errores;
    void Start()
    {
        AdminMYSQL adminmysql = GameObject.Find("Administrador_de_bd").GetComponent<AdminMYSQL>();
        conn = adminmysql.ConectarConServidorBaseDatos();
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
        cmd.CommandText = "SELECT * FROM usuarios WHERE usuario = '"+usuario+"';";
        select2 = cmd.ExecuteReader();
        if (contraseña != "" && usuario != "")
        {
            if (select2.HasRows)
            {
                select2.Close();
                MySqlDataReader select3;
                cmd.CommandText = "SELECT * FROM usuarios WHERE contrasena = '" + contraseña + "';";
                select3 = cmd.ExecuteReader();
                if (select3.HasRows)
                {
                    select3.Close();
                    Debug.Log("si esta");
                    escena();
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
                string comando = "SELECT * FROM usuarios WHERE usuario = '" + usuario + "';";
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
                cmd.CommandText = "SELECT * FROM usuarios WHERE contrasena = '" + contraseña + "';";
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
                    cmd.CommandText = "insert into usuarios values (null,'" + usuario + "','" + contraseña + "');"; ;
                    cmd.ExecuteNonQuery();
                    

                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'ampicilina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'betanecol', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'clavulanato', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'cortisol', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'eritromicina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'ibuprofeno', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'levofloxacina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'metoclopramida', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'penicilina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'piperaclina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'prednisona', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'sulfazalazina', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'tazobactam', 0,'c');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'b12', 0,'h');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'dexametasona', 0,'h');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'hidroxicloroquin', 0,'h');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'metilprednisolona', 0,'h');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'sulfasalazina', 0,'h');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'amoxicilina', 0,'s');";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'aspirina', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'bortezomib', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'cloxacilina', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'lenalomida', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'paracetamol', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Personajes values ('" + usuario + "', 'vorinostat', 0,'s');"; 
                    cmd.ExecuteNonQuery();
                  
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
}

