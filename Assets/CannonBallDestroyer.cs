using UnityEngine;

public class CannonBallDestroyer : MonoBehaviour {

	// Called when something enters the trigger.
	void OnTriggerEnter2D (Collider2D col) {
        Destroy(col.transform.gameObject);
	}
	
}
