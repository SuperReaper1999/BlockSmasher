using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUiHandler : MonoBehaviour {

    [SerializeField]
    private Text ballCountText;

    private PlayerInputHandler playerHandler;

    void Start() {
        playerHandler = GameObject.FindWithTag("Player").GetComponent<PlayerInputHandler>();
    }

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

    // Fixed Update is called once per fixed interval.
    void FixedUpdate() {
        ballCountText.text = " = " + playerHandler.cannonBallCount.ToString();
    }
}
