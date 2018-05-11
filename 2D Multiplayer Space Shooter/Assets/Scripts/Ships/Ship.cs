using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour {

	//if i declare them public i can change their values in unity
	//changing the number here now it only changes the default so if i create a new ship i get this but if i change it in unity that'll be the used one
    
	[SerializeField]
	private float _maxSpeed;
	private float _rotSpeed; //speed we can turn in 1 sec
	private float _shipBoundaryRadius;

	private int _health;
	private float _damageDealt;

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

	public int Health
    {
        get { return this._health; }
        set { this._health = value; }
    }

	public float DamageDealt
    {
		get { return this._damageDealt; }
		set { this._damageDealt = value; }
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
      
	public abstract void EnhancedShotOn();

	public abstract void ShieldsOn();

	public abstract void SpeedBoostOn(float speedMultiplyer);

	//Updates once per pick of the physics frame
	private void FixedUpdate () {}
}
