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
public class funciones_estructuracion : MonoBehaviour, IDragHandler, IEndDragHandler
{
    String[,] Elementos2 = new String[11, 3];
    Archivos archivo_estructuracion;
    Text elementin;
    Image UIImage;
    public GameObject[] cura = new GameObject[25];
    // Start is called before the first frame update
    void Start()
    {
        archivo_estructuracion = GameObject.Find("Estructuracion").GetComponent<Archivos>();
        archivo_estructuracion.cargar_variables();
        elementsadd();
    }

    // Update is called once per frame
 
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
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
