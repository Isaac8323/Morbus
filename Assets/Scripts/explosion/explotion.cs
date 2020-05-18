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

public class explotion : MonoBehaviour
{
    float time = 6.5f;
    public GameObject LoadPanel, anime;
    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 7.0f;
            mapa();
        }

        }
    public void mapa()
    {
        anime.SetActive(false);
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }
}
