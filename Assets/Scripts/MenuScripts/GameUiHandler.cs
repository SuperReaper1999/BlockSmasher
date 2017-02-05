using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUiHandler : MonoBehaviour {

    [SerializeField]
    private Text ballCountText;

    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LoseUI;
    [SerializeField]
    private GameObject PauseUI;

    private PlayerInputHandler playerHandler;

    void Start() {
        playerHandler = GameObject.FindWithTag("Player").GetComponent<PlayerInputHandler>();
        playerHandler.enabled = true;
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

    public void PauseGame()
    {
        playerHandler.enabled = false;
        Debug.Log("Game Paused");
        gameUI.SetActive(true);
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        playerHandler.enabled = true;
        Debug.Log("Game Un-Paused");
        gameUI.SetActive(false);
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    // Fixed Update is called once per fixed interval.
    void FixedUpdate() {
        ballCountText.text = " = " + playerHandler.cannonBallCount.ToString();
    }
}
