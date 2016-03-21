using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private Transform endOfCannon;

    [SerializeField]
    private GameObject cannonBallPrefab;

    public int cannonBallCount;

    private float speed = 0.25F;
    private float TouchTime;

    private GameResultHandler gResHand;

    // Used for things that need to be called after start from another object.
    public void Init() {
        gResHand = GameObject.FindGameObjectWithTag("_GM_").GetComponent<GameResultHandler>();
        cannonBallCount = Mathf.Max(1, gResHand.gameObject.GetComponent<BallSetupHandler>().numOfRed - 1);
    }

    void shoot() {
        if (cannonBallCount > 0 && gResHand.numOfActiveCannonBalls == 0)
        {
            gResHand.numOfActiveCannonBalls++;
            cannonBallCount--;
            GameObject cannonBall = (GameObject)GameObject.Instantiate(cannonBallPrefab, endOfCannon.position, Quaternion.Euler(0, 0, 0));
            cannonBall.GetComponent<Rigidbody2D>().velocity = -transform.up * 5;
        }
    }

    // Update is called once per frame
    void Update() {
    #if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            shoot();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, speed * 4);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -speed * 4);
        }
    #endif

    #if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TouchTime = Time.time;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (Time.time - TouchTime <= 0.2)
                {
                    shoot();
                }
            }

            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                // Rotates object to desired position.
                transform.Rotate(0, 0, touchDeltaPosition.x * speed);
            }
        }
    #endif
    }
}