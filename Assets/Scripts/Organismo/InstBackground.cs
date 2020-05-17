using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackground : MonoBehaviour
{
    public AudioSource fondo;
    public AudioClip[] songs = new AudioClip[4];
    public GameObject[] back = new GameObject[4];
    TempData selected;
    float tran=1F; //Ajusta el tamaño del prefab al del canvas
    void Start()
    {
        System.Random song = new System.Random();
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        fondo.clip = songs[song.Next(0, 3)];
        fondo.Play();
        for (int x = 0; x < 4; x++)
        {
            if (selected.background == x)
            {
                var newPrefab = Instantiate(back[x], transform.position, Quaternion.identity);
                newPrefab.transform.parent = gameObject.transform;
                newPrefab.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    void Update()
    {
        
    }
}
