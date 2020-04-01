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
    public GameObject menu_principal, panel_registro, panel_iniciosesion, soundtrack,Borrar_datos,Cargar_datos,Guardar_datos,Cerrar_sesion;
    public InputField Inputfield_usuario, Inputfield_contraseña, Inputfield_conf_contraseña, Inputfield_ini_us, Inputfield_ini_con;
    public MySqlConnection conn;
    public Text errores;
    public Text  user_loged;
    string usuario;
    int id_user = 0;
  //  String bitmap2;
    Archivos archiv;
    void Start()
    {
        AdminMYSQL adminmysql = GameObject.Find("Administrador_de_bd").GetComponent<AdminMYSQL>();
        conn = adminmysql.ConectarConServidorBaseDatos();
        archiv = GameObject.Find("Administrador_de_bd").GetComponent<Archivos>();
        archiv.Crear();
        archiv.cargar_variables();
        if (variables_indestructibles.Sesion.Equals(""))
        {
            user_loged.text = "no user loged";
            Borrar_datos.SetActive(false);
            Cargar_datos.SetActive(false);
            Guardar_datos.SetActive(false);
            Cerrar_sesion.SetActive(false);
        }
        else
        {
            string comando = "SELECT nombre_usuario FROM usuario WHERE nombre_usuario = '" + usuario + "';";
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            MySqlDataReader select111;
            cmd.CommandText = "SELECT id_usuario FROM usuario WHERE nombre_usuario = '" + variables_indestructibles.Sesion + "';";
            select111 = cmd.ExecuteReader();
            if (select111.HasRows)
            {
                while (select111.Read())
                {
                    id_user = Int32.Parse(select111["id_usuario"].ToString());
                    Debug.Log(id_user.ToString());

                }
            }
            select111.Close();
            user_loged.text = variables_indestructibles.Sesion;
            Borrar_datos.SetActive(true);
            Cargar_datos.SetActive(true);
            Guardar_datos.SetActive(true);
            Cerrar_sesion.SetActive(true);
        }
    //    bitmap2 = archiv.filetoarraybit();
        /*ThreadStart delegado = new ThreadStart(CorrerProceso); 
        Thread hilo = new Thread(delegado); 
        hilo.Start();
        soundtrack.GetComponent<AudioSource>().Play();*/
    }
    // MENU
    void Update()
    {
    
    }
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
    public void CerrarS()
    {
        variables_indestructibles.Sesion = "";
        archiv.guardar_variables();
        Borrar_datos.SetActive(false);
        Cargar_datos.SetActive(false);
        Guardar_datos.SetActive(false);
        Cerrar_sesion.SetActive(false);
        user_loged.text = "no user loged";
    }
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
                    while (select3.Read())
                    {
                        id_user = Int32.Parse(select3["id_usuario"].ToString());
                    }
                    select3.Close();
                    Debug.Log("si esta");
                    user_loged.text = usuario;
                    panel_iniciosesion.SetActive(false);
                    menu_principal.SetActive(true);
                    Borrar_datos.SetActive(true);
                    Cargar_datos.SetActive(true);
                    Guardar_datos.SetActive(true);
                    Cerrar_sesion.SetActive(true);
                    variables_indestructibles.Sesion = usuario;
                    archiv.guardar_variables();
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
        string  contraseña, conf_contraseña;
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
                        cmd.CommandText = "insert into personaje values ( 0," + id_user + ", '" + variables_indestructibles.Personajes[i, 0] + "',1,1);";
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "insert into estadisticas values ( 0," + id_user + ",1,0,0,0,1,0);";
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < 11; i++)
                    {
                        cmd.CommandText = "insert into elementos values ( 0," + id_user + ",'" + variables_indestructibles.Elementos[i, 0] + "',0);";
                        cmd.ExecuteNonQuery();
                    }
                    panel_registro.SetActive(false);
                    menu_principal.SetActive(true);
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
    public void outdb_user_progre()
    {
        string comando = "UPDATE  personaje SET entrenamiento=1, cantidad=0 where usuario = " + id_user + ";";
        String cant, entrne;
        MySqlCommand cmd = new MySqlCommand(comando, conn);
        MySqlDataReader select;
        cmd.CommandText = "SELECT id_usuario FROM usuario WHERE nombre_usuario = '" + usuario + "';";
        select = cmd.ExecuteReader();
        if (select.HasRows)
        {
            while (select.Read())
            {
                id_user = Int32.Parse(select["id_usuario"].ToString());
                Debug.Log(id_user.ToString());

            }
        }
        select.Close();
        MySqlDataReader select2;
        cmd.CommandText = "SELECT entrenamiento, cantidad FROM personaje WHERE usuario= '" + id_user + "';";
        select2 = cmd.ExecuteReader();
        if (select2.HasRows)
        {
            int i = 0;
                while(select2.Read()){

                   variables_indestructibles.Personajes[i,6]=select2["entrenamiento"].ToString();
 
                    variables_indestructibles.Personajes[i, 2] = select2["cantidad"].ToString();
                i++;
            }
        }
        select2.Close();
        MySqlDataReader select3;
        cmd.CommandText = "SELECT nivel,experiencia,monedas,bismuto,jefe FROM estadisticas WHERE usuario= '" + id_user + "';";
        select3 = cmd.ExecuteReader();
             if (select3.HasRows)
        {
         while (select3.Read()){
                variables_indestructibles.level[0] = select3["nivel"].ToString();
  
                variables_indestructibles.experiencia = select3["experiencia"].ToString();
            
                variables_indestructibles.monedas[0] = select3["monedas"].ToString();
            
                variables_indestructibles.bismuto = select3["bismuto"].ToString();
            
                variables_indestructibles.nivel_organismo_jefes = select3["jefe"].ToString();
            
        }
        }
        select3.Close();
                MySqlDataReader select4;
        cmd.CommandText = "SELECT cantidad_elemento FROM elementos WHERE usuario= '" + id_user + "';";
        select4 = cmd.ExecuteReader();
        if (select4.HasRows)
        {
            int i = 0;
            while(select4.Read())
            {
                variables_indestructibles.Elementos[i, 1] = select4["cantidad_elemento"].ToString();
                i++;
            }
        }
        select4.Close();
        archiv.guardar_variables();

    }
    public void save_user_progre()
    {
        string comando = "UPDATE  personaje SET entrenamiento=1, cantidad=0 where usuario = " + id_user + ";";
        MySqlCommand cmd = new MySqlCommand(comando, conn);
        for (int i = 0; i < 25; i++)
        {
            cmd.CommandText = "UPDATE  personaje SET entrenamiento=" + variables_indestructibles.Personajes[i, 6] + ", cantidad=" + variables_indestructibles.Personajes[i, 2] + " where usuario = " + id_user + " and nombre='" + variables_indestructibles.Personajes[i, 0] + "';";
            cmd.ExecuteNonQuery();
        }
        cmd.CommandText = "UPDATE estadisticas SET nivel="+variables_indestructibles.level[0]+", experiencia=" + variables_indestructibles.experiencia + ", monedas="+variables_indestructibles.monedas[0]+", bismuto="+variables_indestructibles.bismuto+", jefe="+variables_indestructibles.nivel_organismo_jefes+", laboratorio=0  where usuario = " + id_user + ";";
        cmd.ExecuteNonQuery();
        for (int i = 0; i < 11; i++)
        {
            cmd.CommandText = "UPDATE elementos SET cantidad_elemento="+variables_indestructibles.Elementos[i,1]+"  where usuario = " + id_user + "  and nombre_elemento='" + variables_indestructibles.Elementos[i, 0] + "';";
            cmd.ExecuteNonQuery();
        }
    }
    public void delete_user_progre()
    {
                string comando = "UPDATE  personaje SET entrenamiento=1, cantidad=0 where usuario = " + id_user + ";";
                MySqlCommand cmd = new MySqlCommand(comando, conn);            
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE estadisticas SET nivel=1, experiencia=0, monedas=0, bismuto=0, jefe=1, laboratorio=0  where usuario = " + id_user + ";";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE elementos SET cantidad_elemento=0  where usuario = " + id_user + ";";
                cmd.ExecuteNonQuery();
            
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