using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour {

    // Converts current level name to an int by splitting it then saves it in PlayerPrefs.
    void SaveLevel()
    {
        string testString = SceneManager.GetActiveScene().name;
        string[] levelNumber = testString.Split(' ');
        if (levelNumber.Length > 1)
        {

            int lvlNum = Convert.ToInt32(levelNumber[1]);
            PlayerPrefs.SetInt("CurrrentLevel", lvlNum);
            Debug.Log("Set player prefs CurrentLevel to: " + lvlNum);
        }
    }
}
