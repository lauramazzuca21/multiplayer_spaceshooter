//FOR EXTENDED INFO ABOUT METHODS AND VARIABLES CHECK SHIP CLASS

// Abilities:
// * average speed (both linear and rotational);     * average health;      * high damage dealt modifier


using UnityEngine;
using System.Collections;

public class StrongShip : Ship
{

	private static readonly float MAX_SPEED = 5f;
	private static readonly float ROT_SPEED = 150f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly float HEALTH = 20f;
	private static readonly float DAMAGE_DEALT_MODIFIER = 1f;

	//components to call methods in Handlers
    private ShieldHandler _shieldHandler;
    private ShipLifeHandler _lifeHandler;
    private ShootHandler _shootHandler;
	private PowerupHandler _powerupHandler;



    override protected void Start()
    {
        _shootHandler = gameObject.GetComponentInChildren<ShootHandler>();
        _shieldHandler = gameObject.GetComponentInChildren<ShieldHandler>();
        _lifeHandler = gameObject.GetComponent<ShipLifeHandler>();
		_powerupHandler = gameObject.GetComponent<PowerupHandler>();

        MaxSpeed = MAX_SPEED; //speed we can reach in 1 sec
        RotSpeed = ROT_SPEED; //speed we can turn in 1 sec
        ShipBoundaryRadius = BOUNDARY_RADIUS;

        _lifeHandler.Health = HEALTH;
        _shootHandler.DamageDealtModifier = DAMAGE_DEALT_MODIFIER;

    }

    // Update is called once per frame
	override protected void Update()
	{

		Movement();
    }

	protected override void Movement()
    {
		//** ROTATE THE SHIP **//
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        //minus to get the std rotaton (dxdx, sxsx)
        z -= Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //** MOVE THE SHIP **//
        Vector3 pos = transform.position;

        //this is what we want to have so it's independant from both keyboard and joystick
        // Input.GetAxis returns a FLOAT between -1.0 and 1.0 0 if not pressed
        Vector3 newPos = new Vector3(0, Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime, 0);

        pos += rot * newPos;

        //RESTRICT player to the cameras boundaries
        pos = this.BoundariesRestrictions(pos);

        transform.position = pos;

        //also valid, unless u wanna do stuff in betweed :
		//transform.Translate( new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime))
    }

	public override void EnhancedShotOn(float shotDamage, float shotSpeed)
    {
		if (!EnhancedShotStatus)
		{
			EnhancedShotStatus = true;
			//changes the attributes of Shooting. 
			//Power down handled by Shooting after one EnhancedShot is shot setting false EnhancedShotStatus.
			_shootHandler.EnhancedShotDamage = shotDamage;
			_shootHandler.EnhancedShotSpeed = shotSpeed;
		}
	}

    public override void ShieldsOn()
    {
		if (!ShieldsStatus)
		{
			ShieldsStatus = true;
			_shieldHandler.ActivateShield();
			StartCoroutine(this.ShieldsPowerDown());
		}
	}

	protected IEnumerator ShieldsPowerDown()
    {
		yield return new WaitForSeconds(150.0f);
		_shieldHandler.DeactivateShield();
		ShieldsStatus = false;

    }
    
	public override void SpeedBoostOn(float speedMultiplyer)
    {
		

	}

    
   
}
