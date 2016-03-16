using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject levelSelect;

    // Start is called on initialization.
    void Start () {
        HandleMenuSwitch(true, false, false);
    }
	
	// Update is called once per frame.
	void Update () {
        HandleInput();
	}

    // Handles any input for the main menu that isn't touches.
    void HandleInput() {
        if (Input.GetKey("escape") && !mainMenu.activeSelf)
        {
            HandleMenuSwitch(true, false, false);
        }
    }

    // Called when the Play button is pressed.
    public void PlayButton() {
        HandleMenuSwitch(false, false, true);
    }

    // Called when the Settings button is pressed.
    public void SettingsButton() {
        HandleMenuSwitch(false, true, false);
    }

    // Handles switching menus on/off
    void HandleMenuSwitch(bool mainM, bool settingsM, bool levelS) {
        mainMenu.SetActive(mainM);
        settingsMenu.SetActive(settingsM);
        levelSelect.SetActive(levelS);
    }

    // Called when the Exit button is pressed.
    public void ExitButton() {
        Application.Quit();
    }

}
