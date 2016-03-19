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

    // Start is called on initialization.
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    #if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GameObject cannonBall = (GameObject)GameObject.Instantiate(cannonBallPrefab, endOfCannon.position, Quaternion.Euler(0, 0, 0));
            cannonBall.GetComponent<Rigidbody2D>().velocity = -transform.up * 5;
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
                if (Time.time - TouchTime <= 0.2 && cannonBallCount <= 10)
                {
                    cannonBallCount--;
                    GameObject cannonBall =  (GameObject)GameObject.Instantiate(cannonBallPrefab, endOfCannon.position, Quaternion.Euler(0, 0, 0));
                    cannonBall.GetComponent<Rigidbody2D>().velocity = -transform.up * 5;
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