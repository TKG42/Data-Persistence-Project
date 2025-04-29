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

    public void SaveData()
    {

    }

    public void LoadData()
    {

    }
}
