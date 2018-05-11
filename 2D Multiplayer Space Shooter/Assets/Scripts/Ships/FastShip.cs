using UnityEngine;
using System.Collections;

public class FastShip : Ship
{
    // Use this for initialization   

	private static readonly float MAX_SPEED = 7f;
	private static readonly float ROT_SPEED = 180f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly int HEALTH = 15;
	private static readonly float DAMAGE_DEALT = 0.5f;
   
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

        //the sensitivity under InputManager gives the sensation of slow start and build up of velocity
        //this is what we want to have so it's independant from both keyboard and joystick
        // Input.GetAxis returns a FLOAT between -1.0 and 1.0 0 if not pressed
        Vector3 newPos = new Vector3(0, Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime, 0);

        pos += rot * newPos;

        //RESTRICT player to the cameras boundaries
        pos = this.BoundariesRestrictions(pos);

        transform.position = pos;

        //also valid, unless u wanna do stuff in betweed : transform.Translate( new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime))
    }

	public override void EnhancedShotOn()
    {
        EnhancedShotStatus = true;

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
