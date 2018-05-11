using UnityEngine;
using System.Collections;

public class ResistantShip : Ship
{

	private static readonly float MAX_SPEED = 3f;
	private static readonly float ROT_SPEED = 110f;
	private static readonly float BOUNDARY_RADIUS = 0.5f;
	private static readonly int HEALTH = 30;
	private static readonly float DAMAGE_DEALT = 0.5f;

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
