using UnityEngine;

public abstract class DestroyableBall : MonoBehaviour {

    private float timeToWait = 0.75F;
    private bool isWaiting = false;
    public AudioClip ballSound;
    public BallSetupHandler bSetupHand;

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
        bSetupHand = GameObject.FindWithTag("_GM_").GetComponent<BallSetupHandler>();
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
                timeToWait = 0.75f;
            }
        }
    }

    // OnCollisionEnter2D is called when an object collides with this object.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isWaiting)
        {
            isWaiting = true;
            GetComponent<AudioSource>().Play();
            OnHit();
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.25f);
        }
    }
}
