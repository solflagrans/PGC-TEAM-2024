using UnityEngine;
using System;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI UIText;
    private string phrase;
    private float letterSpeed;
    private float timer;
    private int letterIndex;
    private bool invisibleLetter;
    private Action End;
    private string text;

    public void AddWriter(TextMeshProUGUI UIText, string phrase, float letterSpeed, bool invisibleLetter, Action End) {

        this.UIText = UIText;
        this.phrase = phrase;
        this.letterSpeed = letterSpeed;
        this.invisibleLetter = invisibleLetter;
        this.End = End;
        letterIndex = 0;

    }

    private void Update() {

        if(UIText != null) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                timer += letterSpeed;
                if(letterIndex < phrase.Length) letterIndex++;
                text = phrase.Substring(0, letterIndex);
                if(invisibleLetter) text += "<color=#00000000>" + phrase.Substring(letterIndex) + "</color>";
                UIText.text = text;
                if(letterIndex >= phrase.Length){
                    UIText = null;
                    if(End != null) End();
                    return;
                }
            }
        }

    }

    public bool IsActive() {

        try {
        return letterIndex < phrase.Length;
        } catch(NullReferenceException) {
         return false;
        }

    }

    public void WriteAll() {

        UIText.text = phrase;
        if(End != null) End();
        letterIndex = phrase.Length;

    }
}
