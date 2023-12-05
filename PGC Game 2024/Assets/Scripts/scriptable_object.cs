using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class scriptable_object : MonoBehaviour
{

    public enum objectFuncs {
        killPlayer,
        openDoor,
        sayThing
    }

    public objectFuncs[] funcs;

    private List<string> funcNames = new List<string>();

    public HackUI menu;

    public GameObject div;

    private CheckCollider canUse;

    private void Start() {

        addNames();

        canUse = GetComponent<CheckCollider>();

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

        print("����� �������");

    }

    public void sayThing() {

        print("thing");

    }

    //������� ��������� � ������������� ������ ������� ����� ����������� �������,
    //��� ��������� ����� ��������� ����� �������� ��� ������� �������
    private void addNames() {

        if(funcs.Contains(objectFuncs.killPlayer)) {
            funcNames.Add("����� ������");
        }
        if(funcs.Contains(objectFuncs.openDoor)) {
            funcNames.Add("������� �����");
        }
        if(funcs.Contains(objectFuncs.sayThing)) {
            funcNames.Add("������� \"���-��\"");
        }

    }
}
