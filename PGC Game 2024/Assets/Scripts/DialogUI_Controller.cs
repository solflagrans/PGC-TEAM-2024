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
    public AudioSource audio;
    private int phraseNum = 0;
    private int targetPhraseNum = 4;
    public GameObject textWindow;
    public List<string> phrases = new List<string>(){
    };
    void Start(){
        textWriter_1.AddWriter(phrase,phrases[phraseNum],0.1f,true,EndOfPhrase);
        audio.Play();
    }
    private void EndOfPhrase(){
        audio.Stop();
    }

    private void Update()
    {
        Debug.Log(phraseNum);
        if (Input.GetKeyUp(KeyCode.Space) && textWriter_1.IsActive())
        {
            textWriter_1.WriteAll();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !textWriter_1.IsActive() && phraseNum == targetPhraseNum)
        {
            textWindow.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !textWriter_1.IsActive() && phraseNum < phrases.Count - 1)
        {
            phraseNum++;
            audio.Play();
            textWriter_1.AddWriter(phrase, phrases[phraseNum], 0.1f, true, EndOfPhrase);
        }
    }
}