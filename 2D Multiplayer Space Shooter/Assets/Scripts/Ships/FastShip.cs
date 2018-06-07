//FOR EXTENDED INFO ABOUT METHODS AND VARIABLES CHECK SHIP CLASS

// Abilities:
// * high speed (both linear and rotational);     * below average health;      * average damage dealt modifier

using UnityEngine;
using System.Collections;

public class FastShip : Ship
{
    // Use this for initialization   

	private static readonly float MAX_SPEED = 7f;
	private static readonly float ROT_SPEED = 180f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly float HEALTH = 15f;
	private static readonly float DAMAGE_DEALT_MODIFIER = 0.5f;

    //component to call methods in Handlers
	private ShieldHandler _shieldHandler;
	private ShipLifeHandler _lifeHandler;
	private ShootHandler _shootHandler;


    override protected void Start()
    {
		_shootHandler = gameObject.GetComponentInChildren<ShootHandler>();
        _shieldHandler = gameObject.GetComponentInChildren<ShieldHandler>();
		_lifeHandler = gameObject.GetComponent<ShipLifeHandler>();

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
		/* Input.GetAxis is what we want to have 
        * so it's independant from both keyboard and joystick */


        //** ROTATE THE SHIP **//
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        //minus to get the std rotaton (dxdx, sxsx)
        z -= Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //** MOVE THE SHIP **//
        Vector3 pos = transform.position;

        // Input.GetAxis returns a FLOAT between -1.0 and 1.0 0 if not pressed
        Vector3 newPos = new Vector3(0, Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime, 0);

        pos += rot * newPos;

        //RESTRICT player to the cameras boundaries
        pos = this.BoundariesRestrictions(pos);

        transform.position = pos;

		/* Also valid, unless u wanna do stuff in betweed :
         * transform.Translate( new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime))*/
    }

    public override void EnhancedShotOn(float shotDamage, float shotSpeed)
    {
        EnhancedShotStatus = true;

        /* Changes the attributes of Shooting. 
         * Power down handled by Shooting after one EnhancedShot 
         * is shot setting false EnhancedShotStatus. */

        _shooting.EnhancedShotDamage = shotDamage;
        _shooting.EnhancedShotSpeed = shotSpeed;
    }

	public override void ShieldsOn()
    {
        ShieldsStatus = true;
        _shieldHandler.ActivateShield();
        StartCoroutine(this.ShieldsPowerDown());
    }

    protected IEnumerator ShieldsPowerDown()
    {
        yield return new WaitForSeconds(150.0f);
        _shieldHandler.DeactivateShield();
        ShieldsStatus = false;

    }

    public override void SpeedBoostOn(float speedMultiplyer)
    {
        SpeedBoostStatus = true;
        // Changes the speed at which the ship moves linearly
        MaxSpeed = MaxSpeed * speedMultiplyer;
        //start the automatic power down coroutine
        StartCoroutine(this.SpeedBoostPowerDown());

    }

    /* IEnumerator grants the possibility to wait inactively 
     * for a certain amount of time and then continues to 
     * execute the code ater the yield call. */
    protected IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        SpeedBoostStatus = false;
        MaxSpeed = MAX_SPEED;

    }

}
