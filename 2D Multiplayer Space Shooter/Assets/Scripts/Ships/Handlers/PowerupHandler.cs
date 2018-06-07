using UnityEngine;
using System.Collections;

public class PowerupHandler : MonoBehaviour
{
	[SerializeField]
    private GameObject _shieldPrefab;

	//bools for powerup activation tracking
    private bool _speedBoost = false;
    private bool _shields = false;
    private bool _enhancedShot = false;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// ****   PowerUps handlers   **** \\
    //these public classes will be directly called by the respective PoweUps once they collide with a ship
    public void EnhancedShotOn(float shotDamage, float shotSpeed)
	{
		
	}

    public void ShieldsOn()
	{

		ActivateShield();
	}

	public void SpeedBoostOn(float speedMultiplyer)
	{
		if (!SpeedBoostStatus)
        {
            SpeedBoostStatus = true;
            // Changes the speed at which the ship moves linearly
            MaxSpeed = MaxSpeed * speedMultiplyer;
            //start the automatic power down coroutine
            StartCoroutine(this.SpeedBoostPowerDown());
        }
	}

    //haven't reset maxspeed in ship yet!!
	protected IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        SpeedBoostStatus = false;

    }

	private void ActivateShield()
    {
        _shieldPrefab.SetActive(true);
    }

    private void DeactivateShield()
    {
        _shieldPrefab.SetActive(false);
    }
}

