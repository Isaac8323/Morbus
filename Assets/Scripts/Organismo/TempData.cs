using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempData : MonoBehaviour
{
    public string[] nameChar = new string[4];
    public int[] lifeChar = new int[4];
    public int lifeBoss;
    public int[,] damageChar = new int[4,5];
    public int damageBoss;
    public int background;
    public string nameBoss;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
    }
}
