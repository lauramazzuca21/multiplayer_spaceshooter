﻿//ship with high damage and medium velocity


using UnityEngine;
using System.Collections;

public class StrongShip : Ship
{

	private static readonly float MAX_SPEED = 5f;
	private static readonly float ROT_SPEED = 150f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly float HEALTH = 20;
	private static readonly float DAMAGE_DEALT = 1f;

	private Shooting _shooting;

	// Use this for initialization
	override protected void Start()
    {
		MaxSpeed = MAX_SPEED;
        RotSpeed = ROT_SPEED; //speed we can turn in 1 sec
        ShipBoundaryRadius = BOUNDARY_RADIUS;
        
        Health = HEALTH;
        DamageDealt = DAMAGE_DEALT;

		_shooting = gameObject.GetComponentInChildren<Shooting>();
    }

    // Update is called once per frame
	override protected void Update()
    {
		Movement();
    }

	protected override void Movement()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;

        Vector3 newPos = new Vector3(0, Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime, 0);

        pos += rot * newPos;

        pos = this.BoundariesRestrictions(pos);

        transform.position = pos;
    }

	public override void EnhancedShotOn(float shotDamage, float shotSpeed, float shotFireDelay)
    {
		EnhancedShotStatus = true;
		_shooting.EnhancedShotDelay = shotFireDelay;
		StartCoroutine(this.EnhancedShotPowerDown());
	}

	protected IEnumerator EnhancedShotPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
		EnhancedShotStatus = false;

    }

    public override void ShieldsOn()
    {
		ShieldsStatus = true;
        StartCoroutine(this.ShieldsPowerDown());    
	}

	protected IEnumerator ShieldsPowerDown()
    {
		yield return new WaitForSeconds(3.0f);
		ShieldsStatus = false;

    }
    
	public override void SpeedBoostOn(float speedMultiplyer)
    {
		SpeedBoostStatus = true;
		MaxSpeed = MaxSpeed * speedMultiplyer;
		StartCoroutine(this.SpeedBoostPowerDown());

	}

	protected IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
		SpeedBoostStatus = false;
		MaxSpeed = MAX_SPEED;

    }
   
}
