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
	private bool _isDead = false;
	private float _health;

	private Ship _owner;

	private Animator _deathAnimation;

    private ScoreManager _scoremanager; //per notify Death


	private void Start()
	{
		_correctLayer = gameObject.layer;
		_owner = gameObject.GetComponent<Ship>();

		_deathAnimation = GetComponent<Animator>();
	}


	private void Update()
	{
		if (Health <= 0) Die(); //_deathAnimation.SetBool("ShipIsDead", true);

		if (this.gameObject.layer == INVULN_LAYER)
		{
			_invulnTimer -= Time.deltaTime;

			if (_invulnTimer <= 0) gameObject.layer = this._correctLayer;
		}
	}

	public void Die() 
	{
		_isDead = true;
		gameObject.SetActive(false);
	}

    //metodi su modello di dominio:
     
    public float Health
    {
        get { return this._health; }
        set { this._health = value; }
    }


    public void takeDamage(float damageTaken)
    {
        Health -= damageTaken;
        gameObject.layer = INVULN_LAYER;
        _invulnTimer = INVULN_TIMER;

    }

    public void notifyDeath()
    {
         //dice allo score manager che è morto e di aggiornare lo score
    }

    public Boolean GetIsDead()
    {
        return _isDead;
    }

}
