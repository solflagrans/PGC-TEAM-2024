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

    //Все возможные для использования функции

    public void KillPlayer(string player) {

        print("Игрок " + player + "был убит.");

    }

    public void OpenDoor() {

        print("Дверь открыта");

    }

    public void sayThing() {

        print("thing");

    }

    //Функция добавляет в открывающийся список функции этого конкретного объекта,
    //что позволяет легко добавлять новые функциии для каждого объекта
    private void addNames() {

        if(funcs.Contains(objectFuncs.killPlayer)) {
            funcNames.Add("Убить игрока");
        }
        if(funcs.Contains(objectFuncs.openDoor)) {
            funcNames.Add("Открыть дверь");
        }
        if(funcs.Contains(objectFuncs.sayThing)) {
            funcNames.Add("Сказать \"что-то\"");
        }

    }
}
