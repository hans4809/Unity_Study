using Client;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager _instance;
    static GameManager Instance { get { Init(); return _instance; } }
    GameManager() { }
    
    #endregion
    
    #region Managers

    ResourceManager _resourceManager = new ResourceManager();
    SoundManager _soundManager = new SoundManager();
    InGameDataManager _inGameDataManager = new InGameDataManager();
    UIManager _uiManager = new UIManager();
    NetworkManager _networkManager = new NetworkManager();

    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }
    public static InGameDataManager InGameData { get { return Instance._inGameDataManager; } }
    public static UIManager UI { get { return Instance._uiManager; } }
    public static NetworkManager Network { get { return Instance._networkManager; } }

    #endregion

    /// <summary> instance 생성, 산하 매니저들 초기화 </summary>
    static void Init()
    {
        if (_instance == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            if (gm == null)
            {
                gm = new GameObject { name = "GameManager" };
                gm.AddComponent<GameManager>();
            }
            _instance = gm.GetComponent<GameManager>();
            DontDestroyOnLoad(gm);

            _instance._soundManager.Init();
            _instance._inGameDataManager.Init();
            _instance._networkManager.Init();

            GoogleSheet googleSheet = _instance._networkManager.data;
            _instance.StartCoroutine(_instance._networkManager.GoogleSheetsDataParsing(googleSheet.associatedSheet, googleSheet.GetData, googleSheet.associatedDataWorksheet));
        }

    }
   
    /// <summary> 모든 정보 초기화 </summary>
    public static void Clear()
    {
        _instance._resourceManager.Clear();
        _instance._soundManager.Clear();
    }

   
}