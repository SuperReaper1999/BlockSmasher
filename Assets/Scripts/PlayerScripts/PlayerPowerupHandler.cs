using UnityEngine;
using System.Collections;

public class PlayerPowerupHandler : MonoBehaviour {

    [HideInInspector]
    public bool powerUpIsActive = false;

    [HideInInspector]
    public int powerUpUsesRemaining;

    [HideInInspector]
    public int powerUpNumber;

    [HideInInspector]
    public string[] powerUps;

    // Called on initialization.
    void Start() {
        powerUps = new string[1];
        powerUps[0] = "TripleShot";
    }

	// Update is called once per frame
	void Update () {
        if (powerUpUsesRemaining == 0)
        {
            powerUpIsActive = false;
        }
	}

    // Called when the player shoots and uses their powerup.
    public void UseCurrentPowerUp()
    {
        if (powerUpUsesRemaining > 0)
        {
            powerUpUsesRemaining--;
        }
    }

    // This is called to set the type of powerup.
    public void PowerUpActivator(int PowerUpNum) {
        powerUpNumber = PowerUpNum;
        powerUpUsesRemaining = 2;
        powerUpIsActive = true;
    }
}
