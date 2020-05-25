using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

public class Archivos : MonoBehaviour
{
    BinaryFormatter fb;
    FileStream Informacion;
    DatosdeJuego Datos;
    String[] cantidades_formulas = new String[25];
    String[] cantidades_elementos = new String[11];
    int prueba;
    // Start is called before the first frame update
    void Start()
    {
        //   perro=GameObject.Find("Mapa_juego").GetComponent<variables_indestructibles>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void filetoarraybit()
    {
        /*  Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
          var data = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(Application.persistentDataPath + "/Partida.d"));
          Debug.Log(data);
          Informacion.Close();
          return System.Convert.ToBase64String(data);*/
    }
    public void Creararchivodebd(String readText)
    {

        /*    Informacion.Close();
          Debug.Log(readText);
             Informacion = File.Create(Application.persistentDataPath + "/Partida.d");
           File.WriteAllBytes(Application.persistentDataPath + "/Partida.d",Convert.FromBase64String(readText));
          byte[] data = Convert.FromBase64String(readText);
              readText = Encoding.UTF8.GetString(data);
              readText = System.Text.Encoding.Default.GetString(data);
              File.AppendAllText(Application.persistentDataPath + "/Partida.d", readText);*/


    }

    //crea un archivo con los siguientes elementos
    public void cargar_variables()
    {

        fb = new BinaryFormatter();

        Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");

        Datos = fb.Deserialize(Informacion) as DatosdeJuego;
        for (int x = 0; x < 3; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                variables_indestructibles.Elementos2[i, x] = Datos.Elementos2[i, x];
            }
        }
        for (int x = 0; x < 25; x++)
        {
            variables_indestructibles.Intentos_curas[x] = Datos.Intentos_curas[x];
        }
        variables_indestructibles.Usuario = Datos.Usuario;
        variables_indestructibles.monedas[0] = Datos.monedas[0];
        variables_indestructibles.level[0] = Datos.level[0];
        variables_indestructibles.bismuto = Datos.bismuto;
        variables_indestructibles.experiencia = Datos.experiencia;
        variables_indestructibles.nivel_organismo_jefes = Datos.nivel_organismo_jefes;
        variables_indestructibles.Sesion = Datos.sesion;
        variables_indestructibles.estructuracion = Datos.estructuracion;
        variables_indestructibles.finished = Datos.finished;
        variables_indestructibles.easter = Datos.easter;
        variables_indestructibles.Arenas = Datos.Arenas;
        variables_indestructibles.first = Datos.first;
        variables_indestructibles.mantenimient = Datos.mantenimient;
        variables_indestructibles.Tutorial = Datos.Tutorial;
        variables_indestructibles.Trophy = Datos.Trophy;
        variables_indestructibles.Skin = Datos.Skin;
        variables_indestructibles.TempTut = Datos.TempTut;
        for (int x = 0; x < 8; x++)
        {
            for (int i = 0; i < 25; i++)
            {
                variables_indestructibles.Personajes[i, x] = Datos.Personajes[i, x];
                if (variables_indestructibles.Personajes[i, x] == null)
                {
                    prueba = 1;
                    //Debug.Log("Personaje " + x.ToString() + " fila " + i.ToString());
                }
            }
        }

        for (int x = 0; x < 5; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                variables_indestructibles.Elementos[i, x] = Datos.Elementos[i, x];
                if (variables_indestructibles.Elementos[i, x] == null)
                {
                    prueba = 1;
                    //Debug.Log("Elemento " + x.ToString() + " fila " + i.ToString());
                    //Debug.Log(Datos.Elementos[i, x]);
                }
            }
        }
        //Debug.Log("entre2");
        //Debug.Log(Datos.Personajes[19, 2]);
        Informacion.Close();
        if (prueba == 1)
        {
            prueba = 0;
            Borrar();
            Crear();
        }

    }
    public void guardar_variables()
    {
        fb = new BinaryFormatter();
        Informacion = File.Create(Application.persistentDataPath + "/Partida.d");
        Datos = new DatosdeJuego();
        Datos.Usuario = variables_indestructibles.Usuario;
        Datos.monedas[0] = variables_indestructibles.monedas[0];
        Datos.level[0] = variables_indestructibles.level[0];
        Datos.bismuto = variables_indestructibles.bismuto;
        Datos.experiencia = variables_indestructibles.experiencia;
        Datos.nivel_organismo_jefes = variables_indestructibles.nivel_organismo_jefes;
        Datos.sesion = variables_indestructibles.Sesion;
        Datos.estructuracion = variables_indestructibles.estructuracion;
        Datos.finished = variables_indestructibles.finished;
        Datos.easter = variables_indestructibles.easter;
        Datos.Arenas = variables_indestructibles.Arenas;
        Datos.first = variables_indestructibles.first;
        Datos.mantenimient = variables_indestructibles.mantenimient;
        Datos.Tutorial = variables_indestructibles.Tutorial;
        Datos.Trophy = variables_indestructibles.Trophy;
        Datos.Skin = variables_indestructibles.Skin;
        Datos.TempTut = variables_indestructibles.TempTut;
        for (int x = 0; x < 25; x++)
        {
            Datos.Intentos_curas[x] = variables_indestructibles.Intentos_curas[x];
        }
        for (int x = 0; x < 8; x++)
        {
            for (int i = 0; i < 25; i++)
            {
                Datos.Personajes[i, x] = variables_indestructibles.Personajes[i, x];
            }
        }

        for (int x = 0; x < 5; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                Datos.Elementos[i, x] = variables_indestructibles.Elementos[i, x];
            }
        }
        for (int x = 0; x < 3; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                Datos.Elementos2[i, x] = variables_indestructibles.Elementos2[i, x];
            }
        }
        fb.Serialize(Informacion, Datos);
        Informacion.Close();
        //Debug.Log("Guardé funcion guardar");
    }
    public void Crear()
    {
        //Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            Debug.Log("Ya tienes un archivo we");
        }
        else
        {
            fb = new BinaryFormatter();
            Informacion = File.Create(Application.persistentDataPath + "/Partida.d");
            Datos = new DatosdeJuego();
            Datos.Usuario = "Daniel";
            //nombre Personaje
            Datos.Personajes[0, 0] = "aspirina";
            Datos.Personajes[1, 0] = "paracetamol";
            Datos.Personajes[2, 0] = "amoxicilina";
            Datos.Personajes[3, 0] = "cloxacilina";
            Datos.Personajes[4, 0] = "bortezomib";
            Datos.Personajes[5, 0] = "lenalidomida";
            Datos.Personajes[6, 0] = "vorinostat";
            Datos.Personajes[7, 0] = "clavulanato";
            Datos.Personajes[8, 0] = "penicilina";
            Datos.Personajes[9, 0] = "eritromicina";
            Datos.Personajes[10, 0] = "levofloxacino";
            Datos.Personajes[11, 0] = "betanecol";
            Datos.Personajes[12, 0] = "metoclopramida";
            Datos.Personajes[13, 0] = "ibuprofeno";
            Datos.Personajes[14, 0] = "sulfasalazina";
            Datos.Personajes[15, 0] = "prednisona";
            Datos.Personajes[16, 0] = "cortisol";
            Datos.Personajes[17, 0] = "ampicilina";
            Datos.Personajes[18, 0] = "piperacilina";
            Datos.Personajes[19, 0] = "tazobactam";
            Datos.Personajes[20, 0] = "metilprednisolona";
            Datos.Personajes[21, 0] = "hidroxicloroquina";
            Datos.Personajes[22, 0] = "h_sulfasalazina";
            Datos.Personajes[23, 0] = "dexametasona";
            Datos.Personajes[24, 0] = "vitamina b12";
            //Tipo
            Datos.Personajes[0, 1] = "easy";
            Datos.Personajes[1, 1] = "easy";
            Datos.Personajes[2, 1] = "easy";
            Datos.Personajes[3, 1] = "easy";
            Datos.Personajes[4, 1] = "easy";
            Datos.Personajes[5, 1] = "easy";
            Datos.Personajes[6, 1] = "easy";
            Datos.Personajes[7, 1] = "Complex";
            Datos.Personajes[8, 1] = "Complex";
            Datos.Personajes[9, 1] = "Complex";
            Datos.Personajes[10, 1] = "Complex";
            Datos.Personajes[11, 1] = "Complex";
            Datos.Personajes[12, 1] = "Complex";
            Datos.Personajes[13, 1] = "Complex";
            Datos.Personajes[14, 1] = "Complex";
            Datos.Personajes[15, 1] = "Complex";
            Datos.Personajes[16, 1] = "Complex";
            Datos.Personajes[17, 1] = "Complex";
            Datos.Personajes[18, 1] = "Complex";
            Datos.Personajes[19, 1] = "Complex";
            Datos.Personajes[20, 1] = "Hard";
            Datos.Personajes[21, 1] = "Hard";
            Datos.Personajes[22, 1] = "Hard";
            Datos.Personajes[23, 1] = "Hard";
            Datos.Personajes[24, 1] = "Hard";
            //Cantidad, todos deberían se 0
            Datos.Personajes[0, 2] = "5";
            Datos.Personajes[1, 2] = "5";
            Datos.Personajes[2, 2] = "5";
            Datos.Personajes[3, 2] = "5";
            Datos.Personajes[4, 2] = "5";
            Datos.Personajes[5, 2] = "5";
            Datos.Personajes[6, 2] = "1";
            Datos.Personajes[7, 2] = "1";
            Datos.Personajes[8, 2] = "1";
            Datos.Personajes[9, 2] = "1";
            Datos.Personajes[10, 2] = "1";
            Datos.Personajes[11, 2] = "100";
            Datos.Personajes[12, 2] = "100";
            Datos.Personajes[13, 2] = "100";
            Datos.Personajes[14, 2] = "100";
            Datos.Personajes[15, 2] = "100";
            Datos.Personajes[16, 2] = "100";
            Datos.Personajes[17, 2] = "100";
            Datos.Personajes[18, 2] = "100";
            Datos.Personajes[19, 2] = "100";
            Datos.Personajes[20, 2] = "100";
            Datos.Personajes[21, 2] = "100";
            Datos.Personajes[22, 2] = "100";
            Datos.Personajes[23, 2] = "100";
            Datos.Personajes[24, 2] = "100";
            //Descripciones
            Datos.Personajes[0, 3] = "Aspirina es el nombre de una marca que se popularizó. Es de gran ayuda contra el dolor, fiebre e inflamación";
            Datos.Personajes[1, 3] = "El paracetamol cuenta con propiedades analgésicas, ayuda también contra el dolor, ya sea leve o moderado, es bueno contra los malestares";
            Datos.Personajes[2, 3] = "Amoxicilina es un antibiótico derivado de la penicilina, es útil para combatir un gran número de espectros de bacterias, se utiliza mayormente para tratar infecciones";
            Datos.Personajes[3, 3] = "Es un antibiótico perteneciente al grupo de las penicilinas, útil para uso intramuscular";
            Datos.Personajes[4, 3] = "Antibiótico utilizado en monoterapia o en conjunto con otros para tratar el linfoma";
            Datos.Personajes[5, 3] = "Medicamento derivado de la talidomina, se ha empleado desde el año 2004 y es útil para tratar el mieloma múltiple y la leucemia";
            Datos.Personajes[6, 3] = "Vorinostato tiene cierta complejidad en cuanto a sus acciones inhibidoras, fue el primero en la historia en ser utilizado para el tratamiento de linfomas";
            Datos.Personajes[7, 3] = "Cluvalanato es un antibiótico que realiza un buen trabajo colaborativo con otros fármacos, en conjunto para bajar la resistencia de bacterias";
            Datos.Personajes[8, 3] = "La Penicilina pertenece al grupo de antibióticos que combaten las infecciones, es de los primeros medicamentos en la historia que se vienen utilizando contra este tipo de tratamiento";
            Datos.Personajes[9, 3] = "La Eritromicina nos será de gran ayuda para impedir que las proteínas en las bacterias se desarrollen, éste compuesto fue encontrado por primera vez en los suelos del archipiélago de las Filipinas";
            Datos.Personajes[10, 3] = "Es considerado un antibiótico de amplio espectro, capaz de inhibir el enzima ADN girasa";
            Datos.Personajes[11, 3] = "Antibiótico útil a la hora de impedir la sintesis de proteínas en las bacterias. Sirve de gran ayuda para mejorar el vaciamiento gástrico";
            Datos.Personajes[12, 3] = "Se utiliza comúnmente para tratar la náusea y vómito y facilitar el vaciamiento gástrico";
            Datos.Personajes[13, 3] = "Es un antibiótico antiinflamatorio, se utiliza para el alivio sintomático del dolor, irritación y molestia en general";
            Datos.Personajes[14, 3] = "Se utiliza principalmente como agente antiinflamatorio en el tratamiento de la enfermedad inflamatoria intestinal";
            Datos.Personajes[15, 3] = "Es un fármaco sintético que se toma generalmente de forma oral, es usado para un gran número de afecciones como la colitis ulcerosa de manera moderada a grave";
            Datos.Personajes[16, 3] = "Es una hormona, cuya principal función es la de incrementar los niveles de azúcar en la sangre y ayudar al metabolismo de las grasas, proteínas y carbohidratos";
            Datos.Personajes[17, 3] = "Es un antibiótico que se ha usado a lo largo de la historia para tratar infecciones bacterianas";
            Datos.Personajes[18, 3] = "Perteneciente al grupo de los antibióticos betalactámicos, éste particular grupo se encarga de bajar la resistencia de agentes bacterianos, útil para la erradicación de acumulaciones sólidas de bilis";
            Datos.Personajes[19, 3] = "Al igual que la Piperacilina, es un agente que debilita la resistencia antimicrobiana de las bacterias. Lo que destaca de éste medicamento es su capacidad de añadirse a otros medicamentos y se presenta generalmente en forma de sal de sodio";
            Datos.Personajes[20, 3] = "Se utiliza en medicina por sus propiedades inmunosupresoras y antiinflamatorias. Por lo que resulta de gran utilidad ante casos de inflamación, hinchazón, calor, enrojecimiento y dolor";
            Datos.Personajes[21, 3] = "Se utiliza para reducir la inflamación en el tratamiento de la artritis reumatoide y del Lupus. Se diferencia de la cloroquina por la presencia de un grupo hidroxilo en el extremo de la cadena lateral";
            Datos.Personajes[22, 3] = "Se utiliza principalmente como agente antiinflamatorio en el tratamiento de la enfermedad inflamatoria intestinal y el artritis reumatoide";
            Datos.Personajes[23, 3] = "Actúa como antiinflamatorio e inmunosupresor";
            Datos.Personajes[24, 3] = "También se le llama cobalamina gracias a que tiene un elemento muy especial, el cual es el cobalto. Ésta es una vitamina muy importante para el funcionamiento normal del sistema nervioso y de varias proteínas";
            //Estructuracion
            Datos.Personajes[0, 4] = "C9H8O4";
            Datos.Personajes[1, 4] = "C8H9NO2";
            Datos.Personajes[2, 4] = "C16H19N3O5S";
            Datos.Personajes[3, 4] = "C19H18N3ClO5S";
            Datos.Personajes[4, 4] = "C19H25N4O4B";
            Datos.Personajes[5, 4] = "C13H13N3O3";
            Datos.Personajes[6, 4] = "C14H20N2O3";
            Datos.Personajes[7, 4] = "C8H9NO5";
            Datos.Personajes[8, 4] = "C16H18N2O4S";
            Datos.Personajes[9, 4] = "C37H67NO13";
            Datos.Personajes[10, 4] = "C18H20N3FO4";
            Datos.Personajes[11, 4] = "C7H17N2O2";
            Datos.Personajes[12, 4] = "C14H22N3ClO2";
            Datos.Personajes[13, 4] = "C13H18O2";
            Datos.Personajes[14, 4] = "C18H14N4O5S";
            Datos.Personajes[15, 4] = "C21H26O5";
            Datos.Personajes[16, 4] = "C21H30O5";
            Datos.Personajes[17, 4] = "C16H19N3O4S";
            Datos.Personajes[18, 4] = "C23H27N5O7S";
            Datos.Personajes[19, 4] = "C10H12N4O5S";
            Datos.Personajes[20, 4] = "C22H30O5";
            Datos.Personajes[21, 4] = "C18H26ClN3O";
            Datos.Personajes[22, 4] = "C18H14N4O5S";
            Datos.Personajes[23, 4] = "C22H29FO5";
            Datos.Personajes[24, 4] = "C63H88CoN14O14P";
            //Costo
            Datos.Personajes[0, 5] = "15000";
            Datos.Personajes[1, 5] = "15000";
            Datos.Personajes[2, 5] = "30000";
            Datos.Personajes[3, 5] = "30000";
            //intercambio
            Datos.Personajes[4, 5] = "50";
            Datos.Personajes[5, 5] = "250";
            Datos.Personajes[6, 5] = "500 1Bi";
            for (int i = 7; i <= 24; i++)
            {
                Datos.Personajes[i, 5] = "";
            }
            //Numero de entrenamiento 
            Datos.Personajes[0, 6] = "1";
            Datos.Personajes[1, 6] = "0";
            Datos.Personajes[2, 6] = "0";
            Datos.Personajes[3, 6] = "0";
            Datos.Personajes[4, 6] = "0";
            Datos.Personajes[5, 6] = "0";
            Datos.Personajes[6, 6] = "0";
            Datos.Personajes[7, 6] = "0";
            Datos.Personajes[8, 6] = "0";
            Datos.Personajes[9, 6] = "0";
            Datos.Personajes[10, 6] = "0";
            Datos.Personajes[11, 6] = "0";
            Datos.Personajes[12, 6] = "0";
            Datos.Personajes[13, 6] = "0";
            Datos.Personajes[14, 6] = "0";
            Datos.Personajes[15, 6] = "0";
            Datos.Personajes[16, 6] = "0";
            Datos.Personajes[17, 6] = "0";
            Datos.Personajes[18, 6] = "0";
            Datos.Personajes[19, 6] = "0";
            Datos.Personajes[20, 6] = "0";
            Datos.Personajes[21, 6] = "0";
            Datos.Personajes[22, 6] = "0";
            Datos.Personajes[23, 6] = "0";
            Datos.Personajes[24, 6] = "0";
            //Puntos de vida de los personajes
            for (int e = 0; e < 7; e++)
            {
                Datos.Personajes[e, 7] = "125000";
            }
            for (int a = 7; a < 20; a++)
            {
                Datos.Personajes[a, 7] = "450000";
            }
            for (int o = 20; o < 25; o++)
            {
                Datos.Personajes[o, 7] = "900000";
            }
            //Nombre Elemento
            Datos.Elementos[0, 0] = "Carbono";
            Datos.Elementos[1, 0] = "Hidrogeno";
            Datos.Elementos[2, 0] = "Oxigeno";
            Datos.Elementos[3, 0] = "Nitrogeno";
            Datos.Elementos[4, 0] = "Boro";
            Datos.Elementos[5, 0] = "Azufre";
            Datos.Elementos[6, 0] = "Radio";
            Datos.Elementos[7, 0] = "Fluor";
            Datos.Elementos[8, 0] = "Cloro";
            Datos.Elementos[9, 0] = "Cobalto";
            Datos.Elementos[10, 0] = "Fosforo";
            //Cantidad Elemento
            Datos.Elementos[0, 1] = "5"; //Deben ser 9
            Datos.Elementos[1, 1] = "5"; //Deben ser 8
            Datos.Elementos[2, 1] = "5"; //Deben ser 4
            Datos.Elementos[3, 1] = "5"; //Las demás deben ser 0
            Datos.Elementos[4, 1] = "5";
            Datos.Elementos[5, 1] = "5";
            Datos.Elementos[6, 1] = "5";
            Datos.Elementos[7, 1] = "5";
            Datos.Elementos[8, 1] = "4";
            Datos.Elementos[9, 1] = "5";
            Datos.Elementos[10, 1] = "5";
            //Descripcion Elemento
            Datos.Elementos[0, 2] = "Es un no metal sólido que es el componente fundamental de los compuestos orgánicos y tiene la propiedad de enlazarse con otros átomos de carbono y otras sustancias para formar un número casi infinito de compuestos.";
            Datos.Elementos[1, 2] = "Es un gas incoloro, inodoro y muy reactivo que se halla en todos los componentes de la materia viva y en muchos minerales, siendo el elemento más abundante en el universo.";
            Datos.Elementos[2, 2] = "El oxígeno es un elemento clave de la química orgánica, al forma parte del agua (H2O)strong>, de los óxidos, de los seres vivos y de casi todos los ácidos y sustancias orgánicas.";
            Datos.Elementos[3, 2] = "Es un gas incoloro, inodoro e inerte, compone cuatro quintos del volumen del aire de la atmósfera y se usa para sintetizar amoníaco y otros productos.";
            Datos.Elementos[4, 2] = "Es un elemento metaloide, semiconductor, trivalente que existe abundantemente en el mineral bórax.";
            Datos.Elementos[5, 2] = "Es un no metal de color amarillo pálido y olor desagradable, que se encuentra en la naturaleza tanto en forma libre como combinado con otros elementos";
            Datos.Elementos[6, 2] = "El radio es un alcalinotérreo que se encuentra a nivel de trazas en minas de uranio. Es extremadamente radiactivo, un millón de veces más que el uranio.";
            Datos.Elementos[7, 2] = "Es un gas a temperatura ambiente, de color verde pálido, formado por moléculas diatómicas F₂. Es el más electronegativo y reactivo de todos los elementos.";
            Datos.Elementos[8, 2] = "El cloro existe como un gas amarillo-verdoso a temperaturas y presiones ordinarias. Es el segundo en reactividad entre los halógenos, sólo después del flúor, y de aquí que se encuentre libre en la naturaleza sólo a las temperaturas elevadas de los gases volcánicos.";
            Datos.Elementos[9, 2] = "El cobalto es un metal ferromagnético, de color blanco azulado. Su temperatura de Curie es de 1388 K. Normalmente se encuentra junto con níquel, y ambos suelen formar parte de los meteoritos de hierro.";
            Datos.Elementos[10, 2] = "Es un no metal multivalente perteneciente al grupo del nitrógeno que se encuentra en la naturaleza combinado en fosfatos inorgánicos y en organismos vivos pero nunca en estado fundamental.";
            //Costo elemento
            Datos.Elementos[0, 3] = "100";
            Datos.Elementos[1, 3] = "100";
            Datos.Elementos[2, 3] = "100";
            Datos.Elementos[3, 3] = "100";
            Datos.Elementos[4, 3] = "100";
            Datos.Elementos[5, 3] = "500";
            Datos.Elementos[6, 3] = "15000";
            Datos.Elementos[7, 3] = "15000";
            Datos.Elementos[8, 3] = "25000";
            Datos.Elementos[9, 3] = "50000";
            Datos.Elementos[10, 3] = "50000";
            //Sigla
            Datos.Elementos[0, 4] = "C";
            Datos.Elementos[1, 4] = "H";
            Datos.Elementos[2, 4] = "O";
            Datos.Elementos[3, 4] = "N";
            Datos.Elementos[4, 4] = "B";
            Datos.Elementos[5, 4] = "S";
            Datos.Elementos[6, 4] = "Ra";
            Datos.Elementos[7, 4] = "F";
            Datos.Elementos[8, 4] = "Cl";
            Datos.Elementos[9, 4] = "Co";
            Datos.Elementos[10, 4] = "P";

            Datos.easter = "false";//Debe ser false
            Datos.Arenas = "false";//Debe ser false
            Datos.finished = "false";//Debe ser false
            Datos.first = "false";//Debe ser true
            Datos.monedas[0] = "40000";//Debe ser 40000
            Datos.bismuto = "99"; //Debe ser 0
            Datos.level[0] = "20"; //Debe ser 1
            Datos.experiencia = "266300"; //Debe ser 0, 
            Datos.nivel_organismo_jefes = "2"; //Debe ser 1
            Datos.sesion = "";
            Datos.estructuracion = "";
            Datos.mantenimient = "0";
            Datos.Tutorial = "7";//Debe ser 0, para no ver ninguno poner valor arriba de 9
            Datos.Trophy = "false";//Debe ser false
            Datos.Skin = "false";//Debe ser false
            Datos.TempTut = "false";//No sirve para nada
            for (int x = 0; x < 3; x++)
            {
                for (int i = 0; i < 11; i++)
                {
                    Datos.Elementos2[i, x] = "";
                }
            }
            for (int x = 0; x < 25; x++)
            {
                Datos.Intentos_curas[x] = "0";
            }
            fb.Serialize(Informacion, Datos);
            Informacion.Close();
            Debug.Log("Guardé ");
        }
    }
    //mete los datos dentro del archivo

    //funciones de cargar{

    //funcion para cargar datos de la tienda{
    public void Cargar_Tienda(String[,] Personajes, String[,] Elementos)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            Debug.Log(Application.persistentDataPath);

            for (int x = 0; x < 7; x++)
            {
                for (int i = 0; i < 25; i++)
                {
                    Personajes[i, x] = Datos.Personajes[i, x];
                }
            }

            for (int x = 0; x < 5; x++)
            {
                for (int i = 0; i < 11; i++)
                {
                    Elementos[i, x] = Datos.Elementos[i, x];
                }
            }
            Informacion.Close();
        }
    }

    public String carga_monedas(String mon)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            mon = Datos.monedas[0];
            Informacion.Close();
            return mon;

        }
        return "";
    }
    public String carga_level(String lev)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            lev = Datos.level[0];
            Informacion.Close();
            return lev;
        }
        return "";
    }
    public String carga_bismuto(String bismuto)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            bismuto = Datos.bismuto;
            Informacion.Close();
            return bismuto;
        }
        return "";
    }
    //}
    //funcion para cargar datos en la escena del almacen
    public void Cargar_Almacen(String Usuario, String[,] Personajes)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            //texto = Datos.Text;
            Usuario = Datos.Usuario;
            for (int x = 0; x < 5; x++)
            {
                for (int i = 0; i < 25; i++)
                {
                    Personajes[i, x] = Datos.Personajes[i, x];
                }
            }
            Informacion.Close();
        }
    }
    //}
    public void Cargar_Laboratorio(String[,] Elementos)
    {
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {

            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            for (int x = 0; x < 5; x++)
            {
                for (int i = 0; i < 11; i++)
                {
                    Elementos[i, x] = Datos.Elementos[i, x];
                }
            }
            Informacion.Close();
        }
    }
    //}
    //borra el archivo existente con el nombre Datos.d
    public void Borrar()
    {

        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            File.Delete(Application.persistentDataPath + "/Partida.d");
        }
        else
        {
            Debug.Log("nada que borrar");
        }
    }
}
//son las variables que tiene el archivo
[Serializable()]
class DatosdeJuego : System.Object
{
    public String Usuario;
    public String[] level = new String[1];
    public String[] monedas = new String[1];
    public String[,] Personajes = new String[25, 8];
    public String[,] Elementos = new String[11, 5];
    public String bismuto;
    public String experiencia;
    public String nivel_organismo_jefes;
    public String sesion;
    public String estructuracion;
    public String[,] Elementos2 = new String[11, 3];
    public String finished;
    public String Arenas;
    public String easter;
    public String first;
    public String[] Intentos_curas = new String[25];
    public String mantenimient;
    public String Tutorial;
    public String Trophy;
    public String Skin;
    public String TempTut;
}