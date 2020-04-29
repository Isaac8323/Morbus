using UnityEngine.EventSystems;
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
public class funciones_estructuracion : MonoBehaviour
{
    String[,] Elementos2 = new String[11, 3];
    Archivos archivo_estructuracion;
    Text elementin,elemento_text_text;
    Image UIImage;
    public GameObject Element_global,LoadPanel;
    public GameObject[] cura = new GameObject[25];
    public GameObject[] enlace_aspirina = new GameObject[26];
    public GameObject[] enlace_paracetamol = new GameObject[22];
    public GameObject[] enlace_amoxicilina = new GameObject[56];
    public GameObject[] enlace_cloxacilina = new GameObject[66];
    public GameObject[] enlace_bortezomib = new GameObject[58];
    public GameObject[] enlace_lenalidomida = new GameObject[42];
    public GameObject[] enlace_vorinostat = new GameObject[38];
    public GameObject[] enlace_clavulanato = new GameObject[30];
    public GameObject[] enlace_penicilina = new GameObject[38];
    public GameObject[] enlace_eritromicina = new GameObject[102];
    Text [] verificadores =new Text[500];
    int banderin,mouseupper;
    int[] cantidad_elementos_celda = new int[500];
    int[] carbon_number = new int[500];
    int[] bandera_carb = new int[500];
    int cantidad_elementos_panel_elementos = 0,starttimer=0,cantidad_carbono_por_formulas=0;
    String element_used;
    float time = 0.1f;
    //aspirina variables
    int[] contador_enlaces_aspirina = new int[500];
    //Global functions
    // Start is called before the first frame update
    void Start()
    {
        archivo_estructuracion = GameObject.Find("Estructuracion").GetComponent<Archivos>();
        archivo_estructuracion.cargar_variables();
        elementsadd();
    }
    // Update is called once per frame
    void Update()
    {


        if (banderin == 1)
        {
            if (Input.GetMouseButton(0))
            {
                starttimer = 1;
            }
            if (starttimer == 1)
            {
                if (time >= 0)
                {
                    time -= Time.deltaTime;
                    return;
                }
                else
                {
                    Debug.Log("Left Mouse Button Down");
                    banderin = 0;
                    starttimer = 0;
                    time = 0.1f;
                    click_other_shit();
                    Element_global.SetActive(false);
                    //Do Something after clock hits 0
                }
            }
            Element_global.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        }
    }

    public void mouseup_on_element()
    {
        mouseupper = 1;
        Debug.Log(mouseupper.ToString());
    }
    public void mouseup_on_element2()
    {
        mouseupper =0;
        Debug.Log(mouseupper.ToString());
    }
    public void click_other_shit()
    {
        if (mouseupper == 1)
        {
            Element_global.SetActive(true);
            for (int i = 1; i < 12; i++)
            {
                elementin = GameObject.Find("txt_elemento" + i.ToString()).GetComponentInChildren<Text>();
                if (element_used.Equals(elementin.text))
                {
                    Debug.Log("compatible");
                    elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                    int totalelementonousado = Int32.Parse((elementin.text));
                    totalelementonousado = totalelementonousado + 1;
                    elementin.text = totalelementonousado.ToString();
                    elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                    elementin.text = "";
                }
            }
            Element_global.SetActive(false);
        }
        else
        {
            Element_global.SetActive(true);
            elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
            elementin.text = "";
            mouseupper = 1;
            Element_global.SetActive(false);
        }
    }

    public void MoverUI(int num_of_element_position)
    {
        Element_global.SetActive(false);
        elemento_text_text = GameObject.Find("txt_elemento"+num_of_element_position.ToString()).GetComponentInChildren<Text>();
         elementin = GameObject.Find("txt_total"+num_of_element_position.ToString()).GetComponentInChildren<Text>();
         mouseupper = 1;
        if (!elemento_text_text.text.Equals(""))
        {
            if (!elementin.text.Equals("0"))
            {
                Element_global.SetActive(true);
                elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                if (elementin.text.Equals(""))
                {
                    elementin = GameObject.Find("txt_total" + num_of_element_position.ToString()).GetComponentInChildren<Text>();
                    cantidad_elementos_panel_elementos = Int32.Parse(elementin.text);
                    cantidad_elementos_panel_elementos = cantidad_elementos_panel_elementos - 1;
                    elementin.text = cantidad_elementos_panel_elementos.ToString();
                    elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                    elementin.text = elemento_text_text.text;
                    element_used = elementin.text;
                    Debug.Log(element_used);
                    banderin = 1;
                }
                else
                {
                    mouseupper = 1;
                    Element_global.SetActive(false);
                }
            }
        }
    }
    public void MoverUI1()
    {
        MoverUI(1);
    }
    public void MoverUI2()
    {
        MoverUI(2);
    }
    public void MoverUI3()
    {
        MoverUI(3);
    }
    public void MoverUI4()
    {
        MoverUI(4);
    }
    public void MoverUI5()
    {
        MoverUI(5);
    }
    public void MoverUI6()
    {
        MoverUI(6);
    }
    public void MoverUI7()
    {
        MoverUI(7);
    }
    public void MoverUI8()
    {
        MoverUI(8);
    }
    public void MoverUI9()
    {
        MoverUI(9);
    }
    public void MoverUI10()
    {
        MoverUI(10);
    }
    public void MoverUI11()
    {
        MoverUI(11);
    }

    public void celda_elemento_form_aspirina(int x)
    {
        Element_global.SetActive(true);
        elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
        elemento_text_text = GameObject.Find("elemento_usado"+x.ToString()).GetComponentInChildren<Text>();
        if (!elementin.text.Equals(""))
        {
            if (!elemento_text_text.text.Equals(""))
            {
                String[] elm = new String[2];
                elm[0] = elementin.text;
                elm[1] = elementin.text;
                if (cantidad_elementos_celda[x] > 1)
                {
                    elm[0] = elementin.text + cantidad_elementos_celda[x].ToString();
                }
                if (elemento_text_text.text.Equals(elm[0]))
                {
                    elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                    cantidad_elementos_celda[x]++;
                    elemento_text_text.text = elementin.text + cantidad_elementos_celda[x].ToString();
                }
                else
                {
                    try
                    {
                        for (int i = 1; i < 12; i++)
                        {
                            elementin = GameObject.Find("txt_elemento" + i.ToString()).GetComponentInChildren<Text>();
                            int largo = elemento_text_text.text.Length;
                            if (largo == 1)
                            {
                                if (elemento_text_text.text.Substring(0, 1).Equals(elementin.text) )
                                {
                                    elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                                    int totalelementonousado = Int32.Parse((elementin.text));
                                    totalelementonousado = totalelementonousado + cantidad_elementos_celda[x];
                                    elementin.text = totalelementonousado.ToString();
                                    i = 12;
                                }
                            }
                            else if (largo == 2)
                            {
                                
                              if (elemento_text_text.text.Substring(0, 2).Equals(elementin.text))
                                {
                                    elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                                    int totalelementonousado = Int32.Parse((elementin.text));
                                    totalelementonousado = totalelementonousado + cantidad_elementos_celda[x];
                                    elementin.text = totalelementonousado.ToString();
                                    i = 12;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    cantidad_elementos_celda[x] = 1;
                    elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                    elemento_text_text = GameObject.Find("elemento_usado" + x.ToString()).GetComponentInChildren<Text>();
                    elemento_text_text.text = elementin.text;
                }
            }
            else if (elemento_text_text.text.Equals(""))
            {
                elemento_text_text.text = elementin.text;
                cantidad_elementos_celda[x]++;
            }
            elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
            elementin.text = "";
            Element_global.SetActive(false);
        }

    }
    public void celda_elemento_form_aspirina0()
    {
        celda_elemento_form_aspirina(0);
    }
    public void celda_elemento_form_aspirina1()
    {
        celda_elemento_form_aspirina(1);
    }
    public void celda_elemento_form_aspirina2()
    {
        celda_elemento_form_aspirina(2);
    }
    public void celda_elemento_form_aspirina3()
    {
        celda_elemento_form_aspirina(3);
    }
    public void celda_elemento_form_aspirina4()
    {
        celda_elemento_form_aspirina(4);
    }
    public void celda_elemento_form_aspirina5()
    {
        celda_elemento_form_aspirina(5);
    }
    public void celda_elemento_form_aspirina6()
    {
        celda_elemento_form_aspirina(6);
    }
    public void celda_elemento_form_aspirina7()
    {
        celda_elemento_form_aspirina(7);
    }
    public void celda_elemento_form_aspirina8()
    {
        celda_elemento_form_aspirina(8);
    }
    public void celda_elemento_form_aspirina9()
    {
        celda_elemento_form_aspirina(9);
    }
    public void celda_elemento_form_aspirina10()
    {
        celda_elemento_form_aspirina(10);
    }
    public void celda_elemento_form_aspirina11()
    {
        celda_elemento_form_aspirina(11);
    }
    public void celda_elemento_form_aspirina12()
    {
        celda_elemento_form_aspirina(12);
    }
    public void celda_elemento_form_aspirina13()
    {
        celda_elemento_form_aspirina(13);
    }
    public void celda_elemento_form_aspirina14()
    {
        celda_elemento_form_aspirina(14);
    }
    public void celda_elemento_form_aspirina15()
    {
        celda_elemento_form_aspirina(15);
    }
    public void celda_elemento_form_aspirina16()
    {
        celda_elemento_form_aspirina(16);
    }
    public void celda_elemento_form_aspirina17()
    {
        celda_elemento_form_aspirina(17);
    }
    public void celda_elemento_form_aspirina18()
    {
        celda_elemento_form_aspirina(18);
    }
    public void celda_elemento_form_aspirina19()
    {
        celda_elemento_form_aspirina(19);
    }
    public void celda_elemento_form_aspirina20()
    {
        celda_elemento_form_aspirina(20);
    }
    public void celda_elemento_form_aspirina21()
    {
        celda_elemento_form_aspirina(21);
    }
    public void celda_elemento_form_aspirina22()
    {
        celda_elemento_form_aspirina(22);
    }
    public void celda_elemento_form_aspirina23()
    {
        celda_elemento_form_aspirina(23);
    }
    public void celda_elemento_form_aspirina24()
    {
        celda_elemento_form_aspirina(24);
    }
    public void celda_elemento_form_aspirina25()
    {
        celda_elemento_form_aspirina(25);
    }
    public void celda_elemento_form_aspirina26()
    {
        celda_elemento_form_aspirina(26);
    }
    public void celda_elemento_form_aspirina27()
    {
        celda_elemento_form_aspirina(27);
    }
    public void celda_elemento_form_aspirina28()
    {
        celda_elemento_form_aspirina(28);
    }
    public void celda_elemento_form_aspirina29()
    {
        celda_elemento_form_aspirina(29);
    }
    public void celda_elemento_form_aspirina30()
    {
        celda_elemento_form_aspirina(30);
    }
    public void celda_elemento_form_aspirina31()
    {
        celda_elemento_form_aspirina(31);
    }
    public void celda_elemento_form_aspirina32()
    {
        celda_elemento_form_aspirina(32);
    }
    public void celda_elemento_form_aspirina33()
    {
        celda_elemento_form_aspirina(33);
    }
    public void celda_elemento_form_aspirina34()
    {
        celda_elemento_form_aspirina(34);
    }
    public void celda_elemento_form_aspirina35()
    {
        celda_elemento_form_aspirina(35);
    }
    public void celda_elemento_form_aspirina36()
    {
        celda_elemento_form_aspirina(36);
    }
    public void celda_elemento_form_aspirina37()
    {
        celda_elemento_form_aspirina(37);
    }
    public void celda_elemento_form_aspirina38()
    {
        celda_elemento_form_aspirina(38);
    }
    public void celda_elemento_form_aspirina39()
    {
        celda_elemento_form_aspirina(39);
    }
    public void celda_elemento_form_aspirina40()
    {
        celda_elemento_form_aspirina(40);
    }
    public void celda_elemento_form_aspirina41()
    {
        celda_elemento_form_aspirina(41);
    }
    public void celda_elemento_form_aspirina42()
    {
        celda_elemento_form_aspirina(42);
    }
    public void celda_elemento_form_aspirina43()
    {
        celda_elemento_form_aspirina(43);
    }
    public void celda_elemento_form_aspirina44()
    {
        celda_elemento_form_aspirina(44);
    }
    public void celda_carbon_from_aspirina(int x)
    {
        Element_global.SetActive(true);
        elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
        elemento_text_text = GameObject.Find("text_carbon" + x.ToString()).GetComponentInChildren<Text>();
        if (elementin.text.Equals("C"))
        {
            if (bandera_carb[x] == 0)
            {
                UIImage = GameObject.Find("carbon" + x.ToString()).GetComponent<Image>();
                UIImage.color = new Color32(81, 194, 72, 255);
                elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
                elementin.text = "";
                Element_global.SetActive(false);
                bandera_carb[x] =1;
            }
            else
            {
                mouseupper = 1;
            }
        }
        else if (elementin.text.Equals("H"))
        {
                if (!elemento_text_text.text.Equals(""))
                {
                    int suma_C = Int32.Parse(elemento_text_text.text.ToString());
                    suma_C = suma_C + 1;
                    carbon_number[x] = suma_C;
                    elemento_text_text.text = suma_C.ToString();
                        for (int i = 1; i < 12; i++)
                        {
                            elemento_text_text = GameObject.Find("txt_elemento" + i.ToString()).GetComponentInChildren<Text>();
                            if (elemento_text_text.text.Equals(elementin.text))
                            {
                                elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                                int totalelementonousado = Int32.Parse((elementin.text));
                                elementin.text = totalelementonousado.ToString();
                                i = 12;
                            }
                        }
                }
                else if (elemento_text_text.text.Equals(""))
                {
                    elemento_text_text.text = "1";
                    for (int i = 1; i < 12; i++)
                    {
                        elemento_text_text = GameObject.Find("txt_elemento" + i.ToString()).GetComponentInChildren<Text>();
                        if (elemento_text_text.text.Equals(elementin.text))
                        {
                            elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                            int totalelementonousado = Int32.Parse((elementin.text));
                            elementin.text = totalelementonousado.ToString();
                            i = 12;
                        }
                    }
                }
        }
        else if (elementin.text.Equals(""))
        {
            if (!elemento_text_text.text.Equals("0") && !elemento_text_text.text.Equals(""))
            {
                int suma_C = Int32.Parse(elemento_text_text.text.ToString());
                suma_C = suma_C - 1;
                carbon_number[x] = suma_C;
                if (suma_C == 0)
                {
                    elemento_text_text.text = "";
                }
                else
                {
                    elemento_text_text.text = suma_C.ToString();
                }
                for (int i = 1; i < 12; i++)
                {
                    elemento_text_text = GameObject.Find("txt_elemento" + i.ToString()).GetComponentInChildren<Text>();
                    if (elemento_text_text.text.Equals("H"))
                    {
                        elementin = GameObject.Find("txt_total" + i.ToString()).GetComponentInChildren<Text>();
                        int totalelementonousado = Int32.Parse((elementin.text));
                        totalelementonousado = totalelementonousado + 1;
                        elementin.text = totalelementonousado.ToString();
                        i = 12;
                    }
                }

            }
        }
        else
        {
            mouseupper = 1;
        }
            Element_global.SetActive(true);
            elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
            elementin.text = "";
            Element_global.SetActive(false);
        
    }
    public void celda_carbon_from_aspirina0()
    {
        celda_carbon_from_aspirina(0);
    }
    public void celda_carbon_from_aspirina1()
    {
        celda_carbon_from_aspirina(1);
    }
    public void celda_carbon_from_aspirina2()
    {
        celda_carbon_from_aspirina(2);
    }
    public void celda_carbon_from_aspirina3()
    {
        celda_carbon_from_aspirina(3);
    }
    public void celda_carbon_from_aspirina4()
    {
        celda_carbon_from_aspirina(4);
    }
    public void celda_carbon_from_aspirina5()
    {
        celda_carbon_from_aspirina(5);
    }
    public void celda_carbon_from_aspirina6()
    {
        celda_carbon_from_aspirina(6);
    }
    public void celda_carbon_from_aspirina7()
    {
        celda_carbon_from_aspirina(7);
    }
    public void celda_carbon_from_aspirina8()
    {
        celda_carbon_from_aspirina(8);
    }
    public void celda_carbon_from_aspirina9()
    {
        celda_carbon_from_aspirina(9);
    }
    public void celda_carbon_from_aspirina10()
    {
        celda_carbon_from_aspirina(10);
    }
    public void celda_carbon_from_aspirina11()
    {
        celda_carbon_from_aspirina(11);
    }
    public void celda_carbon_from_aspirina12()
    {
        celda_carbon_from_aspirina(12);
    }
    public void celda_carbon_from_aspirina13()
    {
        celda_carbon_from_aspirina(13);
    }
    public void celda_carbon_from_aspirina14()
    {
        celda_carbon_from_aspirina(14);
    }
    public void celda_carbon_from_aspirina15()
    {
        celda_carbon_from_aspirina(15);
    }
    public void celda_carbon_from_aspirina16()
    {
        celda_carbon_from_aspirina(16);
    }
    public void celda_carbon_from_aspirina17()
    {
        celda_carbon_from_aspirina(17);
    }
    public void celda_carbon_from_aspirina18()
    {
        celda_carbon_from_aspirina(18);
    }
    public void celda_carbon_from_aspirina19()
    {
        celda_carbon_from_aspirina(19);
    }
    public void celda_carbon_from_aspirina20()
    {
        celda_carbon_from_aspirina(20);
    }
    public void celda_carbon_from_aspirina21()
    {
        celda_carbon_from_aspirina(21);
    }
    public void celda_carbon_from_aspirina22()
    {
        celda_carbon_from_aspirina(22);
    }
    public void celda_carbon_from_aspirina23()
    {
        celda_carbon_from_aspirina(23);
    }
    public void verificar()
    {
        int contador_de_enlaces=0;
         Element_global.SetActive(true);
         elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
         if (elementin.text.Equals(""))
         {
         elementin = GameObject.Find("text_cura_name").GetComponentInChildren<Text>();
              //Verificacion de Aspirina
        if(elementin.text.Equals("Aspirina")){
            for (int i = 0; i < 9; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 9)
            {
                for (int i = 0; i < 5; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                 //comprovacion 2
                    if(verificadores[0].text.Equals("O") && verificadores[1].text.Equals("O") && verificadores[2].text.Equals("H") && verificadores[3]  .text.Equals("O") && verificadores[4].text.Equals("O") ){
                        Debug.Log("paso  comprovacion 2"); 
                        //comprovacion 3
                        for (int i = 0; i < 9; i++)
                        {
                            verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                        }
                        if (verificadores[0].text.Equals("1") && verificadores[6].text.Equals("3") && verificadores[7].text.Equals("1") && verificadores[8].text.Equals("1"))
                        {
                            Debug.Log("paso  comprovacion 3");
                            //comprovacion 4
                            if(contador_enlaces_aspirina[1]==1 && contador_enlaces_aspirina[19]==1 && contador_enlaces_aspirina[3]==1 && contador_enlaces_aspirina[5]==1 && contador_enlaces_aspirina[21]==1 ){
                                for (int i = 0; i < 26; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                                if (contador_de_enlaces == 21)
                                {
                                    Debug.Log("Creaste exitosamente a Aspirina");
                                    verificar_final(0);
                                }
                            }
                        }
                    }
            }
        }
            //Verificacion de paracetamol
        else if (elementin.text.Equals("Paracetamol"))
        {
            for (int i = 0; i < 9; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 7)
            {
                for (int i = 0; i < 7; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("H") && verificadores[1].text.Equals("O") && verificadores[2].text.Equals("N") && verificadores[3].text.Equals("H") && verificadores[4].text.Equals("O") && verificadores[5].text.Equals("C") && verificadores[6].text.Equals("H3"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 7; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }
                    if (verificadores[1].text.Equals("1") && verificadores[2].text.Equals("1") && verificadores[5].text.Equals("1") && verificadores[6].text.Equals("1"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[3] == 1 && contador_enlaces_aspirina[11] == 1 && contador_enlaces_aspirina[9] == 1 &&  contador_enlaces_aspirina[21] == 1)
                        {
                            for (int i = 0; i < 22; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                                if (contador_de_enlaces == 18)
                                {
                                Debug.Log("Creaste exitosamente a Paracetamol");
                                verificar_final(1);
                                }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Amoxicilina"))
        {
            for (int i = 0; i < 16; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 16)
            {
                for (int i = 0; i < 14; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("H") && verificadores[1].text.Equals("O") && verificadores[2].text.Equals("N") && verificadores[3].text.Equals("H2") && verificadores[4].text.Equals("N") && verificadores[5].text.Equals("H") && verificadores[6].text.Equals("H") && verificadores[7].text.Equals("S") && verificadores[8].text.Equals("O") && verificadores[9].text.Equals("H") && verificadores[10].text.Equals("O") && verificadores[11].text.Equals("N") && verificadores[12].text.Equals("O") && verificadores[13].text.Equals("O"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 16; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }
                    if (verificadores[1].text.Equals("1") && verificadores[2].text.Equals("1") && verificadores[4].text.Equals("1") && verificadores[6].text.Equals("1") && verificadores[9].text.Equals("3") && verificadores[10].text.Equals("3") && verificadores[11].text.Equals("1") && verificadores[13].text.Equals("1") && verificadores[14].text.Equals("1"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[3] == 1 && contador_enlaces_aspirina[7] == 1 && contador_enlaces_aspirina[13] == 1 && contador_enlaces_aspirina[21] == 1 && contador_enlaces_aspirina[31] == 1 && contador_enlaces_aspirina[55] == 1)
                        {
                            for (int i = 0; i < 56; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 50)
                            {
                                Debug.Log("Creaste exitosamente a Amoxicilina");
                                verificar_final(2);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Cloxacilina"))
        {
            for (int i = 0; i < 19; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 19)
            {
                for (int i = 0; i < 13; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("Cl") && verificadores[1].text.Equals("N") && verificadores[2].text.Equals("H") && verificadores[3].text.Equals("H") && verificadores[4].text.Equals("S") && verificadores[5].text.Equals("O") && verificadores[6].text.Equals("H") && verificadores[7].text.Equals("O") && verificadores[8].text.Equals("N") && verificadores[9].text.Equals("O") && verificadores[10].text.Equals("O") && verificadores[11].text.Equals("O") && verificadores[12].text.Equals("N"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 19; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[1].text.Equals("1") && verificadores[2].text.Equals("1") && verificadores[3].text.Equals("1") && verificadores[4].text.Equals("1") && verificadores[9].text.Equals("1") && verificadores[12].text.Equals("3") && verificadores[13].text.Equals("3") && verificadores[14].text.Equals("1") && verificadores[17].text.Equals("3"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[1] == 1 && contador_enlaces_aspirina[9] == 1 && contador_enlaces_aspirina[7] == 1 && contador_enlaces_aspirina[17] == 1 && contador_enlaces_aspirina[25] == 1 && contador_enlaces_aspirina[31] == 1 && contador_enlaces_aspirina[41] == 1 && contador_enlaces_aspirina[63] == 1)
                        {
                            for (int i = 0; i < 66; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 58)
                            {
                                Debug.Log("Creaste exitosamente a Cloxacilina");
                                verificar_final(3);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Bortezomib"))
        {
            for (int i = 0; i < 19; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 19)
            {
                for (int i = 0; i < 13; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("N") && verificadores[1].text.Equals("O") && verificadores[2].text.Equals("N") && verificadores[3].text.Equals("H") && verificadores[4].text.Equals("N") && verificadores[5].text.Equals("H") && verificadores[6].text.Equals("B") && verificadores[7].text.Equals("O") && verificadores[8].text.Equals("H") && verificadores[9].text.Equals("O") && verificadores[10].text.Equals("H") && verificadores[11].text.Equals("O") && verificadores[12].text.Equals("N"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 19; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[0].text.Equals("1") && verificadores[1].text.Equals("1") && verificadores[4].text.Equals("1") && verificadores[5].text.Equals("2") && verificadores[7].text.Equals("1") && verificadores[8].text.Equals("1") && verificadores[9].text.Equals("1") && verificadores[10].text.Equals("1") && verificadores[11].text.Equals("1") && verificadores[13].text.Equals("1") && verificadores[14].text.Equals("2") && verificadores[15].text.Equals("1") && verificadores[16].text.Equals("3") && verificadores[17].text.Equals("3") && verificadores[18].text.Equals("1"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[1] == 1 && contador_enlaces_aspirina[11] == 1 && contador_enlaces_aspirina[7] == 1 && contador_enlaces_aspirina[15] == 1 && contador_enlaces_aspirina[27] == 1 && contador_enlaces_aspirina[37] == 1 && contador_enlaces_aspirina[33] == 1 && contador_enlaces_aspirina[39] == 1)
                        {
                            for (int i = 0; i < 58; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 50)
                            {
                                Debug.Log("Creaste exitosamente a Bortezomib");
                                verificar_final(4);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Lenalidomida"))
        {
            for (int i = 0; i < 13; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 13)
            {
                for (int i = 0; i < 8; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("N") && verificadores[1].text.Equals("H2") && verificadores[2].text.Equals("N") && verificadores[3].text.Equals("O") && verificadores[4].text.Equals("O") && verificadores[5].text.Equals("N") && verificadores[6].text.Equals("H") && verificadores[7].text.Equals("O")) 
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 13; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[0].text.Equals("1") && verificadores[1].text.Equals("1") && verificadores[2].text.Equals("1") && verificadores[5].text.Equals("1") && verificadores[7].text.Equals("2") && verificadores[8].text.Equals("2") && verificadores[10].text.Equals("2") )
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[1] == 1 && contador_enlaces_aspirina[11] == 1 && contador_enlaces_aspirina[9] == 1 && contador_enlaces_aspirina[21] == 1 && contador_enlaces_aspirina[31] == 1 && contador_enlaces_aspirina[41] == 1)
                        {
                            for (int i = 0; i < 42; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 36)
                            {
                                Debug.Log("Creaste exitosamente a Lenalidomida");
                                verificar_final(5);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Vorinostat"))
        {
            for (int i = 0; i < 14; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 14)
            {
                for (int i = 0; i < 8; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("N") && verificadores[1].text.Equals("H") && verificadores[2].text.Equals("O") && verificadores[3].text.Equals("O") && verificadores[4].text.Equals("O") && verificadores[5].text.Equals("N") && verificadores[6].text.Equals("H") && verificadores[7].text.Equals("H")) 
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 14; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[0].text.Equals("1") && verificadores[1].text.Equals("1") && verificadores[4].text.Equals("2") && verificadores[5].text.Equals("2") && verificadores[6].text.Equals("2") && verificadores[7].text.Equals("2") && verificadores[8].text.Equals("2") && verificadores[9].text.Equals("2") && verificadores[11].text.Equals("1") && verificadores[12].text.Equals("1") && verificadores[13].text.Equals("1") )
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[1] == 1 && contador_enlaces_aspirina[11] == 1 && contador_enlaces_aspirina[7] == 1 && contador_enlaces_aspirina[15] == 1 && contador_enlaces_aspirina[33] == 1)
                        {
                            for (int i = 0; i < 38; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 33)
                            {
                                Debug.Log("Creaste exitosamente a Vorinostat");
                                verificar_final(6);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Clavulanato"))
        {
            for (int i = 0; i < 6; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 6)
            {
                for (int i = 0; i < 14; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("O") && verificadores[1].text.Equals("N") && verificadores[2].text.Equals("H") && verificadores[3].text.Equals("C") && verificadores[4].text.Equals("O") && verificadores[5].text.Equals("O") && verificadores[6].text.Equals("H") && verificadores[7].text.Equals("H") && verificadores[8].text.Equals("C") && verificadores[9].text.Equals("H2") && verificadores[10].text.Equals("O") && verificadores[11].text.Equals("H") && verificadores[12].text.Equals("O") && verificadores[13].text.Equals("H"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 6; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[5].text.Equals("2"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[1] == 1 && contador_enlaces_aspirina[25] == 1)
                        {
                            for (int i = 0; i < 30; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 28)
                            {
                                Debug.Log("Creaste exitosamente a Clavulanato");
                                verificar_final(7);
                            }
                        }
                    }
                }
            }
        }
        else if (elementin.text.Equals("Penicilina"))
        {
            for (int i = 0; i < 7; i++)
            {
                if (bandera_carb[i] == 1)
                {
                    bandera_carb[99]++;
                    Debug.Log(bandera_carb[99].ToString());
                }
            }
            //comprovacion 1
            if (bandera_carb[99] == 7)
            {
                for (int i = 0; i < 15; i++)
                {
                    verificadores[i] = GameObject.Find("elemento_usado" + i.ToString()).GetComponentInChildren<Text>();
                }
                Debug.Log("paso  comprovacion 1");
                //comprovacion 2
                if (verificadores[0].text.Equals("R") && verificadores[1].text.Equals("O") && verificadores[2].text.Equals("N") && verificadores[3].text.Equals("H") && verificadores[4].text.Equals("H") && verificadores[5].text.Equals("S") && verificadores[6].text.Equals("C") && verificadores[7].text.Equals("H3") && verificadores[8].text.Equals("C") && verificadores[9].text.Equals("H3") && verificadores[10].text.Equals("O") && verificadores[11].text.Equals("H") && verificadores[12].text.Equals("O") && verificadores[13].text.Equals("N") && verificadores[14].text.Equals("O"))
                {
                    Debug.Log("paso  comprovacion 2");
                    //comprovacion 3
                    for (int i = 0; i < 7; i++)
                    {
                        verificadores[i] = GameObject.Find("text_carbon" + i.ToString()).GetComponentInChildren<Text>();
                    }

                    if (verificadores[1].text.Equals("1") && verificadores[4].text.Equals("1"))
                    {
                        Debug.Log("paso  comprovacion 3");
                        //comprovacion 4
                        if (contador_enlaces_aspirina[27] == 1 && contador_enlaces_aspirina[7] == 1 && contador_enlaces_aspirina[5] == 1)
                        {
                            for (int i = 0; i < 38; i++)
                            {
                                if (contador_enlaces_aspirina[i] == 0)
                                {
                                    contador_de_enlaces++;
                                }
                            }
                            if (contador_de_enlaces == 35)
                            {
                                Debug.Log("Creaste exitosamente a Penicilina");
                                verificar_final(8);
                            }
                        }
                    }
                }
            }
        }

        }
         else
         {
             elementin.text = "";
             mouseupper = 1;
         }
         bandera_carb[99] = 0;
         Element_global.SetActive(false);
    }
    public void verificar_final(int numero_del_pj_en_el_archivo)
    {
        bandera_carb[99] = 0;
        int incremento = Int32.Parse(variables_indestructibles.Personajes[numero_del_pj_en_el_archivo, 2]);
        incremento = incremento + 1;
        int suma_exp = Int32.Parse(variables_indestructibles.experiencia);
        if (variables_indestructibles.Personajes[numero_del_pj_en_el_archivo,1].Equals("easy"))
        {
            suma_exp = suma_exp + 800;
        }
        else if (variables_indestructibles.Personajes[numero_del_pj_en_el_archivo, 1].Equals("Complex"))
        {
            suma_exp = suma_exp + 2000;
        }
        else if (variables_indestructibles.Personajes[numero_del_pj_en_el_archivo, 1].Equals("Hard"))
        {
            suma_exp = suma_exp + 10000;
        }
        variables_indestructibles.experiencia = suma_exp.ToString();
        if (suma_exp >= 50)
        {
            variables_indestructibles.level[0] = "2";
        }
        if (suma_exp >= 100)
        {
            variables_indestructibles.level[0] = "3";
        }
        if (suma_exp >= 550)
        {
            variables_indestructibles.level[0] = "4";
        }
        if (suma_exp >= 600)
        {
            variables_indestructibles.level[0] = "5";
        }
        if (suma_exp >= 1000)
        {
            variables_indestructibles.level[0] = "6";
        }
        if (suma_exp >= 2000)
        {
            variables_indestructibles.level[0] = "7";
        }
        if (suma_exp >= 3000)
        {
            variables_indestructibles.level[0] = "8";
        }
        if (suma_exp >= 4000)
        {
            variables_indestructibles.level[0] = "9";
        }
        if (suma_exp >= 5000)
        {
            variables_indestructibles.level[0] = "10";
        }
        if (suma_exp >= 14000)
        {
            variables_indestructibles.level[0] = "11";
        }
        if (suma_exp >= 15000)
        {
            variables_indestructibles.level[0] = "12";
        }
        if (suma_exp >= 19000)
        {
            variables_indestructibles.level[0] = "13";
        }
        if (suma_exp >= 23000)
        {
            variables_indestructibles.level[0] = "14";
        }
        if (suma_exp >= 27000)
        {
            variables_indestructibles.level[0] = "15";
        }
        if (suma_exp >= 31000)
        {
            variables_indestructibles.level[0] = "16";
        }
        if (suma_exp >= 35000)
        {
            variables_indestructibles.level[0] = "17";
        }
        if (suma_exp >= 39000)
        {
            variables_indestructibles.level[0] = "18";
        }
        if (suma_exp >= 47000)
        {
            variables_indestructibles.level[0] = "19";
        }
        if (suma_exp >= 55000)
        {
            variables_indestructibles.level[0] = "20";
        }

        variables_indestructibles.Personajes[numero_del_pj_en_el_archivo,2] = incremento.ToString();
        for (int i = 1; i < 12; i++)
        {
            elementin = GameObject.Find("txt_elemento" + i.ToString()).GetComponent<Text>();
            if (!elementin.text.Equals(""))
            {
                for (int y = 0; y < 11; y++)
                {
                    if (elementin.text.Equals(variables_indestructibles.Elementos[y, 4]))
                    {
                        int convercion = Int32.Parse(variables_indestructibles.Elementos[y, 1]);
                        int elemtincantidad = Int32.Parse(Elementos2[y,1]);
                        convercion = convercion - elemtincantidad;
                        variables_indestructibles.Elementos[y, 1] = convercion.ToString();
                        y = 11;
                    }
                }
            }
        }
        archivo_estructuracion.guardar_variables();
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }


    public void elementsadd()
    {
        String a = variables_indestructibles.estructuracion.ToLower();
        for(int i=0; i<25; i++){
            if (variables_indestructibles.Personajes[i, 0].Equals(a))
            {
                cura[i].SetActive(true); 
            }
        }
        elementin = GameObject.Find("text_cura_name").GetComponentInChildren<Text>();
        elementin.text = variables_indestructibles.estructuracion;
        Debug.Log(variables_indestructibles.estructuracion);
        for (int x = 0; x < 2; x++)
        {
            for (int i = 0; i < 11; i++)
            {
                if (x == 0)
                {
                    Elementos2[i, x] = variables_indestructibles.Elementos2[i, x];
                    elementin = GameObject.Find("txt_elemento" + (i + 1).ToString()).GetComponentInChildren<Text>();
                    elementin.text = Elementos2[i, x];
                }
                else
                {
                    Elementos2[i, x] = variables_indestructibles.Elementos2[i, x];
                    if (Elementos2[i, x].Equals("0"))
                    {
                    }
                    else
                    {
                        elementin = GameObject.Find("txt_total" + (i + 1).ToString()).GetComponentInChildren<Text>();
                        elementin.text = Elementos2[i, x];
                    }
                }
            }
        }
        for (int i2 = 0; i2 < 11; i2++)
        {
            Debug.Log(variables_indestructibles.Elementos2[i2, 0]);
            for (int i = 0; i < 11; i++)
            {
                if (variables_indestructibles.Elementos2[i2, 0].Equals(variables_indestructibles.Elementos[i, 4]))
                {
                    Elementos2[i2, 2] = variables_indestructibles.Elementos[i, 0];
                    elementin = GameObject.Find("txt_name" + (i2 + 1).ToString()).GetComponentInChildren<Text>();
                    elementin.text = Elementos2[i2, 2];
                }
            }
        }
        try
        {
            for (cantidad_carbono_por_formulas = 0; cantidad_carbono_por_formulas < 100; cantidad_carbono_por_formulas++)
            {
                Debug.Log("carbon" + cantidad_carbono_por_formulas.ToString());
                UIImage = GameObject.Find("carbon" + cantidad_carbono_por_formulas.ToString()).GetComponent<Image>();
                UIImage.color = new Color32(209, 9, 21, 255);
               
            }
        }
        catch(Exception e){
            cantidad_carbono_por_formulas = 100;
        }
    }
    //Aspirina functions
    public void enlace_as(int x,int x2)
    {
        Element_global.SetActive(true);
        String ruta="",nombre_form;
        elementin = GameObject.Find("text_cura_name").GetComponentInChildren<Text>();
        nombre_form = elementin.text;
                if(elementin.text.Equals("Aspirina")){
                    ruta = "Estrucutras/Simple/Aspirina/Enlaces/EN_AS_";
                }
                else if(elementin.text.Equals("Paracetamol")){
                    ruta = "Estrucutras/Simple/Paracetamol/Enlaces/EN_PA_";
                }
                else if (elementin.text.Equals("Amoxicilina")){
                    ruta = "Estrucutras/Simple/Amoxicilina/Enlaces/EN_AX_";
                }
                else if (elementin.text.Equals("Cloxacilina"))
                {
                    ruta = "Estrucutras/Simple/Cloxacilina/Enlaces/EN_CX_";
                }
                else if (elementin.text.Equals("Bortezomib"))
                {
                    ruta = "Estrucutras/Simple/Bortezomib/Enlaces/EN_BZ_";
                }
                else if (elementin.text.Equals("Lenalidomida"))
                {
                    ruta = "Estrucutras/Simple/Lenalidomida/Enlaces/EN_LD_";
                }
                else if (elementin.text.Equals("Vorinostat"))
                {
                    ruta = "Estrucutras/Simple/Vorinostat/Enlaces/EN_VO_";
                }
                else if (elementin.text.Equals("Clavulanato"))
                {
                    ruta = "Estrucutras/Complex/Clavulanato/Enlaces/EN_CLV_";
                }
                else if (elementin.text.Equals("Penicilina"))
                {
                    ruta = "Estrucutras/Complex/Penicilina/Enlaces/EN_PNL_";
                }
                else if (elementin.text.Equals("Eritromicina"))
                {
                    ruta = "Estrucutras/Complex/Eritromicina/Enlaces/EN_ERT_";
                }
         elementin = GameObject.Find("txt_elemento_global").GetComponentInChildren<Text>();
         if (elementin.text.Equals(""))
         {
             if (contador_enlaces_aspirina[x] == 2)
             {
                 contador_enlaces_aspirina[x] = 0;
                 int activate = x - 1;
                 int activate2 = x2 - 1;
                 if (nombre_form.Equals("Aspirina"))
                 {
                     enlace_aspirina[activate].SetActive(false);
                     enlace_aspirina[activate2].SetActive(false);
                 }
                 else if(nombre_form.Equals("Paracetamol")){
                      enlace_paracetamol[activate].SetActive(false);
                      enlace_paracetamol[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Amoxicilina"))
                 {
                     enlace_amoxicilina[activate].SetActive(false);
                     enlace_amoxicilina[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Cloxacilina"))
                 {
                     enlace_cloxacilina[activate].SetActive(false);
                     enlace_cloxacilina[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Bortezomib"))
                 {
                     enlace_bortezomib[activate].SetActive(false);
                     enlace_bortezomib[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Lenalidomida"))
                 {
                    enlace_lenalidomida[activate].SetActive(false);
                    enlace_lenalidomida[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Vorinostat"))
                 {
                    enlace_vorinostat[activate].SetActive(false);
                    enlace_vorinostat[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Clavulanato"))
                 {
                    enlace_clavulanato[activate].SetActive(false);
                    enlace_clavulanato[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("Penicilina"))
                 {
                    enlace_penicilina[activate].SetActive(false);
                    enlace_penicilina[activate2].SetActive(false);
                 }
                 else if (nombre_form.Equals("eritromicina"))
                 {
                    enlace_eritromicina[activate].SetActive(false);
                    enlace_eritromicina[activate2].SetActive(false);
                 }    
             }
             else if (contador_enlaces_aspirina[x] == 1)
             {
                 int activate = x2 - 1;
                 if (nombre_form.Equals("Aspirina"))
                 {
                     enlace_aspirina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Paracetamol"))
                 {
                     enlace_paracetamol[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Amoxicilina"))
                 {
                     enlace_amoxicilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Cloxacilina"))
                 {
                     enlace_cloxacilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Bortezomib"))
                 {
                     enlace_bortezomib[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Lenalidomida"))
                 {
                     enlace_lenalidomida[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Vorinostat"))
                 {
                     enlace_vorinostat[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Clavulanato"))
                 {
                     enlace_clavulanato[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Penicilina"))
                 {
                     enlace_penicilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("eritromicina"))
                 {
                     enlace_eritromicina[activate].SetActive(true);
                 }
                 UIImage = GameObject.Find("ENA_AS_" + x2.ToString()).GetComponentInChildren<Image>();
                 UIImage.sprite = Resources.Load<Sprite>(ruta+ x2.ToString());
                 contador_enlaces_aspirina[x]++;
             }
             else
             {
                 int activate = x - 1;
                 Debug.Log(activate.ToString());
                 if (nombre_form.Equals("Aspirina"))
                 {
                     enlace_aspirina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Paracetamol"))
                 {
                     enlace_paracetamol[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Amoxicilina"))
                 {
                     enlace_amoxicilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Cloxacilina"))
                 {
                     enlace_cloxacilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Bortezomib"))
                 {
                     enlace_bortezomib[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Lenalidomida"))
                 {
                     enlace_lenalidomida[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Vorinostat"))
                 {
                     enlace_vorinostat[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Clavulanato"))
                 {
                     enlace_clavulanato[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("Penicilina"))
                 {
                     enlace_penicilina[activate].SetActive(true);
                 }
                 else if (nombre_form.Equals("eritromicina"))
                 {
                     enlace_eritromicina[activate].SetActive(true);
                 }
                 UIImage = GameObject.Find("ENA_AS_" + x.ToString()).GetComponentInChildren<Image>();
                 UIImage.sprite = Resources.Load<Sprite>(ruta + x.ToString());
                 contador_enlaces_aspirina[x]++;
             }
         }

         else
         {
             elementin.text = "";
             mouseupper = 1;
         }
         Element_global.SetActive(false);
    }
    public void enlace_aspirina0()
    {
        enlace_as(1,2);
    }
    public void enlace_aspirina1()
    {
        enlace_as(3,4);
    }
    public void enlace_aspirina2()
    {
        enlace_as(5,6);
    }
    public void enlace_aspirina3()
    {
        enlace_as(7,8);
    }
    public void enlace_aspirina4()
    {
        enlace_as(9,10);
    }
    public void enlace_aspirina5()
    {
        enlace_as(11,12);
    }
    public void enlace_aspirina6()
    {
        enlace_as(13,14);
    }
    public void enlace_aspirina7()
    {
        enlace_as(15,16);
    }
    public void enlace_aspirina8()
    {
        enlace_as(17,18);
    }
    public void enlace_aspirina9()
    {
        enlace_as(19,20);
    }
    public void enlace_aspirina10()
    {
        enlace_as(21,22);
    }
    public void enlace_aspirina11()
    {
        enlace_as(23,24);
    }
    public void enlace_aspirina12()
    {
        enlace_as(25,26);
    }
    public void enlace_aspirina13()
    {
        enlace_as(27, 28);
    }
    public void enlace_aspirina14()
    {
        enlace_as(29, 30);
    }
    public void enlace_aspirina15()
    {
        enlace_as(31, 32);
    }
    public void enlace_aspirina16()
    {
        enlace_as(33, 34);
    }
    public void enlace_aspirina17()
    {
        enlace_as(35, 36);
    }
    public void enlace_aspirina18()
    {
        enlace_as(37, 38);
    }
    public void enlace_aspirina19()
    {
        enlace_as(39, 40);
    }
    public void enlace_aspirina20()
    {
        enlace_as(41, 42);
    }
    public void enlace_aspirina21()
    {
        enlace_as(43, 44);
    }
    public void enlace_aspirina22()
    {
        enlace_as(45, 46);
    }
    public void enlace_aspirina23()
    {
        enlace_as(47, 48);
    }
    public void enlace_aspirina24()
    {
        enlace_as(49, 50);
    }
    public void enlace_aspirina25()
    {
        enlace_as(51, 52);
    }
    public void enlace_aspirina26()
    {
        enlace_as(53, 54);
    }
    public void enlace_aspirina27()
    {
        enlace_as(55, 56);
    }
    public void enlace_aspirina28()
    {
        enlace_as(57, 58);
    }
    public void enlace_aspirina29()
    {
        enlace_as(59, 60);
    }
    public void enlace_aspirina30()
    {
        enlace_as(61, 62);
    }
    public void enlace_aspirina31()
    {
        enlace_as(63, 64);
    }
    public void enlace_aspirina32()
    {
        enlace_as(65, 66);
    }
    public void enlace_aspirina33()
    {
        enlace_as(67, 68);
    }
    public void enlace_aspirina34()
    {
        enlace_as(69, 70);
    }
    public void enlace_aspirina35()
    {
        enlace_as(71, 72);
    }
    public void enlace_aspirina36()
    {
        enlace_as(73, 74);
    }
    public void enlace_aspirina37()
    {
        enlace_as(75, 76);
    }
    public void enlace_aspirina38()
    {
        enlace_as(77, 78);
    }
    public void enlace_aspirina39()
    {
        enlace_as(79, 80);
    }
    public void enlace_aspirina40()
    {
        enlace_as(81, 82);
    }
    public void enlace_aspirina41()
    {
        enlace_as(83, 84);
    }
    public void enlace_aspirina42()
    {
        enlace_as(85, 86);
    }
    public void enlace_aspirina43()
    {
        enlace_as(87, 88);
    }
    public void enlace_aspirina44()
    {
        enlace_as(89, 90);
    }
    public void enlace_aspirina45()
    {
        enlace_as(91, 92);
    }
    public void enlace_aspirina46()
    {
        enlace_as(93, 94);
    }
    public void enlace_aspirina47()
    {
        enlace_as(95, 96);
    }
    public void enlace_aspirina48()
    {
        enlace_as(97, 98);
    }
    public void enlace_aspirina49()
    {
        enlace_as(99, 100);
    }
    public void enlace_aspirina50()
    {
        enlace_as(101, 102);
    }
   //Paracetamol functions
}
