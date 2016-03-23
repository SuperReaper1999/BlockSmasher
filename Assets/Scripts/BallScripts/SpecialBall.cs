using UnityEngine;

/// <summary>
/// For info on how to use see
/// <see cref="DestroyableBall"/>
/// </summary>

public class SpecialBall : DestroyableBall {

    public override void OnDestruction()
    {

    }

    public override void SetBallsColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
    }

    public override void OnHit()
    {
        System.Random rand = new System.Random();
        PlayerPowerupHandler powerUpHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPowerupHandler>();
        powerUpHandler.PowerUpActivator(rand.Next(powerUpHandler.powerUps.Length));
    }
}
