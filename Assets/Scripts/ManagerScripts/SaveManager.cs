using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour {

    // Converts current level name to an int by splitting it then adds 1 and saves it in PlayerPrefs.
    public void SaveLevel()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        string[] levelNumber = activeScene.Split(' ');
        if (levelNumber.Length > 1)
        {
            int lvlNum = Convert.ToInt32(levelNumber[1]);
            lvlNum += 1;
            PlayerPrefs.SetInt("CurrrentLevel", lvlNum);
            Debug.Log("Set player prefs CurrentLevel to: " + lvlNum);
        }
    }
}
