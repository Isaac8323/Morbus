using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variables_indestructibles : MonoBehaviour
{
    // Start is called before the first frame update
    botones_laboratorio lab;
    public static string estructuracion;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void estruct()
    {
        lab = GameObject.Find("Laboratorio").GetComponent<botones_laboratorio>();
        lab.cargarformula = estructuracion;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
