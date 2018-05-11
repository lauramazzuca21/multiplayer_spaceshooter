using UnityEngine;
using System.Collections;

public class ResistantShip : Ship
{

	private static readonly float MAX_SPEED = 5f;
	private static readonly float ROT_SPEED = 180f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly int HEALTH = 15;
	private static readonly float DAMAGE_DEALT = 0.5f;

	public override void EnhancedShotOn()
	{
		throw new System.NotImplementedException();
	}

	public override void ShieldsOn()
	{
		throw new System.NotImplementedException();
	}

	public override void SpeedBoostOn(float speedMultiplyer)
	{
		throw new System.NotImplementedException();
	}

	protected override void Movement()
	{
		throw new System.NotImplementedException();
	}

	// Use this for initialization
	override protected void Start()
    {
		MaxSpeed = MAX_SPEED;
        RotSpeed = ROT_SPEED; //speed we can turn in 1 sec
        ShipBoundaryRadius = BOUNDARY_RADIUS;

        Health = HEALTH;
        DamageDealt = DAMAGE_DEALT;
    }

    // Update is called once per frame
	override protected void Update()
    {

    }
}
