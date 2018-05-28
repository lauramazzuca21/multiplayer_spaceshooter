using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private static readonly float DEFAULT_FIREDELAY = 0.25f;

	[SerializeField]
	private GameObject _bulletPrefab;
	[SerializeField]
	private GameObject _enhancedBulletPrefab;
	[SerializeField]
	private AudioClip _bulletSound;
	[SerializeField]
	private AudioClip _enhancedBulletSound;

	private Ship _owner;   
	private GameObject bullet;
	private Bullet bulletFunctions;

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
			_cooldownTimer = DEFAULT_FIREDELAY;
			if (_owner.EnhancedShotStatus)
			{
				bullet = Instantiate(_enhancedBulletPrefab, transform.position, transform.rotation);
				bullet.layer = gameObject.layer;

				bulletFunctions = bullet.GetComponent<Bullet>();            
				//modifier so that the bullet damages the enemies its default value times the owner ship modifier
				bulletFunctions.Damage = (bulletFunctions.Damage + EnhancedShotDamage) * _owner.DamageDealtModifier;
				bulletFunctions.Speed += EnhancedShotSpeed;
				AudioSource.PlayClipAtPoint(_enhancedBulletSound, transform.position);

				_owner.EnhancedShotStatus = false;

			} 
			else 
			{
				bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
				bullet.layer = gameObject.layer;
                
                bulletFunctions = bullet.GetComponent<Bullet>();
				//modifier so that the bullet damages the enemies its default value times the owner ship modifier
				bulletFunctions.Damage = bulletFunctions.Damage * _owner.DamageDealtModifier;

				AudioSource.PlayClipAtPoint(_bulletSound, transform.position);
			}

		}
	}
}
