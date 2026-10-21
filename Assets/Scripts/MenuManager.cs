using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_Text BestScoreText;

    private void Awake()
    {
        LoadBestScore();
        BestScoreText.text = $"Best Score: {DataPersistance.Instance.BestScorePlayerName} : {DataPersistance.Instance.BestScore}";
    }

    public void StartNew()
    {
        DataPersistance.Instance.PlayerName = NameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataPersistance.SaveData data = JsonUtility.FromJson<DataPersistance.SaveData>(json);

            DataPersistance.Instance.BestScore = data.BestScore;
            DataPersistance.Instance.BestScorePlayerName = data.BestScorePlayerName;
        }
        else
        {
            DataPersistance.Instance.BestScore = 0;
            DataPersistance.Instance.BestScorePlayerName = "";
        }
    }

    public void Exit()
    {

#if UNITY_EDITOR
        //Don't forget since this use editor code, need to add "using UnityEditor" at the top and wrap it between #if
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
