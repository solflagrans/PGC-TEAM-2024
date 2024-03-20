using System;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    public static SaveHandler Instance { get; private set; }

    private PlayerInformation _playerInfo;
    private GameInformation _gameInfo;
    [SerializeField] private MainMenuUI _settingsInformation;

    private void Awake() {

        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

    }

    private void Start() {

        _playerInfo = PlayerInformation.Instance;
        _gameInfo = GameInformation.Instance;

        LoadOnLevelEnter();

    }


    public void CheckpointSave() {

        PlayerPrefs.SetFloat("PosX", _playerInfo.transform.position.x);
        PlayerPrefs.SetFloat("PosY", _playerInfo.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", _playerInfo.transform.position.z);
        PlayerPrefs.SetInt("Hp", _playerInfo.Hp);
        PlayerPrefs.SetInt("Honey", _playerInfo.CollectedHoney);

        string solvedPuzzlesHash = "";
        foreach(int id in _gameInfo.SolvedPuzzles) {
            solvedPuzzlesHash += id + " ";
        }
        PlayerPrefs.SetString("SolvedPuzzles", solvedPuzzlesHash);

        string brokenBarrelsHash = "";
        foreach(int id in _gameInfo.BrokenBarrels) {
            brokenBarrelsHash += id + " ";
        }
        PlayerPrefs.SetString("Barrel", brokenBarrelsHash);

        PlayerPrefs.Save();

    }
    public void EnterLevelSave() {

        PlayerPrefs.SetInt("Level", _gameInfo.LevelNum);

        PlayerPrefs.Save();

    }

    public void ExitLevelSave() {

        PlayerPrefs.SetInt("Hp", _playerInfo.MaxHp);
        PlayerPrefs.SetInt("Honey", _playerInfo.CollectedHoney);

        string solvedPuzzlesHash = "";
        foreach(int id in _gameInfo.SolvedPuzzles) {
            solvedPuzzlesHash += id + " ";
        }
        PlayerPrefs.SetString("SolvedPuzzles", solvedPuzzlesHash);

        string brokenBarrelsHash = "";
        foreach(int id in _gameInfo.BrokenBarrels) {
            brokenBarrelsHash += id + " ";
        }
        PlayerPrefs.SetString("Barrel", brokenBarrelsHash);

        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");

        PlayerPrefs.Save();

    }


    public void ShopSave() {

        //_gameInformation.SaveBoughtItems(); make new function later
        //_gameInformation.SaveCollectibles(); analogy

        PlayerPrefs.SetInt("MaxHp", _playerInfo.MaxHp);
        PlayerPrefs.SetInt("MaxHoney", _playerInfo.MaxHoneyAmount);
        PlayerPrefs.SetInt("Honey", _playerInfo.CollectedHoney);

        PlayerPrefs.Save();

    }

    public void CollectSave() {

        //_gameInformation.SaveCollectibles(); still make function

        PlayerPrefs.Save();

    }

    public void UnlockedLevelSave() {

        PlayerPrefs.SetInt("LastUnlockedLevel", _gameInfo.LastUnlockedLevel);

        PlayerPrefs.Save();

    }

    public void SettingsSave() {

        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetString("Fullscreen", Screen.fullScreen ? "true" : "false");
        //Resolution

        PlayerPrefs.Save();

    }

    private void LoadOnLevelEnter() {

        _playerInfo.MaxHp = PlayerPrefs.GetInt("MaxHp", _playerInfo.MaxHp);
        _playerInfo.MaxHoneyAmount = PlayerPrefs.GetInt("MaxHoney", _playerInfo.MaxHoneyAmount);

        _playerInfo.Hp = PlayerPrefs.GetInt("Hp", _playerInfo.Hp);
        _playerInfo.CollectedHoney = PlayerPrefs.GetInt("Honey", _playerInfo.CollectedHoney);

        string[] solvedPuzzles = PlayerPrefs.GetString("SolvedPuzzles").Split(" ");
        foreach (string id in solvedPuzzles) {
            _gameInfo.SolvedPuzzles.Add(Int32.Parse(id));
        }

        string[] brokenBarrels = PlayerPrefs.GetString("BrokenBarrels").Split(" ");
        foreach(string id in brokenBarrels) {
            _gameInfo.BrokenBarrels.Add(Int32.Parse(id));
        }

        if(PlayerPrefs.HasKey("PosX")) _playerInfo.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));

    }

    public void LoadShop() {

        //make function later

    }

    public void LoadCollection() {

        //analogy

    }

    public void LoadLastLevel() {

        _gameInfo.LastUnlockedLevel = PlayerPrefs.GetInt("LastUnlockedLevel", 2);

    }

    public void LoadSettings() {

        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 1));
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen", 0) == 1 ? true : false;

    }

}
