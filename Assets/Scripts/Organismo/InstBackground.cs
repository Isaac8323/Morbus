using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackground : MonoBehaviour
{
    public GameObject[] back = new GameObject[4];
    TempData selected;
    float tran=2.5F;
    void Start()
    {
        selected = GameObject.Find("Reference").GetComponent<TempData>();
        for (int x = 0; x < 4; x++)
        {
            if (selected.background == x)
            {
                var newPrefab = Instantiate(back[x], transform.position, Quaternion.identity);
                newPrefab.transform.parent = gameObject.transform;
                newPrefab.transform.localScale = new Vector3(tran, tran, 1);
            }
        }
    }
    void Update()
    {
        
    }
}
