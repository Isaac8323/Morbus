using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monedas : MonoBehaviour
{    
    public Archivos CoinFile;
    public Text cant;
    string coins;

    void Update()
    {
        coins = CoinFile.carga_monedas("xd");
        cant.text = coins;
    }
}
