using UnityEngine;

/// <summary>
/// For info on how to use see
/// <see cref="DestroyableBall"/>
/// </summary>

public class RedBall : DestroyableBall
{

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
        
    }
}
