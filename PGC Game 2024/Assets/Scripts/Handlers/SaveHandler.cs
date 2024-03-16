using System;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    public static SaveHandler Instance { get; private set; }

    private PlayerInformation _playerInfo;
    private GameInformation _gameInfo;
    [SerializeField] private MainMenuUI _settingsInformation;

    private void Awake() {

        if(!Instance) Instance = this;

    }

    private void Start() {

        _playerInfo = PlayerInformation.Instance;
        _gameInfo = GameInformation.Instance;

        OnLevelEnter();

    }

    public void CheckpointSave() {

        PlayerPrefs.SetFloat("PosX", _playerInfo.transform.position.x);
        PlayerPrefs.SetFloat("PosY", _playerInfo.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", _playerInfo.transform.position.z);
        PlayerPrefs.SetInt("Honey", _playerInfo.CollectedHoney);

        PlayerPrefs.Save();

    }

    public void CheckpointLoad() {

        if(PlayerPrefs.HasKey("PosX")) _playerInfo.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        PlayerInformation.Instance.CollectedHoney = PlayerPrefs.GetInt("Honey", 0);

    }

    public void OnLevelEnter() {

        GameInformation.Instance.IsTalkedToMechanic = PlayerPrefs.GetInt("MechanicTalked", 0) == 1 ? true : false ;
        GameInformation.Instance.LastUnlockedLevel = PlayerPrefs.GetInt("LastLevel", 0);
        PlayerInformation.Instance.CollectedHoney = PlayerPrefs.GetInt("Honey", 0);

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

    public void LastLevel() {

        PlayerPrefs.SetInt("LastLevel", _gameInfo.LastUnlockedLevel);
        PlayerPrefs.Save();

    }

    public void LoadShop() {

        //make function later

    }

    public void LoadCollection() {

        //analogy

    }

}
