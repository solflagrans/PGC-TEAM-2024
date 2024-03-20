using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private List<string> _dialogue1; //первый разговор с Механиком
    [SerializeField] private List<string> _dialogue2; //разговор до сбора всех чипов
    [SerializeField] private List<string> _dialogue3; // разговор после сбора всех чипов
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private GameObject _worldText;
    [SerializeField] private GameObject _mechanic;
    private GameInformation _gameInfo;
    private MovingController _movingController;
    private DialogUI_Controller _dialogController;
    private bool inTrigger;

    private void Start() {
        
        _gameInfo = GameInformation.Instance;
        _movingController = MovingController.Instance;
        _dialogController = GetComponent<DialogUI_Controller>();

    }

    private void Update() {

        if(inTrigger) TalkToMechanic(_mechanic);

    }


    private void OnTriggerEnter(Collider coll) {

        if(coll.CompareTag("Mechanic")) {
            inTrigger = true;
            ShowMessage();
        }
           
    }

    private void OnTriggerExit(Collider coll) {

        if(coll.CompareTag("Mechanic")) {
            inTrigger = false;
            HideMessage();
            if(_shopWindow.activeSelf) {
                _shopWindow.SetActive(!_shopWindow.activeSelf);
                Cursor.visible = _shopWindow.activeSelf;
            }
        }

    }
        
    private void OpenShop() {

        _shopWindow.SetActive(!_shopWindow.activeSelf);
        GetComponent<MovingController>().enabled = !_shopWindow.activeSelf;
        Cursor.visible = _shopWindow.activeSelf;
          
    }

    private void TalkToMechanic(GameObject mechanic) {

        if (Input.GetKeyDown(KeyCode.E)) {
            _worldText.SetActive(false);
            if (!_gameInfo.IsTalkedToMechanic) {
                StartDialogue(_dialogue1);
            } else if(_gameInfo.LastUnlockedLevel < 4) {
                StartDialogue(_dialogue2);
            } else if(_gameInfo.LastUnlockedLevel == 4) {
                StartDialogue(_dialogue3);
                //mechanic.GetComponent<Animator>().SetTrigger("");
                if (!mechanic.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(" ")) {
                    mechanic.SetActive(false);
                }
            }
        } else if (Input.GetKeyDown(KeyCode.Q) && !_dialogueWindow.activeSelf) {
            OpenShop();
        }

    }

    private void ShowMessage() {

        _worldText.SetActive(true);

    }

    private void HideMessage() {

        _worldText.SetActive(false);

    }

    public void StartDialogue(List<string> dialogue) {

        _movingController.enabled = false;
        _dialogController.Phrases.Clear();
        for(int i = 0; i < dialogue.Count;i++){           
            _dialogController.Phrases.Add(dialogue[i]);
        }
        _dialogController.StartWriting();
        _dialogueWindow.SetActive(true);

    }

    public void EndDialogue() {

        _movingController.enabled = true;
        _dialogueWindow.SetActive(false);
        _dialogController.Phrases.Clear();
        GameInformation.Instance.IsTalkedToMechanic = true;
        if (inTrigger) _worldText.SetActive(true);

    }
        
}
