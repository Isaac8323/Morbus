using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempData : MonoBehaviour
{
    public string[] nameChar = new string[4];
    public int[] lifeChar = new int[4];
    public int lifeBoss;
    public int[,] damageChar = new int[3, 4];
    public string[,] HabChar = new string[3, 4];
    public int idBoss;
    public int[] idChar = new int[4];
    public int damageBoss;
    public int background;
    public string nameBoss;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }
}
