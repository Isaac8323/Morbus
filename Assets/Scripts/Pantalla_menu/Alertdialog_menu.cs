using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alertdialog_menu : MonoBehaviour
{
    public GameObject Alertais;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Alerta_inicio_sesion_A()
    {
         Alertais.SetActive(true);
    }
    public void Alerta_inicio_sesion_C()
    {
        Alertais.SetActive(false);
    }
}
