using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioListener))]

public class AudioManager : MonoBehaviour {

    // The booleans in this are backwards because it was easier to change script than it was to change art.

    private Toggle soundButton;

    // Start is called on initialization.
    void Start () {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetInt("volume", 1);
        }
        AudioListener.volume = PlayerPrefs.GetInt("volume");
        soundButton = GameObject.Find("AudioToggle").GetComponent<Toggle>();
    }
	
	// Update is called once per frame.
	void Update () {
        if (AudioListener.volume == 0)
        {
            AudioListener.pause = true;
            soundButton.isOn = true;
        }
        else
        {
            AudioListener.pause = false;
            soundButton.isOn = false;
        }
    }

    // Boolean that returns the value of the sound toggle.
    public bool soundEnabled() {
        return soundButton.isOn;
    }

    // Toggles sound based off the value of soundEnabled.
    public void SoundToggle () {
        if (!soundEnabled())
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("volume", 1);
            Debug.Log("Volume on");
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("volume", 0);
            Debug.Log("Volume off");
        }
    }
}
