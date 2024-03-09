using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogUI_Controller : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter_1;
    public TextMeshProUGUI phrase;
    //public AudioSource audio;
    private int phraseNum = 0;
    public GameObject textWindow;
    public List<string> phrases = new List<string>(){ };

    public void StartWriting(){
        phraseNum = 0;
        textWriter_1.AddWriter(phrase,phrases[phraseNum],0.1f,true,EndOfPhrase);
       // GetComponent<AudioSource>().Play();
    }
    private void EndOfPhrase(){
        //GetComponent<AudioSource>().Stop();
    }

    private void Update()
    {
        Debug.Log(phraseNum);
        if (Input.anyKeyDown && textWriter_1.IsActive())
        {
            print("text is writing");
            textWriter_1.WriteAll();
        }
        else if (Input.anyKeyDown  && !textWriter_1.IsActive() && phraseNum == phrases.Count - 1)
        {
            gameObject.GetComponent<Interactions>().EndDialogue();
        }
        else if (Input.anyKeyDown  && !textWriter_1.IsActive() && phraseNum < phrases.Count - 1)
        {
            phraseNum++;
           // audio.Play();
            textWriter_1.AddWriter(phrase, phrases[phraseNum], 0.1f, true, EndOfPhrase);
        }
    }
}