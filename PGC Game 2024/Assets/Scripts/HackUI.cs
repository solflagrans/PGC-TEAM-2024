using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HackUI : MonoBehaviour
{

    //To add new trigger:
    //1) Add it in unity UI
    //2) Do coroutine for it
    //3) Add coroutine in void Use
    //4) *if needed, make new parameter for it

    [Header("UI Elements")]
    public TMP_Dropdown actions;
    public TMP_Dropdown triggers;
    public Slider param1;
    public TMP_Dropdown param2;

    [Header("Instances")]
    public GameObject menu;
    [HideInInspector] public scriptable_object scr_obj;
    public CheckCollider[] cols;
    
    [Header("Settings")]
    private string choosedAction;
    private string choosedTrigger;
    private float numParam;
    private int textParam;

    private void Update() {
        
        choosedAction = actions.captionText.text;
        choosedTrigger = triggers.captionText.text;
        numParam = param1.value;
        textParam = param2.value;

        if(choosedTrigger == "Таймер") {
            param1.gameObject.SetActive(true);
            param2.gameObject.SetActive(false);
        }
        if(choosedTrigger == "Коллидер") {
            param1.gameObject.SetActive(false);
            param2.gameObject.SetActive(true); 
        }
        if(choosedTrigger == "По нажатию кнопки") {
            param1.gameObject.SetActive(false);
            param2.gameObject.SetActive(false);
        }

    }

    //Включается выбранная игроком функция с учётом необходимых проверок и параметров
    public void Use() {

        if(choosedTrigger == "Таймер") {
            StartCoroutine(Timer(numParam));
        }
        if(choosedTrigger == "Коллидер") {
            StartCoroutine(Collider());
        }
        if(choosedTrigger == "По нажатию кнопки") {
            StartCoroutine(Button());
        }

        menu.SetActive(false);

    }

    IEnumerator Timer(float time) {

        float i = 0;

        while(i < time) {
            i += 1f;
            print(i);
            yield return new WaitForSeconds(1f);
        }

        Action();

    }

    IEnumerator Collider() {

        while(!cols[textParam].playerIn) {
            yield return new WaitForSeconds(.1f);
        }

        Action();

    }

    IEnumerator Button() {

        yield return new WaitForSeconds(2f);

        Action();
    }

    private void Action() {

        if(choosedAction == "Убить игрока") {
            scr_obj.KillPlayer("time");
        }

        if(choosedAction == "Сказать \"что-то\"") {
            scr_obj.SayThing();
        }

        if(choosedAction == "Открыть дверь на время") {
            scr_obj.OpenDoor();
        }
        
        if(choosedAction == "Взорвать камни") {
            scr_obj.ExplodeStones();
        }

    }

}
