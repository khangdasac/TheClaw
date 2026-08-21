using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    public GameData gameData;
    public SettingData settingData;
    public TextAsset jsonFile;

    public InventoryManager inventoryManager;
    public ExchangeDeskManager exchangeDeskManager01;
    public ExchangeDeskManager exchangeDeskManager02;
    public ExchangeDeskManager exchangeDeskManager03;

    public bool isLoadGameData;
    public bool isLoadSettingData;

    public static GameManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (isLoadGameData)
        {
            if (Variable.IsLoadFileSaveGame)
                LoadGame();
            else
            {
                LoadNewGame();
                inventoryManager.ResetInventory();
                exchangeDeskManager01.ResetExcahngeDesk();
                exchangeDeskManager02.ResetExcahngeDesk();
                exchangeDeskManager03.ResetExcahngeDesk();
            }
        }

        if(isLoadSettingData)
        {
            
        }

    }
    public void SaveGame()  
    {
        CabinetData[] cabinetDatas = CabinetListManager.Instance.GetCabinetDatas();
        EngineTableData engineTableData = EngineTableDataManager.Instance.GetEngineTableData();
        SerializableTransform playerTransform = PlayerDataManager.Instance.GetPlayerTransform();
        SerializableTransform monsterTransform = MonsterDataManager.Instance.GetMonsterTransform();

        gameData = new GameData(
            cabinetDatas,
            engineTableData,
            playerTransform,
            monsterTransform,
            exchangeDeskManager01.toExchangeDeskData(),
            exchangeDeskManager02.toExchangeDeskData(),
            exchangeDeskManager03.toExchangeDeskData()
        );

        string json = JsonUtility.ToJson(gameData);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            // Đọc JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển đổi JSON thành dữ liệu game
            gameData = JsonUtility.FromJson<GameData>(json);


            // Cập nhật vị trí người chơi
            CabinetListManager.Instance.SetCabinetDatas(gameData.cabinetDatas);
            PlayerDataManager.Instance.SetPlayerTransform(PlayerDataManager.Instance.GetPlayerTransformDefault());
            MonsterDataManager.Instance.SetMonsterTransform(MonsterDataManager.Instance.GetMonsterTransformDefault());

            EngineTableDataManager.Instance.SetEngineTableData(gameData.engineTableData);

            exchangeDeskManager01.LoadExchangeDeskData(gameData.exchangeDeskData01);
            exchangeDeskManager02.LoadExchangeDeskData(gameData.exchangeDeskData02);
            exchangeDeskManager03.LoadExchangeDeskData(gameData.exchangeDeskData03);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }


    public void SaveGameDefault()
    {
        CabinetData[] cabinetDatas = CabinetListManager.Instance.GetCabinetDatas();
        EngineTableData engineTableData = EngineTableDataManager.Instance.GetEngineTableData();
        SerializableTransform playerTransform = PlayerDataManager.Instance.GetPlayerTransformDefault();
        SerializableTransform monsterTransform = MonsterDataManager.Instance.GetMonsterTransformDefault();
        gameData = new GameData(
            cabinetDatas,
            engineTableData,
            playerTransform,
            monsterTransform, 
            exchangeDeskManager01.toExchangeDeskDataDefault(),
            exchangeDeskManager02.toExchangeDeskDataDefault(),
            exchangeDeskManager03.toExchangeDeskDataDefault()
            );

        string json = JsonUtility.ToJson(gameData);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadNewGame()
    {
        if (jsonFile != null)
        {
            string jsonContent = jsonFile.text;

            gameData = JsonUtility.FromJson<GameData>(jsonContent);

            CabinetListManager.Instance.SetCabinetDatas(gameData.cabinetDatas);
            PlayerDataManager.Instance.SetPlayerTransform(gameData.playerTransform);
            EngineTableDataManager.Instance.SetEngineTableData(gameData.engineTableData);
            MonsterDataManager.Instance.SetMonsterTransform(gameData.monsterTransform);
        }
        else
        {
            Debug.LogError("JSON file is missing!");
        }
    }

    public void SaveSettingData()
    {
        settingData = Variable.GetSettingData();
        string json = JsonUtility.ToJson(settingData);
        File.WriteAllText(Application.persistentDataPath + "/settingData.json", json);
    }
}
