using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] tutorial = new VideoClip[8];
    public VideoPlayer player;
    public GameObject load, train, santuario;
    private Archivos arctuto;

    public void Exit()
    {
        LoadScene.sceneToLoad = "Mapajuego";
        load.SetActive(true);
    }

    public void selectVideo(int id)
    {
        player.clip = tutorial[id];
    }

    void Start()
    {
        arctuto = GameObject.Find("Tutorials").GetComponent<Archivos>();
        arctuto.cargar_variables();
        if (Int32.Parse(variables_indestructibles.level[0]) < 15)
        {
            santuario.SetActive(false);
        }
        if (Int32.Parse(variables_indestructibles.level[0]) > 14)
        {
            santuario.SetActive(true);
        }
        if (Int32.Parse(variables_indestructibles.level[0]) < 8)
        {
            train.SetActive(false);
        }
        if (Int32.Parse(variables_indestructibles.level[0]) > 7)
        {
            train.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
