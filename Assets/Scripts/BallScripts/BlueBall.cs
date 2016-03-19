using UnityEngine;

/// <summary>
/// For info on how to use see
/// <see cref="DestroyableBall"/>
/// </summary>

public class BlueBall : DestroyableBall
{

    public override void OnDestruction()
    {

    }

    public override void SetBallsColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 100, 255, 255);
    }

    public override void OnHit()
    {

    }
}
