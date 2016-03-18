using UnityEngine;
using System.Collections;

public abstract class DestroyableBall : MonoBehaviour {

    private float timeToWait = 1F;
    private bool isWaiting = false;

    /// <summary>
    /// This method should be used for any special behaviour the ball has when being destroyed.
    /// </summary>
    public abstract void OnDestruction();

    /// <summary>
    /// This method should be used for any special behaviour the ball has when it is hit.
    /// </summary>
    public abstract void OnHit();

    /// <summary>
    /// This method should be used to Set The Balls Initial Color.
    /// </summary>
    public abstract void SetBallsColor();

    // Start is called on initialization.
    void Start()
    {
        SetBallsColor();
    }

    // Update is called once per frame.
    void Update()
    {
        if (isWaiting)
        {
            timeToWait -= Time.deltaTime;
            if (timeToWait <= 0)
            {
                OnDestruction();
                Destroy(gameObject);
                isWaiting = false;
                timeToWait = 1F;
            }
        }
    }

    // OnCollisionEnter2D is called when an object collides with this object.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isWaiting)
        {
            isWaiting = true;
            OnHit();
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.25f);
        }
    }
}
