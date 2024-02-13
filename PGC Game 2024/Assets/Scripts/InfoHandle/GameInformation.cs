using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{

    private int _levelNum;
    private int _lastUnlockedLevel;
    private List<string> _collectibles;
    private List<string> _boughtItems;
    private List<int> _solvedPuzzles;
    private List<int> _brokenBarrels;

    public int LevelNum { get => _levelNum; set { if(value >= 0) _levelNum = value; } }
    public int LastUnlockedLevel { get => _lastUnlockedLevel; set { if(value >= 0) _lastUnlockedLevel = value; } }
    public List<string> Collectibles { get => _collectibles; set => _collectibles = value; }
    public List<string> ShopList { get => _boughtItems; set => _boughtItems = value; }
    public List<int> SolvedPuzzles { get => _solvedPuzzles; set => _solvedPuzzles = value; }
    public List<int> BrokenBarrels { get => _brokenBarrels; set => _brokenBarrels = value; }

}