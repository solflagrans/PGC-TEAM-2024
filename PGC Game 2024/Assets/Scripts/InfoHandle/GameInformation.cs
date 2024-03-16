using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInformation : MonoBehaviour
{

    public static GameInformation Instance { get; private set; }

    private int _levelNum;
    private int _lastUnlockedLevel;
    private List<int> _collectibles;
    private List<int> _shopList;
    private List<int> _solvedPuzzles;
    private List<int> _brokenBarrels;
    private bool _isTalkedToMechanic = false;
    private Checkpoint _lastCheckpoint;
    public Transform tpPoint;
    public Vector3 tpPosition;

    public int LevelNum { get => _levelNum; set { if(value >= 0) _levelNum = value; } }
    public int LastUnlockedLevel { get => _lastUnlockedLevel; set { if(value >= 0) _lastUnlockedLevel = value; } }
    public List<int> Collectibles { get => _collectibles; set => _collectibles = value; }
    public List<int> ShopList { get => _shopList; set => _shopList = value; }
    public List<int> SolvedPuzzles { get => _solvedPuzzles; set => _solvedPuzzles = value; }
    public List<int> BrokenBarrels { get => _brokenBarrels; set => _brokenBarrels = value; }
    public bool IsTalkedToMechanic {get => _isTalkedToMechanic; set => _isTalkedToMechanic = value;}
    public Checkpoint LastCheckpoint { get => _lastCheckpoint; set => _lastCheckpoint = value; }

    private void Awake() {

        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

    }

    private void Start() {
        
        tpPosition = tpPoint.position;

    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.K)) {
            MovingController.Instance.gameObject.transform.position = tpPosition;
        }
        if(Input.GetKeyDown(KeyCode.H)) {
            PlayerInformation.Instance.Hp = 3;
        }

    }
    
}