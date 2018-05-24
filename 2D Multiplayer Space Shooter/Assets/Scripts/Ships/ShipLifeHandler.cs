//STILL DON'T KNOW IF IT'S BETTER TO KEEP THIS CLASS OR MOVE ITS CONTENT IN SHIP OR SOMETHING

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLifeHandler : MonoBehaviour 
{

    //in physics 2D Invulnerable layer is set to not collide with anything
	private static readonly int INVULN_LAYER = 12;
	private static readonly float INVULN_TIMER = 0.5f;

	[SerializeField]
	private int _correctLayer;
	private float _invulnTimer = 0;
	private Ship _owner;

	private Animator _deathAnimation;


	//public Animator DeathAnimation
    //{
    //    get { return this._deathAnimation; }
    //    set { this._deathAnimation = value; }
    //}


	private void Start()
	{
		_correctLayer = gameObject.layer;
		_owner = gameObject.GetComponent<Ship>();

		_deathAnimation = GetComponent<Animator>();
	}


	private void Update()
	{
		if (_owner.Health <= 0) Die(); //_deathAnimation.SetBool("ShipIsDead", true);

		if (this.gameObject.layer == INVULN_LAYER)
		{
			_invulnTimer -= Time.deltaTime;

			if (_invulnTimer <= 0) gameObject.layer = this._correctLayer;
		}
	}


    public void takeDamage(float damageTaken)
    {
		if (!_owner.ShieldsStatus)
		{
			_owner.Health -= damageTaken;
            gameObject.layer = INVULN_LAYER;
            _invulnTimer = INVULN_TIMER;
		}
    }


	public void Die() 
	{
    		Destroy(gameObject);
	}

   
}
