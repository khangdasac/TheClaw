using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameData gameData;

    public void SaveGame()
    {
        // Cập nhật vị trí hiện tại của người chơi
        gameData.playerPosition = new SerializableVector3(transform.position);

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
            transform.position = gameData.playerPosition.ToVector3();
            Debug.Log("Game Loaded: " + json);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameData = new GameData(100, 200, new SerializableVector3(1, 2, 3));
            Debug.Log(Application.persistentDataPath + "/savefile.json");
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }
}
