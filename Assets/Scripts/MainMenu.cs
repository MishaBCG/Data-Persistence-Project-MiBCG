using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public  TextMeshProUGUI bestScore;
    public static string namePlayer;
    public int Score;

    private void Start()
    {
        ForSave.instance.LoadGame();
        if(ForSave.instance.namePlayer != "")
        {
            namePlayer = ForSave.instance.namePlayer;
            Score = ForSave.instance.ScoreToSave;
            bestScore.text = $"Best score {namePlayer} : {Score}";
            Debug.Log("I load best score");
        }
    }
    public void TakeName(string Name)
    {
        namePlayer = Name;

    }



    public void GoInGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }




}
