using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiButtons : MonoBehaviour {

	// Loads currently saved level.
	public void LoadSavedLevel () {
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
        if (SceneManager.sceneCountInBuildSettings < PlayerPrefs.GetInt("CurrentLevel") + 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("CurrentLevel"));
        }
    }
}
