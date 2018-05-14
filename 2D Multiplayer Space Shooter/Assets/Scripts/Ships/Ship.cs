//Abstract class to define what a generic ship should implement


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour {

        
	[SerializeField] //field right under the declaration will be visible in unity
	private float _maxSpeed; //speed we can reach in 1 sec
	private float _rotSpeed; //speed we can turn in 1 sec
	private float _shipBoundaryRadius; //radius of the ship to not go over the screen limits

	private float _health;
	//modifier for each ship that will be passed to Shooting and then Bullet to make the damage dealt balanced.
    // The modifier is supposed to be a percentage so it must in the [0.0, 1.0] range.
	private float _damageDealtModifier; 

    //bools for powerup activation tracking
	private bool _speedBoost = false;
    private bool _shields = false;
    private bool _enhancedShot = false;

	[SerializeField]
	private GameObject destroyedAnimation;

    public GameObject DestroyedAnimation
    {
        get { return this.destroyedAnimation; }
        set { this.destroyedAnimation = value; }
    }

	public float MaxSpeed
    {
		get { return this._maxSpeed; }
		set { this._maxSpeed = value; }
    }

	public float RotSpeed
    {
		get { return this._rotSpeed; }
		set { this._rotSpeed = value; }
    }

	public float ShipBoundaryRadius
    {
		get { return this._shipBoundaryRadius; }
		set { this._shipBoundaryRadius = value; }
    }

	public float Health
    {
        get { return this._health; }
        set { this._health = value; }
    }

	public float DamageDealtModifier
    {
		get { return this._damageDealtModifier; }
		set { this._damageDealtModifier = value; }
    }

	public bool SpeedBoostStatus
    {
		get { return this._speedBoost; }
		set { this._speedBoost = value; }
    }

	public bool ShieldsStatus
    {
        get { return this._shields; }
        set { this._shields = value; }
    }

	public bool EnhancedShotStatus
    {
		get { return this._enhancedShot; }
		set { this._enhancedShot = value; }
    }

	// Use this for initialization
	protected abstract void Start();

	// Update is called once per frame
	//where you check player input
	//it runs 30 to 60 fps
	protected abstract void Update();

	protected abstract void Movement();

    //implemented here because the algorythm must be equal to all ships.
	protected Vector3 BoundariesRestrictions(Vector3 pos)
	{
		if (pos.y + _shipBoundaryRadius > Camera.main.orthographicSize)
		{
			pos.y = Camera.main.orthographicSize - _shipBoundaryRadius;
		}

		else if (pos.y - _shipBoundaryRadius < -Camera.main.orthographicSize)
		{
			pos.y = -Camera.main.orthographicSize + _shipBoundaryRadius;
		}

		//for x axis we need the ratio

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + _shipBoundaryRadius > widthOrtho)
		{
			pos.x = widthOrtho - _shipBoundaryRadius;
		}
        else if (pos.x - _shipBoundaryRadius < -widthOrtho)
		{
			pos.x = -widthOrtho + _shipBoundaryRadius;
		}

		return pos;
	}
     
	// ****   PowerUps handlers   **** \\
	//these public classes will be directly called by the respective PoweUps once they collide with a ship
	public abstract void EnhancedShotOn(float shotDamage, float shotSpeed);

	public abstract void ShieldsOn();

	public abstract void SpeedBoostOn(float speedMultiplyer);
   
}
