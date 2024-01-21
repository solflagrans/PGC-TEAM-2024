using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{

    [Header("Stats")]
    private int _hp = 3;
    private int _maxHp = 3;
    private int _collectedHoney;
    private int _maxHoneyAmount = 60;

    [Header("Technical")]
    private bool _isInvulnerable;
    private int _swordAura = -1;

    public int Hp { get => _hp; set { if(value >= 0 && value <= _maxHp) _hp = value; } }
    public int MaxHp { get => _maxHp; set { if(value > 0) _maxHp = value; } }
    public bool IsInvulnerable { get => _isInvulnerable; set => _isInvulnerable = value; }
    public int CollectedHoney { get => _collectedHoney; set { if(value >= 0) _collectedHoney = value; } }
    public int MaxHoneyAmount { get => _maxHoneyAmount; set { if(value >= 0) _maxHoneyAmount = value; } }
    public int SwordAura { get => _swordAura; set { if(value >= -1) _swordAura = value; } }

}
