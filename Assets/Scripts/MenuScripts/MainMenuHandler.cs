using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settingsMenu;

    // Start is called on initialization.
    void Start () {
        HandleMenuSwitch(true, false);
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
    }
	
	// Update is called once per frame.
	void Update () {
        HandleInput();
	}

    // Handles any input for the main menu that isn't touches.
    void HandleInput() {
        if (Input.GetKey("escape") && !mainMenu.activeSelf)
        {
            HandleMenuSwitch(true, false);
        }
    }

    // Called when the Play button is pressed.
    public void PlayButton() {
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("CurrentLevel"));
    }

    // Called when the Settings button is pressed.
    public void SettingsButton() {
        HandleMenuSwitch(false, true);
    }

    // Handles switching menus on/off
    void HandleMenuSwitch(bool mainM, bool settingsM) {
        mainMenu.SetActive(mainM);
        settingsMenu.SetActive(settingsM);
    }

    // Called when the Exit button is pressed.
    public void ExitButton() {
        Application.Quit();
    }

}
