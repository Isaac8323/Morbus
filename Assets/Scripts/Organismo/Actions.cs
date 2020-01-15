using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackone()
    {
        character.GetComponent<Animator>().Play("test01_atck1");
    }
    public void attacktwo()
    {
        character.GetComponent<Animator>().Play("test01_atck2");
    }
    public void attackthree()
    {
        character.GetComponent<Animator>().Play("test01_atck3");
    }
}
