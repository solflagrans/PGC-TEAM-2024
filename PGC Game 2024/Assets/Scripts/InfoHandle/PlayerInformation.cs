using UnityEngine;

public class PlayerInformation : MonoBehaviour
{

    public static PlayerInformation Instance { get; private set; }

    [Header("Stats")]
    private int _hp = 3;
    private int _maxHp = 3;
    private int _collectedHoney;
    private int _maxHoneyAmount = 60;
    private int _healJars;
    [Header("Technical")]
    private bool _isInvulnerable;
    private int _swordAura = -1;

    public int Hp { 
        get => _hp; 
        set {
            if(IsInvulnerable) return;
            if(value >= 0 && value <= _maxHp) {
                _hp = value;
                AudioHandler.Instance.healthSource.PlayOneShot(AudioHandler.Instance.hitSound);
                if (!UI_Controller.Instance.HPFading) StartCoroutine(UI_Controller.Instance.FadeHP());
                IsInvulnerable = true;             
            }
        } 
    }
    public int MaxHp { get => _maxHp; set { if(value > 0) _maxHp = value; } }
    public bool IsInvulnerable { get => _isInvulnerable; set => _isInvulnerable = value; }
    public int CollectedHoney { 
        get => _collectedHoney; 
        set {
            if(value >= 0 ) _collectedHoney = value;
            //else if(value > _maxHoneyAmount) _collectedHoney = _maxHoneyAmount;
            if(!UI_Controller.Instance.HoneyFading) StartCoroutine(UI_Controller.Instance.FadeHoney());
        } 
    }
    public int CollectedHealJars
    {
        get => _healJars;
        set
        {
            if (value >= 0) _healJars = value;
            //else if(value > _maxHoneyAmount) _collectedHoney = _maxHoneyAmount;
            if (!UI_Controller.Instance.HealFading) StartCoroutine(UI_Controller.Instance.FadeHeal());
        }
    }
    public int MaxHoneyAmount { get => _maxHoneyAmount; set { if(value >= 0) _maxHoneyAmount = value; } }
    public int SwordAura { get => _swordAura; set { if(value >= -1) _swordAura = value; } }

    private void Awake() {

        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

    }

}
