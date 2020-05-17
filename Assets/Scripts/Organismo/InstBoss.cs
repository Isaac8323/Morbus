using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBoss : MonoBehaviour
{
    public GameObject[] boss = new GameObject[16];
    public GameObject panel;
    public bool MyTurn;
    private TempData selected;

    void Start()
    {
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        //panel = GameObject.Find("Habilities").GetComponent<GameObject>();
        //var newPrefab = Instantiate(boss[selected.idBoss], transform.position, Quaternion.identity);
        //newPrefab.transform.parent = gameObject.transform;
        //newPrefab.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        if(MyTurn == true)
        {
            panel.SetActive(false);
        }
    }
}
