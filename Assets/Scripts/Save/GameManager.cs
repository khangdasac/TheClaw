using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameData gameData;

    public void SaveGame()
    {
        // Cập nhật vị trí hiện tại của người chơi

        // Chuyển đổi dữ liệu game sang JSON
        string json = JsonUtility.ToJson(gameData);

        // Lưu JSON vào file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Game Saved: " + json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            // Đọc JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển đổi JSON thành dữ liệu game
            gameData = JsonUtility.FromJson<GameData>(json);


            // Cập nhật vị trí người chơi
            CabinetListManager.Instance.SetCabinetDatas(gameData.cabinetDatas);
            PlayerDataManager.Instance.SetPlayerTransform(gameData.playerTransform);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CabinetData[] cabinetDatas = CabinetListManager.Instance.GetCabinetDatas();
            EngineTableData engineTableData = EngineTable.Instance.GetEngineTableData();
            SerializableTransform playerTransform = PlayerDataManager.Instance.GetPlayerTransform();
            SerializableTransform monsterTransform = MonsterDataManager.Instance.GetMonsterTransform();
            gameData = new GameData(cabinetDatas, engineTableData, playerTransform, monsterTransform);
            Debug.Log(Application.persistentDataPath + "/savefile.json");
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }
}
