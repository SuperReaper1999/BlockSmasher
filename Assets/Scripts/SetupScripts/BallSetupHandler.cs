using UnityEngine;
using System.Collections.Generic;

public class BallSetupHandler : MonoBehaviour {

    [SerializeField]
    private GameObject ballPrefab;

    private List<GameObject> ballList = new List<GameObject>();

    private int numOfBlank;
    private int numOfBlue;
    public int numOfRed;
    private int numOfSpecial;



    // Use this for initialization
    void Start () {
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
                ballList.RemoveAt(num);
        }
        foreach (GameObject go in ballList)
        {
            go.tag = "BlueBall";
            go.AddComponent<BlueBall>();
        }
        player.Init();
    }
}
