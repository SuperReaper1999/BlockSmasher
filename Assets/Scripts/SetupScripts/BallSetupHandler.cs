using UnityEngine;
using System.Collections.Generic;

public class BallSetupHandler : MonoBehaviour {

    [SerializeField]
    private GameObject ballPrefab;

    private List<GameObject> ballList = new List<GameObject>();

    [SerializeField]
    private AudioClip redBallSound;
    [SerializeField]
    private AudioClip blueBallSound;
    [SerializeField]
    private AudioClip specialBallSound;

    private int numOfBlank;
    private int numOfBlue;
    public int numOfRed;
    private int numOfSpecial;

    // Called on initialization.
    void Start () {
        numOfRed = 0;
        PlayerInputHandler player = GameObject.FindWithTag("Player").GetComponent<PlayerInputHandler>();
        System.Random rand = new System.Random();
        ballList.AddRange(GameObject.FindGameObjectsWithTag("BlankBall"));
        numOfBlank = ballList.Count;
        int numOfRedsToPlace = Mathf.Max(1, ballList.Count / 6);
        for (int i = 0; i < numOfRedsToPlace; i++)
        {
                numOfBlank--;
                numOfRed++;
                int num = rand.Next(ballList.Count);
                ballList[num].tag = "RedBall";
                ballList[num].AddComponent<RedBall>();
                ballList[num].GetComponent<AudioSource>().clip = redBallSound;
                ballList[num].GetComponent<AudioSource>().volume = 0.5f;
                ballList.RemoveAt(num);
        }
        foreach (GameObject go in ballList)
        {
            go.tag = "BlueBall";
            go.AddComponent<BlueBall>();
            go.GetComponent<AudioSource>().clip = blueBallSound;
            go.GetComponent<AudioSource>().volume = 0.4f;
            numOfBlank--;
            numOfBlue++;
        }
        if (numOfRed > 6)
        {
            numOfSpecial++;
            int num = rand.Next(ballList.Count);
            ballList[num].tag = "SpecialBall";
            ballList[num].AddComponent<SpecialBall>();
            ballList[num].GetComponent<AudioSource>().volume = 1f;
            ballList[num].GetComponent<AudioSource>().clip = specialBallSound;
        }
        Debug.Log("The number of balls total is : " + (numOfBlue + numOfRed + numOfSpecial));
        player.Init();
    }
}
