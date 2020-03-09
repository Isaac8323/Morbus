using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
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
    //crea un archivo con los siguientes elementos
    public void cargar_variables()
    {
        fb = new BinaryFormatter();

        File.Delete(Application.persistentDataPath + "/Partida.d");
        Crear();

        Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");

        Datos = fb.Deserialize(Informacion) as DatosdeJuego;
        variables_indestructibles.Usuario = Datos.Usuario;
        variables_indestructibles.monedas[0] = Datos.monedas[0];
        variables_indestructibles.level[0] = Datos.level[0];
        variables_indestructibles.bismuto = Datos.bismuto;
        for (int x = 0; x < 7; x++)
        {
            for (int i = 0; i < 25; i++)
            {
                variables_indestructibles.Personajes[i, x] = Datos.Personajes[i, x];
                if (variables_indestructibles.Personajes[i, x] == null)
                {
                    prueba = 1;
                    Debug.Log("Personaje " + x.ToString() + " fila " + i.ToString());
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
                    Debug.Log("Elemento " + x.ToString() + " fila " + i.ToString());
                    Debug.Log(Datos.Elementos[i, x]);
                }
            }
        }
        Debug.Log("entre2");
        Debug.Log(Datos.Personajes[19, 2]);
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
        for (int x = 0; x < 7; x++)
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
        fb.Serialize(Informacion, Datos);
        Informacion.Close();
        Debug.Log("Guardé funcion guardar");
    }
    public void Crear()
    {
        Debug.Log(Application.persistentDataPath);
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
            Datos.Personajes[24, 0] = "vitamina B12";
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
            //Cantidad
            Datos.Personajes[0, 2] = "0";
            Datos.Personajes[1, 2] = "0";
            Datos.Personajes[2, 2] = "0";
            Datos.Personajes[3, 2] = "0";
            Datos.Personajes[4, 2] = "0";
            Datos.Personajes[5, 2] = "5";
            Datos.Personajes[6, 2] = "100";
            Datos.Personajes[7, 2] = "100";
            Datos.Personajes[8, 2] = "500";
            Datos.Personajes[9, 2] = "100";
            Datos.Personajes[10, 2] = "100";
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
            Datos.Personajes[11, 4] = "C37H67NO12";
            Datos.Personajes[12, 4] = "C14H22N3ClO2";
            Datos.Personajes[13, 4] = "C13H18O2";
            Datos.Personajes[14, 4] = "C18H14N4O5S";
            Datos.Personajes[15, 4] = "C21H26O5";
            Datos.Personajes[16, 4] = "C21H30O5";
            Datos.Personajes[17, 4] = "C16H18N3O4S";
            Datos.Personajes[18, 4] = "C23H26N5O7S";
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
            Datos.Personajes[1, 6] = "1";
            Datos.Personajes[2, 6] = "1";
            Datos.Personajes[3, 6] = "1";
            Datos.Personajes[4, 6] = "1";
            Datos.Personajes[5, 6] = "1";
            Datos.Personajes[6, 6] = "1";
            Datos.Personajes[7, 6] = "1";
            Datos.Personajes[8, 6] = "1";
            Datos.Personajes[9, 6] = "1";
            Datos.Personajes[10, 6] = "1";
            Datos.Personajes[11, 6] = "1";
            Datos.Personajes[12, 6] = "1";
            Datos.Personajes[13, 6] = "1";
            Datos.Personajes[14, 6] = "1";
            Datos.Personajes[15, 6] = "1";
            Datos.Personajes[16, 6] = "1";
            Datos.Personajes[17, 6] = "1";
            Datos.Personajes[18, 6] = "1";
            Datos.Personajes[19, 6] = "1";
            Datos.Personajes[20, 6] = "1";
            Datos.Personajes[21, 6] = "1";
            Datos.Personajes[22, 6] = "1";
            Datos.Personajes[23, 6] = "1";
            Datos.Personajes[24, 6] = "1";
            //Puntos de vida de los personajes
            for(int e = 0; e <= 7; e++)
            {
                Datos.Personajes[e, 7] = "125000";
            }
            for(int a = 8; a <= 20; a++)
            {
                Datos.Personajes[a, 7] = "450000";
            }
            for(int o = 21; o <= 24; o++)
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
            Datos.Elementos[0, 1] = "100";
            Datos.Elementos[1, 1] = "100";
            Datos.Elementos[2, 1] = "100";
            Datos.Elementos[3, 1] = "100";
            Datos.Elementos[4, 1] = "100";
            Datos.Elementos[5, 1] = "100";
            Datos.Elementos[6, 1] = "100";
            Datos.Elementos[7, 1] = "100";
            Datos.Elementos[8, 1] = "100";
            Datos.Elementos[9, 1] = "100";
            Datos.Elementos[10, 1] = "100";
            //Descripcion Elemento
            Datos.Elementos[0, 2] = "elemntin1";
            Datos.Elementos[1, 2] = "elemntin2";
            Datos.Elementos[2, 2] = "elemntin3";
            Datos.Elementos[3, 2] = "elemntin4";
            Datos.Elementos[4, 2] = "elemntin5";
            Datos.Elementos[5, 2] = "elemntin6";
            Datos.Elementos[6, 2] = "elemntin7";
            Datos.Elementos[7, 2] = "elemntin8";
            Datos.Elementos[8, 2] = "elemntin9";
            Datos.Elementos[9, 2] = "elemntin10";
            Datos.Elementos[10, 2] = "elementin11";
            //Costo elemento
            Datos.Elementos[0, 3] = "100";
            Datos.Elementos[1, 3] = "100";
            Datos.Elementos[2, 3] = "100";
            Datos.Elementos[3, 3] = "100";
            Datos.Elementos[5, 3] = "500";
            Datos.Elementos[6, 3] = "15000";
            Datos.Elementos[7, 3] = "15000";
            Datos.Elementos[8, 3] = "25000";
            Datos.Elementos[9, 3] = "50000";
            Datos.Elementos[10, 3] = "50000";
            Datos.Elementos[4, 3] = "100";
            //Sigla
            Datos.Elementos[0, 4] = "C";
            Datos.Elementos[1, 4] = "H";
            Datos.Elementos[2, 4] = "O";
            Datos.Elementos[3, 4] = "N";
            Datos.Elementos[5, 4] = "S";
            Datos.Elementos[6, 4] = "Ra";
            Datos.Elementos[7, 4] = "F";
            Datos.Elementos[8, 4] = "Cl";
            Datos.Elementos[9, 4] = "Co";
            Datos.Elementos[10, 4] = "P";
            Datos.Elementos[4, 4] = "B";
            //Nombres de los jefes
            Datos.Jefes[0, 0] = "Cefalea";
            Datos.Jefes[1, 0] = "Adenopatia";
            Datos.Jefes[2, 0] = "Linfedema";
            Datos.Jefes[3, 0] = "Linfangitis";
            Datos.Jefes[4, 0] = "Linfoma";
            Datos.Jefes[5, 0] = "Rinosinusitis";
            Datos.Jefes[6, 0] = "F-Amigdalitis";
            Datos.Jefes[7, 0] = "Difteria";
            Datos.Jefes[8, 0] = "Bronquitis";
            Datos.Jefes[9, 0] = "ERGE";
            Datos.Jefes[10, 0] = "Hemorroides";
            Datos.Jefes[11, 0] = "Colitis. U.";
            Datos.Jefes[12, 0] = "Calculos. B.";
            Datos.Jefes[13, 0] = "L. E. S.";
            Datos.Jefes[14, 0] = "Artritis. R.";
            Datos.Jefes[15, 0] = "Esclerosis M.";
            Datos.Jefes[16, 0] = "Anemia P.";
            //Descripción de los jefes
            Datos.Jefes[0, 1] = "Dolor de cabeza intenso y persistente que va acompañado de sensación de pesadez. Las cefaleas pueden estar relacionadas con la tensión nerviosa.";
            Datos.Jefes[1, 1] = "Glándulas del sistema inmunológico que, por lo general, se agrandan en respuesta a una infección bacteriana o viral.";
            Datos.Jefes[2, 1] = "Inflamación en un brazo o una pierna ocasionada por una obstrucción del sistema linfático.";
            Datos.Jefes[3, 1] = "La linfangitis es una inflamación de los canales linfáticos que ocurre como resultado de una infección en un sitio distal del canal.";
            Datos.Jefes[4, 1] = "El linfoma es un tipo de cáncer del sistema linfático, que es parte de la red del organismo que combate los gérmenes.";
            Datos.Jefes[5, 1] = "La rinosinusitis es una inflamación de las fosas nasales y de los senos paranasales caracterizada por el bloqueo, la obstrucción y/o la congestión nasal sumado a la secreción nasal o rinorrea que puede drenar por la parte anterior o posterior de la nariz.";
            Datos.Jefes[6, 1] = "La faringoamigdalitis es la infección aguda de la faringe o las amígdalas palatinas.";
            Datos.Jefes[7, 1] = "Enfermedad infecciosa aguda, provocada por un bacilo, que afecta a la nariz, la garganta y la laringe y produce fiebre y dificultad para respirar.";
            Datos.Jefes[8, 1] = "Inflamación del revestimiento de los conductos bronquiales que transportan el aire dentro y fuera de los pulmones.";
            Datos.Jefes[9, 1] = "La enfermedad por reflujo gastroesofágico (ERGE) es una afección en la cual los contenidos estomacales se devuelven desde el estómago hacia el esófago (tubo de deglución).";
            Datos.Jefes[10, 1] = "Las hemorroides, también llamadas almorranas, son venas hinchadas en el ano y la parte inferior del recto, similares a las venas varicosas.";
            Datos.Jefes[11, 1] = "La colitis ulcerosa es una enfermedad inflamatoria del colon (el intestino grueso) y del recto.";
            Datos.Jefes[12, 1] = "Los cálculos biliares son acumulaciones sólidas de bilis cristalizada que es producida en el hígado, guardada en la vesícula biliar y secretada hacia el intestino a través de los ductos biliares para ayudar a digerir las grasas.";
            Datos.Jefes[13, 1] = "El lupus eritematoso sistémico (LES) es una enfermedad autoinmunitaria. En esta enfermedad, el sistema inmunitario del cuerpo ataca por error el tejido sano. Este puede afectar la piel, las articulaciones, los riñones, el cerebro y otros órganos.";
            Datos.Jefes[14, 1] = "La artritis reumatoide es una forma de artritis que causa dolor, inflamación, rigidez y pérdida de la función de las articulaciones. Puede afectar cualquier articulación, pero es común en las muñecas y los dedos.";
            Datos.Jefes[15, 1] = "Esclerosis múltiple (o esclerosis en placas) Enfermedad progresiva del sistema nervioso central que provoca lesiones múltiples en la mielina que recubre los axones de las neuronas y constituye la sustancia blanca, en forma de placas diseminadas; se manifiesta con diversos síntomas como la parálisis de las extremidades inferiores, hormigueo, pérdida de la sensibilidad, etc.";
            Datos.Jefes[16, 1] = "La anemia es una afección en la cual el cuerpo no tiene suficientes glóbulos rojos, los cuales le suministran el oxígeno a los tejidos corporales. Hay muchos tipos de anemia. La anemia perniciosa es una disminución en los glóbulos rojos que ocurre cuando los intestinos no pueden absorber apropiadamente la vitamina B12.";
            //Puntos de vida iniciales de los jefes
            Datos.Jefes[0, 2] = "25000";
            Datos.Jefes[1, 2] = "150000";
            Datos.Jefes[2, 2] = "200000";
            Datos.Jefes[3, 2] = "250000";
            Datos.Jefes[4, 2] = "300000";
            Datos.Jefes[5, 2] = "400000";
            Datos.Jefes[6, 2] = "575000";
            Datos.Jefes[7, 2] = "650000";
            Datos.Jefes[8, 2] = "725000";
            Datos.Jefes[9, 2] = "850000";
            Datos.Jefes[9, 2] = "975000";
            Datos.Jefes[10, 2] = "1100000";
            Datos.Jefes[11, 2] = "1225000";
            Datos.Jefes[12, 2] = "1450000";
            Datos.Jefes[13, 2] = "1675000";
            Datos.Jefes[14, 2] = "1900000";
            Datos.Jefes[15, 2] = "2500000";

            Datos.monedas[0] = "15000";
            Datos.bismuto = "3";
            Datos.level[0] = "3";
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

    //Función que carga la vida inicial de los personajes en combate
    public int HealthPoints(int index)
    {
        int life = 0;
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            Debug.Log(Application.persistentDataPath);

            life = Convert.ToInt32(Datos.Personajes[index, 7]);
            Informacion.Close();
            Debug.Log(life);
            return life;
        }
        return life;
    }

    //Función que carga la vida inicial del jefe en combate
    public int BossLife(int index)
    {
        int enemylife = 0;
        if (File.Exists(Application.persistentDataPath + "/Partida.d"))
        {
            fb = new BinaryFormatter();
            Informacion = File.OpenRead(Application.persistentDataPath + "/Partida.d");
            Datos = fb.Deserialize(Informacion) as DatosdeJuego;
            Debug.Log(Application.persistentDataPath);
            enemylife = Convert.ToInt32(Datos.Jefes[index, 2]);
            Informacion.Close();
            Debug.Log(enemylife);
            return enemylife;
        }
        return enemylife;
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
    public String[,] Jefes = new String[17, 3];
}
