using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 dest;
    private Transform mov;

    // Start is called before the first frame update
    void Start()
    {
        Archivos archivo_battle = GameObject.Find("Organismo").GetComponent<Archivos>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Arrow(string bot)
    {
        mov = GameObject.Find(bot).GetComponent<Transform>();
        pos = mov.transform.position;
        dest = new Vector3(152, pos.y + 4, pos.z);
        GameObject.Find("Aspirina_arrow01").transform.position = dest;
    }

    public void HOne()
    {
        Arrow("Aspirina_Hab_01");
    }

    public void HTwo()
    {
        Arrow("Aspirina_Hab_02");
    }
    public void HThree()
    {
        Arrow("Aspirina_Hab_03");
    }
    public void HFour()
    {
        Arrow("Aspirina_Hab_04");
    }
}
