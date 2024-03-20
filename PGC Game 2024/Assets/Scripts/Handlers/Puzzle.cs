using UnityEngine;

public class Puzzle : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private HeavyButton[] _heavyButtons;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Tumbler[] _tumblers;
    [SerializeField] private Elevator[] _elevators;
    [SerializeField] private Gate[] _gates;
    [SerializeField] private GameObject[] _objects;

    [Header("Results")]
    [SerializeField] private _results _result;
    [SerializeField] private bool _canUndo;
    private enum _results {
        TurnPanel,
        TurnOnElevator,
        TurnOnFloatingPanel,
        MakeActive,
        MakeNotActive
    }

    [Header("TrapElements")]
    [SerializeField] private HeavyButton[] _trapHeavyButtons;
    [SerializeField] private Button[] _trapButtons;

    [Header("TrapResults")]
    [SerializeField] private _trapResults _trapResult;
    private enum _trapResults {
        ActivateSpikes,
        DamagePlayer,
        KillPlayer
    }

    private void Update() {

        Tasking();
        TrapTasking();

    }

    private void Tasking() {

        foreach(HeavyButton heavyButton in _heavyButtons) {
            if(heavyButton.Activated) continue;
            else {
                Undo();
                return;
            }
        }
        foreach(Button button in _buttons) {
            if(button.Activated) continue;
            else {
                Undo();
                return;
            }
        }
        foreach(Tumbler tumbler in _tumblers) {
            if(tumbler.Activated) continue;
            else {
                Undo();
                return;
            }
        }

        Result();

    }

    private void Result() {

        switch(_result) {
            case _results.TurnOnElevator:
                foreach(Elevator _elevator in _elevators) {
                    _elevator.Enabled = true;
                }
                break;
            case _results.TurnPanel:
                foreach(Gate _gate in _gates) {
                    _gate.TurnOn();
                }
                break;
            case _results.MakeActive:
                foreach(GameObject _gameObject in _objects) {
                    _gameObject.SetActive(true);
                }
                break;
            case _results.MakeNotActive:
                foreach(GameObject _gameObject in _objects) {
                    _gameObject.SetActive(false);
                }
                break;
        }

    }

    private void Undo() {

        if(!_canUndo) return;

        switch(_result) {
            case _results.TurnOnElevator:
                foreach(Elevator _elevator in _elevators) {
                    _elevator.Enabled = false;
                }
                break;
            case _results.TurnPanel:
                foreach(Gate _gate in _gates) {
                    _gate.TurnOff();
                }
                break;
            case _results.MakeActive:
                foreach(GameObject _gameObject in _objects) {
                    _gameObject.SetActive(false);
                }
                break;
            case _results.MakeNotActive:
                foreach(GameObject _gameObject in _objects) {
                    _gameObject.SetActive(true);
                }
                break;
        }

    }

    private void TrapTasking() {
        
        foreach(HeavyButton button in _trapHeavyButtons) {
            if(button.Activated) continue;
            else return;
        }
        foreach(Button button in _trapButtons) {
            if(button.Activated) {
                TrapResults();
                button.Activated = false;
            } else continue;
        }

        TrapResults();

    }

    private void TrapResults() {

        switch(_trapResult) {
            case _trapResults.DamagePlayer:
                PlayerInformation.Instance.Hp -= 1;
                break;
            case _trapResults.KillPlayer:
                PlayerInformation.Instance.Hp = 0;
                break;
        }

    }

}
