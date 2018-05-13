using UnityEngine;
using System.Collections;

public class EnhancedShot : PowerUp
{
	private static readonly float LIFE_TIMER = 10f;
	private static readonly float SHOT_DAMAGE = 10f;
	private static readonly float SHOT_SPEED = 10f;
	private static readonly float SHOT_FIREDELAY = 10f;


    // Use this for initialization
    override protected void Start()
    {
        this.lifeTimer = LIFE_TIMER;
    }

    // Update is called once per frame
    override protected void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0) this.DestroyPowerUp();


    }

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        Ship shipCollided = collision.GetComponent<Ship>();


        if (shipCollided != null)
        {
			shipCollided.EnhancedShotOn(SHOT_DAMAGE, SHOT_SPEED, SHOT_FIREDELAY);
            this.DestroyPowerUp();
        }

    }
}
