using UnityEngine;
using System.Collections;

public class FastShip : Ship
{
    // Use this for initialization   

	private const float MAX_SPEED = 5f;
	private const float ROT_SPEED = 180f;
	private const float BOUNDARY_RADIUS = 0.5f;

	private bool _speedBoost = false;
	private bool _shields = false;
	private bool _enhancedShot = false;

	new void Start()
    {
		this._maxSpeed = MAX_SPEED;

		this._rotSpeed = ROT_SPEED; //speed we can turn in 1 sec

		this._shipBoundaryRadius = BOUNDARY_RADIUS;
    }

		// Update is called once per frame
	new void Update()
    {
		Movement();
    }

	protected override void Movement()
    {
        //** ROTATE THE SHIP **//
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        //minus to get the std rotaton (dxdx, sxsx)
        z -= Input.GetAxis("Horizontal") * _rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //** MOVE THE SHIP **//
        Vector3 pos = transform.position;

        //the sensitivity under InputManager gives the sensation of slow start and build up of velocity
        //this is what we want to have so it's independant from both keyboard and joystick
        // Input.GetAxis returns a FLOAT between -1.0 and 1.0 0 if not pressed
        Vector3 newPos = new Vector3(0, Input.GetAxis("Vertical") * _maxSpeed * Time.deltaTime, 0);

        pos += rot * newPos;

        //RESTRICT player to the cameras boundaries
        pos = this.BoundariesRestrictions(pos);

        transform.position = pos;

        //also valid, unless u wanna do stuff in betweed : transform.Translate( new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime))
    }

	override public void SpeedBoostOn() { _speedBoost = true; } 

	override public void ShieldsOn() { _shields = true; } 

	override public void EnhancedShotOn() { _enhancedShot = true; } 



}
