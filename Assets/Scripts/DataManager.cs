using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public string playerName;
    public int highScore;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int highScore;
    public string highScoreName;

    private string savePath;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/savefile.json";
        LoadData();
    }

    // Comment out when not testing
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetData();
        }
    }

    public void SaveData()
    {
        SaveData data = new SaveData();
        data.playerName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.playerName;
        }
    }

    // For test purposes
    public void ResetData()
    {
        string savePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save data reset.");
        }

        // Reset runtime values
        highScore = 0;
        highScoreName = "";
        playerName = "";
    }
}
