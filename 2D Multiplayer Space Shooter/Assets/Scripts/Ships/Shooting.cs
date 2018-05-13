using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private static readonly float DEFAULT_FIREDELAY = 0.25f;

	[SerializeField]
	private GameObject _bulletPrefab;
	[SerializeField]
	private GameObject _enhancedBulletPrefab;

	private Ship _owner;   
	private Bullet bullet;

	private float _cooldownTimer;
 
	private float _enhancedShotDamage;
	private float _enhancedShotSpeed;  

	public float EnhancedShotDamage
    {
		get { return this._enhancedShotDamage; }
		set { this._enhancedShotDamage = value; }
    }

	public float EnhancedShotSpeed
    {
		get { return this._enhancedShotSpeed; }
		set { this._enhancedShotSpeed = value; }
    }

	// Use this for initialization
	private void Start () {
		_owner = gameObject.GetComponentInParent<Ship>();
		_cooldownTimer = DEFAULT_FIREDELAY;
	}

	// Update is called once per frame
	private void Update () {
		_cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && _cooldownTimer <= 0) {

			if (_owner.EnhancedShotStatus)
			{
				bullet = Instantiate(_enhancedBulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
				bullet.Damage = (bullet.Damage + EnhancedShotDamage) * _owner.DamageDealtModifier;
                bullet.Speed += EnhancedShotSpeed;
				_owner.EnhancedShotStatus = false;

			} 
			else 
			{
				_cooldownTimer = DEFAULT_FIREDELAY;

				bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
				bullet.Damage = bullet.Damage * _owner.DamageDealtModifier;
			}

		}
	}
}
