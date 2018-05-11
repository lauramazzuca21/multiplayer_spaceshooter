﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour 
{

    //in physics 2D Invulnerable layer is set to not collide with anything
	private static readonly int INVULN_LAYER = 12;
	private static readonly String POWERUP = "PowerUp";
	private static readonly float INVULN_TIMER = 0.5f;

	[SerializeField]
	private int _correctLayer;
	private float _invulnTimer = 0;
	Ship _owner;

	private void Start()
	{
		_correctLayer = gameObject.layer;
		_owner = gameObject.GetComponent<Ship>();
	}


	private void Update()
	{
		if (_owner.Health <= 0) Die();

		if (this.gameObject.layer == INVULN_LAYER)
		{
			_invulnTimer -= Time.deltaTime;

			if (_invulnTimer <= 0) gameObject.layer = this._correctLayer;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
  

    }


    private void takeDamage()
    {
		_owner.Health--;
        gameObject.layer = INVULN_LAYER;
		_invulnTimer = INVULN_TIMER;
    }


	private void Die() 
	{
		Destroy(gameObject);
	}
}
