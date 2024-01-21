using System;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    [SerializeField] private GameInformation _gameInformation;
    [SerializeField] private PlayerInformation _playerInformation;
    [SerializeField] private MainMenuUI _settingsInformation;

    private void Start() {

        LoadOnLevelEnter();

    }


    public void CheckpointSave() {

        PlayerPrefs.SetFloat("PosX", _playerInformation.transform.position.x);
        PlayerPrefs.SetFloat("PosY", _playerInformation.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", _playerInformation.transform.position.z);
        PlayerPrefs.SetInt("Hp", _playerInformation.Hp);
        PlayerPrefs.SetInt("Honey", _playerInformation.CollectedHoney);

        string solvedPuzzlesHash = "";
        foreach(int id in _gameInformation.SolvedPuzzles) {
            solvedPuzzlesHash += id + " ";
        }
        PlayerPrefs.SetString("SolvedPuzzles", solvedPuzzlesHash);

        string brokenBarrelsHash = "";
        foreach(int id in _gameInformation.BrokenBarrels) {
            brokenBarrelsHash += id + " ";
        }
        PlayerPrefs.SetString("Barrel", brokenBarrelsHash);

        PlayerPrefs.Save();

    }
    public void EnterLevelSave() {

        PlayerPrefs.SetInt("Level", _gameInformation.LevelNum);

        PlayerPrefs.Save();

    }

    public void ExitLevelSave() {

        PlayerPrefs.SetInt("Hp", _playerInformation.MaxHp);
        PlayerPrefs.SetInt("Honey", _playerInformation.CollectedHoney);

        string solvedPuzzlesHash = "";
        foreach(int id in _gameInformation.SolvedPuzzles) {
            solvedPuzzlesHash += id + " ";
        }
        PlayerPrefs.SetString("SolvedPuzzles", solvedPuzzlesHash);

        string brokenBarrelsHash = "";
        foreach(int id in _gameInformation.BrokenBarrels) {
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

        PlayerPrefs.SetInt("MaxHp", _playerInformation.MaxHp);
        PlayerPrefs.SetInt("MaxHoney", _playerInformation.MaxHoneyAmount);
        PlayerPrefs.SetInt("Honey", _playerInformation.CollectedHoney);

        PlayerPrefs.Save();

    }

    public void CollectSave() {

        //_gameInformation.SaveCollectibles(); still make function

        PlayerPrefs.Save();

    }

    public void UnlockedLevelSave() {

        PlayerPrefs.SetInt("LastUnlockedLevel", _gameInformation.LastUnlockedLevel);

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

        _playerInformation.MaxHp = PlayerPrefs.GetInt("MaxHp", _playerInformation.MaxHp);
        _playerInformation.MaxHoneyAmount = PlayerPrefs.GetInt("MaxHoney", _playerInformation.MaxHoneyAmount);

        _playerInformation.Hp = PlayerPrefs.GetInt("Hp", _playerInformation.Hp);
        _playerInformation.CollectedHoney = PlayerPrefs.GetInt("Honey", _playerInformation.CollectedHoney);

        string[] solvedPuzzles = PlayerPrefs.GetString("SolvedPuzzles").Split(" ");
        foreach (string id in solvedPuzzles) {
            _gameInformation.SolvedPuzzles.Add(Int32.Parse(id));
        }

        string[] brokenBarrels = PlayerPrefs.GetString("BrokenBarrels").Split(" ");
        foreach(string id in brokenBarrels) {
            _gameInformation.BrokenBarrels.Add(Int32.Parse(id));
        }

        if(PlayerPrefs.HasKey("PosX")) _playerInformation.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));

    }

    public void LoadShop() {

        //make function later

    }

    public void LoadCollection() {

        //analogy

    }

    public void LoadLastLevel() {

        _gameInformation.LastUnlockedLevel = PlayerPrefs.GetInt("LastUnlockedLevel", 2);

    }

    public void LoadSettings() {

        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 1));
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen", 0) == 1 ? true : false;

    }

}
