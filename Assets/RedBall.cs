using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// For info on how to use see
/// <see cref="DestroyableBall"/>
/// </summary>

public class RedBall : DestroyableBall
{
    private BallSetupHandler bSetupHand;

    public override void OnDestruction()
    {
        bSetupHand.numOfRed--;
    }

    public override void SetBallsColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 20, 40, 255);
    }

    public override void OnHit()
    {
        bSetupHand = GameObject.Find("_Game_Manager_").GetComponent<BallSetupHandler>();
    }
}
