using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstChar : MonoBehaviour
{
    public bool MyTurn; //Bandera de turno
    public GameObject PanelHabs;
    public GameObject[] character = new GameObject[25];
    public GameObject[] spawns = new GameObject[3];
    public Image turn;
    public Text[] Habs = new Text[4];
    private string[] HabPS = new string[4]; //Nombres de cada habilidad
    private int[] HabP = new int[4]; //Puntos de cada habilidad
    private int id;
    public int noPersonaje;
    public Animator anim;
    private TempData selected;

    void Awake()
    {
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        id = selected.idChar[noPersonaje];
        for (int x = 0; x < 3; x++)
        {
            if (noPersonaje == x + 1)
            {
                spawns[x] = Instantiate(character[id], transform.position, Quaternion.identity);
                spawns[x].transform.parent = transform;
                spawns[x].transform.localScale = new Vector3(1, 1, 1);
                anim = spawns[x].GetComponentInChildren<Animator>();
            }
        }
        /*var newPrefab = Instantiate(character[id], transform.position, Quaternion.identity);
        newPrefab.transform.parent = gameObject.transform;
        newPrefab.transform.localScale = new Vector3(1, 1, 1);*/
        //anim.SetBool("Appear", true);

        for (int i = 0; i < 4; i++)
        {
            HabPS[i] = selected.HabChar[id, i];
        }
    }

    void Update()
    {
        /*if (MyTurn == true)
        {
            turn.enabled = true;
            PanelHabs.SetActive(true);
            for (int x = 0; x < 4; x++)
            {
                Habs[x].text = HabPS[x];
            }
        }
        if (MyTurn == false)
        {
            turn.enabled = false;
        }*/
    }
}
