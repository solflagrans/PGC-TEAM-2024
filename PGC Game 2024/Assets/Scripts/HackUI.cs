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

        if(choosedTrigger == "������") {
            param1.gameObject.SetActive(true);
            param2.gameObject.SetActive(false);
        }
        if(choosedTrigger == "��������") {
            param1.gameObject.SetActive(false);
            param2.gameObject.SetActive(true); 
        }
        if(choosedTrigger == "�� ������� ������") {
            param1.gameObject.SetActive(false);
            param2.gameObject.SetActive(false);
        }

    }

    //���������� ��������� ������� ������� � ������ ����������� �������� � ����������
    public void Use() {

        if(choosedTrigger == "������") {
            StartCoroutine(Timer(numParam));
        }
        if(choosedTrigger == "��������") {
            StartCoroutine(Collider());
        }
        if(choosedTrigger == "�� ������� ������") {
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

        if(choosedAction == "����� ������") {
            scr_obj.KillPlayer("time");
        }

        if(choosedAction == "������� \"���-��\"") {
            scr_obj.SayThing();
        }

        if(choosedAction == "������� ����� �� �����") {
            scr_obj.OpenDoor();
        }
        
        if(choosedAction == "�������� �����") {
            scr_obj.ExplodeStones();
        }

    }

}
