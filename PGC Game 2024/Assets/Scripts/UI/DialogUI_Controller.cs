using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI_Controller : MonoBehaviour
{
    [SerializeField] private TextWriter _textWriter;
    [SerializeField] private TextMeshProUGUI _phrase;
    private int _phraseNum;
    private List<string> _phrases = new List<string>(){ };

    public List<string> Phrases { get => _phrases; set => _phrases = value; }

    public void StartWriting() {
        _phraseNum = 0;
        _textWriter.AddWriter(_phrase, _phrases[_phraseNum], 0.2f, true, EndOfPhrase);
    }

    private void EndOfPhrase() {
        //GetComponent<AudioSource>().Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _textWriter.IsActive())
        {
            _textWriter.WriteAll();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !_textWriter.IsActive() && _phraseNum == _phrases.Count - 1)
        {
            gameObject.GetComponent<Interactions>().EndDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !_textWriter.IsActive() && _phraseNum < _phrases.Count - 1)
        {
            _phraseNum++;
            _textWriter.AddWriter(_phrase, _phrases[_phraseNum], 0.2f, true, EndOfPhrase);
        }
    }
}