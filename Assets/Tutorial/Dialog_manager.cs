using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog_manager : MonoBehaviour
{
    public Animator animator;
    public Dialogs dialogos;

    Queue<string> sentences; //Listado de oraciones que cambia constantemente

    public GameObject panelDialogo; //Espacio en donde se mostrará el texto 
    public TextMeshProUGUI displayText; //Texto que representará el conjunto de oraciones
    string activeSentence; //Valor de la oración actual
    public float typingSpeed; //rapidez de desplazamiento de texto

    AudioSource myAudio; //Declaración del recurso de sonido
    public AudioClip speakSound; //Se reproduce a la par que aparece el texto

    private void Awake()
    {        
        sentences = new Queue<string>(); //Crea la sentencia u oración actual
        myAudio = GetComponent<AudioSource>(); //Toma el valor del audio que se reproduce mientras se muestra el texto        
        StartDialogue();        
    }

    void Start()
    {
        
    }

    void StartDialogue()
    {
        sentences.Clear(); //Limpia el queue con la oración anterior
        foreach(string sentence in dialogos.listaOraciones)
        {
            sentences.Enqueue(sentence); //Tomar la oración y la añade al queue para ser presentada
        }
        DisplayNextSentence();

    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }
        activeSentence = sentences.Dequeue(); //Saca la oración del listado y la pasa a activeSentence
        displayText.text = activeSentence;
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));        
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        animator.SetBool("Silencio", false);
        if (Input.GetMouseButtonUp(0) && displayText.text == activeSentence) //Detecta el clic izquierdo del ratón y verifica que la oración anterior haya terminado
        {            
            DisplayNextSentence();            
        }
        if (displayText.text == activeSentence)
        {
            animator.SetBool("Silencio", true);
        }
    }
}
