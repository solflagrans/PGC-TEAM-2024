using UnityEngine;

public class Invulnerable : MonoBehaviour
{

    private PlayerInformation _player;

    private float _invulnerableTime = 5f;

    private bool _invokeLocked;

    public float InvulnerableTime { get => _invulnerableTime; set => _invulnerableTime = value; }

    private void Start() {
        _player = PlayerInformation.Instance;
    }

    private void Update() {
        
        if(_player.IsInvulnerable) {
            if(!_invokeLocked) {
                Invoke(nameof(RemoveInvulnerable), InvulnerableTime);
                _invokeLocked = true;
            }
        }

    }

    private void RemoveInvulnerable() {

        _player.IsInvulnerable = false;
        _invokeLocked = false;

    }

}
