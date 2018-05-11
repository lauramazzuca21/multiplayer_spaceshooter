//ship with high damage and medium velocity


using UnityEngine;
using System.Collections;

public class StrongShip : Ship
{

	private static readonly float MAX_SPEED = 5f;
	private static readonly float ROT_SPEED = 150f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly int HEALTH = 20;
	private static readonly float DAMAGE_DEALT = 1f;

	private bool _speedBoost = false;
    private bool _shields = false;
    private bool _enhancedShot = false;


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

	public override void EnhancedShotOn()
    {
		_enhancedShot = true;
        
        StartCoroutine(this.SpeedBoostPowerDown());
	}

    public override void ShieldsOn()
    {
		_shields = true;
        
        StartCoroutine(this.SpeedBoostPowerDown());    
	}

	public override void SpeedBoostOn(float speedMultiplyer)
    {
		_speedBoost = true;
		MaxSpeed = MaxSpeed * speedMultiplyer;
		StartCoroutine(this.SpeedBoostPowerDown());

	}

	protected IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        _speedBoost = false;
		MaxSpeed = MAX_SPEED;

    }
   
}
