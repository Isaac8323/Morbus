using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private Archivos arc;
    public GameObject tuto;

    public void Start()
    {
        arc = GameObject.Find("Estructuracion").GetComponent<Archivos>();
        arc.cargar_variables();
        if (variables_indestructibles.Tutorial.Equals("2"))
        {
            tuto.SetActive(true);
        }
        else
        {
            tuto.SetActive(false);
        }
    }
}
