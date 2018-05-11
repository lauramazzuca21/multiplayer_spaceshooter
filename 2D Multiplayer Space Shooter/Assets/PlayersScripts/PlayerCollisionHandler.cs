using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour 
{

    //in physics 2D Invulnerable layer is set to not collide with anything
	private const int INVULN_LAYER = 12;
	private const String POWERUP = "PowerUp";
	private const String ENEMY = "";
	private const float INVULN_TIMER = 0.5f;

	[SerializeField]
	private int health = 1;
	private int correctLayer;
	private float invulnTimer = 0;

	private void Start()
	{
		correctLayer = gameObject.layer;
	}


	private void Update()
	{
		if (health <= 0) Die();

		if (this.gameObject.layer == INVULN_LAYER)
		{
			invulnTimer -= Time.deltaTime;

			if (invulnTimer <= 0) gameObject.layer = this.correctLayer;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case ENEMY:
                takeDamage();
                break;
            case POWERUP:
				usePowerUp(collision.gameObject);
                break;
            default:
                break;
        }

    }

    private void usePowerUp(GameObject gameObject)
    {



        throw new NotImplementedException();
    }

    private void takeDamage()
    {
        health--;

        gameObject.layer = INVULN_LAYER;
		invulnTimer = INVULN_TIMER;
    }


	private void Die() 
	{
		Destroy(gameObject);
	}
}
