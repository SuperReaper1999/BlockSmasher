using UnityEngine;

public class GameResultHandler : MonoBehaviour {

    private bool isWon = false;
    private bool isLost = false;
    public int numOfActiveCannonBalls;

    private PlayerInputHandler player;
    private BallSetupHandler ballSetup;

    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LoseUI;
    [SerializeField]
    private GameObject PauseUI;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerInputHandler>();
        ballSetup = GameObject.FindGameObjectWithTag("_GM_").GetComponent<BallSetupHandler>();
    }

	// Fixed Update is called once per fixed interval.
	void FixedUpdate () {
        if (numOfActiveCannonBalls == 0 && player.cannonBallCount == 0 && ballSetup.numOfRed > 0 && !isLost)
        {
            isLost = true;
            ResultHandler();
            Debug.Log("Lose");
        }
        else if (numOfActiveCannonBalls == 0 && ballSetup.numOfRed == 0 && !isWon)
        {
            isWon = true;
            ResultHandler();
            Debug.Log("Win");
        }
    }

    // Checks if game is won or lost.
    void ResultHandler() {
        if (isWon == true)
        {
            ResultUiHandler(true);
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        }
        else if (isLost == true)
        {
            ResultUiHandler(false);
        }
    }

    // Sets the correct UI to be active.
    void ResultUiHandler(bool Result)
    {
        player.enabled = false;
        gameUI.SetActive(true);
        PauseUI.SetActive(false);
        WinUI.SetActive(Result);
        LoseUI.SetActive(!Result);
    }
}
