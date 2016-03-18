using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallSetupHandler : MonoBehaviour {

    [SerializeField]
    private GameObject ballPrefab;

    private GameObject[] ballArray;

    private int numOfBlank;
    private int numOfBlue;
    public int numOfRed;
    private int numOfSpecial;

    // Use this for initialization
    void Start () {
        ballArray = GameObject.FindGameObjectsWithTag("BlankBall");
        numOfBlank = ballArray.Length;
        if (ballArray.Length < 6)
        {
            int numRequired = 6 - numOfBlank;
            Debug.LogError("Not enough balls in this level. at least 6 are required for basic level. add " + numRequired + " more balls to the level to make it work.");
        }
        for (int i = 0; i < ballArray.Length; i++)
        {
            if (numOfBlue != ballArray.Length / 2 )
            {
                numOfBlank--;
                numOfBlue++;
                ballArray[i].tag = "BlueBall";
                ballArray[i].AddComponent<BlueBall>();
            }
            else if (numOfRed != ballArray.Length / 6)
            {
                numOfBlank--;
                numOfRed++;
                ballArray[i].tag = "RedBall";
                ballArray[i].AddComponent<RedBall>();
            }
            else
            {
                if (numOfBlank >= 0)
                {
                    ballArray[i].tag = "BlueBall";
                    ballArray[i].AddComponent<BlueBall>();
                }
            }
        }
        Debug.Log("Number of Blank balls Was : " + numOfBlank);
        Debug.Log("Number of Blue balls Was : " + numOfBlue);
        int numOfBlueAfterBalanks = numOfBlue + numOfBlank;
        Debug.Log("Replaced blanks num of Blues is now :" + numOfBlueAfterBalanks);
        Debug.Log("Number of Red balls is : " + numOfRed);
        Debug.Log("Number of Special balls is : " + numOfSpecial);
    }
}
