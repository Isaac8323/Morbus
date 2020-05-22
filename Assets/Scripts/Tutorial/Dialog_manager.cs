using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class Dialog_manager : MonoBehaviour
{
    public int cont = 0;
    public int NoTutorial; // 1.Intro, 2.Creacion de curas, 3.Compras, 4.Combates, 5.Centro de entrenamiento, 6.Arenas, 7.Nivel20, 8.Arenas desb
    public Animator animator;
    public Animator key;
    private Queue<string> sentences; //Listado de oraciones que cambia constantemente
    public GameObject panelDialogo; //Espacio en donde se mostrará el texto 
    public GameObject clara;
    public TextMeshProUGUI displayText; //Texto que representará el conjunto de oraciones
    public string activeSentence; //Valor de la oración actual
    public float typingSpeed; //rapidez de desplazamiento de texto
    AudioSource myAudio; //Declaración del recurso de sonido
    public AudioClip speakSound; //Se reproduce a la par que aparece el texto

    private void Awake()
    {
        sentences = new Queue<string>(); //Crea la sentencia u oración actual
        myAudio = GetComponent<AudioSource>(); //Toma el valor del audio que se reproduce mientras se muestra el texto        
    }

    public void Skip()
    {
        Destroy(GameObject.Find("Tutorial"));
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialogue(Dialogs dialogs)
    {
        sentences.Clear(); //Limpia el queue con la oración anterior
        foreach(string sentence in dialogs.sentences)
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
        if (sentences.Count == 0)
        {
            Destroy(GameObject.Find("Tutorial"));
        }
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
        if (Input.GetKey(KeyCode.Return) && displayText.text == activeSentence) //Detecta el clic izquierdo del ratón y verifica que la oración anterior haya terminado
        {            
            DisplayNextSentence();
            cont++;
        }
    }
}
