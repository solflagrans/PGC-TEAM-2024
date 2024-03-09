using UnityEngine;

public class Puzzle : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private HeavyButton[] _heavyButtons;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Elevator[] _elevators;

    [Header("Results")]
    [SerializeField] private _results _result;
    [SerializeField] private bool _canUndo;
    private enum _results {
        TurnPanel,
        TurnOnElevator,
        TurnOnFloatingPanel
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

        Result();

    }

    private void Result() {

        switch(_result) {
            case _results.TurnOnElevator:
                foreach(Elevator _elevator in _elevators) {
                    _elevator.Enabled = true;
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
        }

    }

    private void TrapTasking() {
        
        /*foreach(HeavyButton button in _trapHeavyButtons) {
            if(button.Activated) {
                TrapResults();
                button.Activated = false;
            } else continue;
        } There are some logical problems with that. We should think about it */
        foreach(Button button in _trapButtons) {
            if(button.Activated) {
                TrapResults();
                button.Activated = false;
            } else continue;
        }

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
