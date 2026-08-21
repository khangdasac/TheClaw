using UnityEngine;
using System.IO;
using System.Collections.Generic;

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

    public static GameManager Instance
    {
        get => instance;
        set => instance = value;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (isLoadGameData)
        {
            if (Variable.IsLoadFileSaveGame)
            {
                LoadGame();
            }
            else
            {
                LoadNewGame();

                inventoryManager.ResetInventory();

                exchangeDeskManager01.ResetExcahngeDesk();
                exchangeDeskManager02.ResetExcahngeDesk();
                exchangeDeskManager03.ResetExcahngeDesk();
            }
        }

        if (isLoadSettingData)
        {
        }
    }

    public void LoadNewGame()
    {
        if (jsonFile == null)
        {
            Debug.LogError("JSON file is missing!");
            return;
        }

        LoadNewGame(jsonFile.text);
    }

    public void LoadNewGame(string jsonContent)
    {
        if (string.IsNullOrEmpty(jsonContent))
        {
            Debug.LogError("JSON content is empty!");
            return;
        }

        // JSON -> GameData
        gameData = JsonUtility.FromJson<GameData>(jsonContent);

        // Random nhóm vật phẩm giữa các tủ
        RandomizeCabinetItems(gameData);

        // Apply dữ liệu
        CabinetListManager.Instance.SetCabinetDatas(
            gameData.cabinetDatas
        );

        PlayerDataManager.Instance.SetPlayerTransform(
            gameData.playerTransform
        );

        EngineTableDataManager.Instance.SetEngineTableData(
            gameData.engineTableData
        );

        MonsterDataManager.Instance.SetMonsterTransform(
            gameData.monsterTransform
        );
    }

    private void RandomizeCabinetItems(GameData data)
    {
        List<ItemData[]> groups = new List<ItemData[]>();

        // Mỗi tủ = một nhóm
        foreach (CabinetData cabinet in data.cabinetDatas)
        {
            groups.Add(cabinet.itemDatas);
        }

        // Fisher-Yates Shuffle
        for (int i = groups.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            ItemData[] temp = groups[i];

            groups[i] = groups[randomIndex];
            groups[randomIndex] = temp;
        }

        for (int i = 0; i < data.cabinetDatas.Length; i++)
        {
            data.cabinetDatas[i].itemDatas = groups[i];
        }
    }

    public void SaveGame()
    {
        CabinetData[] cabinetDatas =
            CabinetListManager.Instance.GetCabinetDatas();

        EngineTableData engineTableData =
            EngineTableDataManager.Instance.GetEngineTableData();

        SerializableTransform playerTransform =
            PlayerDataManager.Instance.GetPlayerTransform();

        SerializableTransform monsterTransform =
            MonsterDataManager.Instance.GetMonsterTransform();

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

        File.WriteAllText(
            Application.persistentDataPath + "/saveFile.json",
            json
        );
    }

    public void LoadGame()
    {
        string path =
            Application.persistentDataPath + "/saveFile.json";

        if (!File.Exists(path))
        {
            Debug.LogError("Save file not found in " + path);
            return;
        }

        string json = File.ReadAllText(path);

        gameData = JsonUtility.FromJson<GameData>(json);

        CabinetListManager.Instance.SetCabinetDatas(
            gameData.cabinetDatas
        );

        PlayerDataManager.Instance.SetPlayerTransform(
            PlayerDataManager.Instance.GetPlayerTransformDefault()
        );

        MonsterDataManager.Instance.SetMonsterTransform(
            MonsterDataManager.Instance.GetMonsterTransformDefault()
        );

        EngineTableDataManager.Instance.SetEngineTableData(
            gameData.engineTableData
        );

        exchangeDeskManager01.LoadExchangeDeskData(
            gameData.exchangeDeskData01
        );

        exchangeDeskManager02.LoadExchangeDeskData(
            gameData.exchangeDeskData02
        );

        exchangeDeskManager03.LoadExchangeDeskData(
            gameData.exchangeDeskData03
        );
    }

    public void SaveGameDefault()
    {
        CabinetData[] cabinetDatas =
            CabinetListManager.Instance.GetCabinetDatas();

        EngineTableData engineTableData =
            EngineTableDataManager.Instance.GetEngineTableData();

        SerializableTransform playerTransform =
            PlayerDataManager.Instance.GetPlayerTransformDefault();

        SerializableTransform monsterTransform =
            MonsterDataManager.Instance.GetMonsterTransformDefault();

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

        File.WriteAllText(
            Application.persistentDataPath + "/saveFile.json",
            json
        );
    }

    public void SaveSettingData()
    {
        settingData = Variable.GetSettingData();

        string json = JsonUtility.ToJson(settingData);

        File.WriteAllText(
            Application.persistentDataPath + "/settingData.json",
            json
        );
    }
}