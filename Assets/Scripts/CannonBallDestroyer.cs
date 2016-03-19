using UnityEngine;

public class CannonBallDestroyer : MonoBehaviour {

    private GameResultHandler ResultHandler;

    void Start() {
        ResultHandler = GameObject.FindGameObjectWithTag("_GM_").GetComponent<GameResultHandler>();
    }

	// Called when something enters the trigger.
	void OnTriggerEnter2D (Collider2D col) {
        ResultHandler.numOfActiveCannonBalls--;
        Destroy(col.transform.gameObject);
	}
	
}
