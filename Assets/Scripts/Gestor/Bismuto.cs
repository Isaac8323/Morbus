using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bismuto : MonoBehaviour
{

    public Archivos BiFile;
    public Text cant;
    string bi;

    void Update()
    {
        bi = BiFile.carga_bismuto("xd");
        cant.text = bi;
    }
}
