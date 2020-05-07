using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiateCant : MonoBehaviour
{

    public GameObject prefab = null;

    void Start()
    {
        var newPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
        newPrefab.transform.parent = gameObject.transform;
        newPrefab.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        
    }
}
