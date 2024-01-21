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
        explodeStones,
        activate
    }

    [Tooltip("Choose functions, that will be apllied to your object")]
    public objectFuncs[] funcs;

    private List<string> funcNames = new List<string>();

    private HackUI menu;

    private GameObject div;

    public CheckCollider canUse;

    public bool activated;

    [Header("Items for functions")]
    public DestructionObjects destruction;
    public GameObject target;
    public GameObject door;
    public scriptable_object second;

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

    //Все возможные для использования функции

    public void KillPlayer(string player) {

        print("Игрок " + player + "был убит.");

    }

    public void OpenDoor() {

        door.SetActive(false);

        StartCoroutine(CloseDoor());

    }

    IEnumerator CloseDoor() {

        float i = 0;

        while(i < 7f) {
            i += 1f;
            yield return new WaitForSeconds(1f);
        }

        door.SetActive(true);

    }

    public void SayThing() {

        print("thing");

    }

    public void ExplodeStones() {

        destruction.Replace();

    }

    public void Activate() {
        target.SetActive(true);
    }

    //Функция добавляет в открывающийся список функции этого конкретного объекта,
    //что позволяет легко добавлять новые функциии для каждого объекта
    private void addNames() {

        if(funcs.Contains(objectFuncs.killPlayer)) {
            funcNames.Add("Убить игрока");
        }
        if(funcs.Contains(objectFuncs.openDoor)) {
            funcNames.Add("Открыть дверь на время");
        }
        if(funcs.Contains(objectFuncs.sayThing)) {
            funcNames.Add("Сказать \"что-то\"");
        }
        if(funcs.Contains(objectFuncs.explodeStones)) {
            funcNames.Add("Взорвать камни");
        }
        if(funcs.Contains(objectFuncs.activate)) {
            funcNames.Add("Включить объект");
        }

    }
}
