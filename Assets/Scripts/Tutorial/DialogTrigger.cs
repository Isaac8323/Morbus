using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialogs dialog;

    public void Start()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialog);
    }
}
