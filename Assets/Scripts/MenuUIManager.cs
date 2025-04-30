using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        if (DataManager.Instance != null)
        {
            highScoreText.text = $"Best Score : {DataManager.Instance.highScoreName} : {DataManager.Instance.highScore}";
        }
    }

    public void SaveName()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.playerName = nameInputField.text;
        }
    }

    public void StartButton()
    {
        SaveName();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
