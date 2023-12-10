using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class scriptable_object : MonoBehaviour
{

    //To make new function:
    //1) Add it in objectFuncs
    //2) Describe it using void
    //3) Indicate it's name in void AddNames()
    //4) Connect function with name in HackUI class, in void Action

    public enum objectFuncs {
        killPlayer,
        openDoor,
        sayThing,
        explodeStones
    }

    [Tooltip("Choose functions, that will be apllied to your object")]
    public objectFuncs[] funcs;

    private List<string> funcNames = new List<string>();

    private HackUI menu;

    private GameObject div;

    public CheckCollider canUse;

    [Header("Items for functions")]
    public DestructionObjects destruction;

    private void Start() {

        addNames();

        menu = transform.Find("/UI").GetComponent<HackUI>();
        div = menu.transform.Find("HackUI").gameObject;

    }

    private void Update() {

        if(canUse.playerIn) {
            if(Input.GetKeyDown(KeyCode.H)) {

                div.SetActive(true);

                menu.actions.ClearOptions();

                menu.actions.AddOptions(funcNames);

                menu.scr_obj = this;

            }
        }

    }

    //��� ��������� ��� ������������� �������

    public void KillPlayer(string player) {

        print("����� " + player + "��� ����.");

    }

    public void OpenDoor() {

        gameObject.SetActive(true);

        StartCoroutine(CloseDoor());

    }

    IEnumerator CloseDoor() {

        float i = 0;

        while(i < 7f) {
            i += 1f;
            print(i);
            yield return new WaitForSeconds(1f);
        }

        gameObject.SetActive(false);

    }

    public void SayThing() {

        print("thing");

    }

    public void ExplodeStones() {

        destruction.Replace();

    }

    //������� ��������� � ������������� ������ ������� ����� ����������� �������,
    //��� ��������� ����� ��������� ����� �������� ��� ������� �������
    private void addNames() {

        if(funcs.Contains(objectFuncs.killPlayer)) {
            funcNames.Add("����� ������");
        }
        if(funcs.Contains(objectFuncs.openDoor)) {
            funcNames.Add("������� ����� �� �����");
        }
        if(funcs.Contains(objectFuncs.sayThing)) {
            funcNames.Add("������� \"���-��\"");
        }
        if(funcs.Contains(objectFuncs.explodeStones)) {
            funcNames.Add("�������� �����");
        }

    }
}
