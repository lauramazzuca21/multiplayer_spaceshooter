using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {


	private static readonly float DEFAULT_FIREDELAY = 0.25f;

	[SerializeField]
	private GameObject _bulletPrefab;
	private Ship _owner;
	private float _enhancedShotDelay = 0;
	private float _cooldownTimer = 0;

	public float EnhancedShotDelay 
	{
		get { return this._enhancedShotDelay; }
		set { this._enhancedShotDelay = value; }
	}
   

	// Use this for initialization
	private void Start () {
		_owner = gameObject.GetComponentInParent<Ship>();
	}

	// Update is called once per frame
	private void Update () {
		_cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && _cooldownTimer <= 0) {

			if (_owner.EnhancedShotStatus)
			{
				_cooldownTimer = DEFAULT_FIREDELAY + EnhancedShotDelay;

			} else 
			{
				_cooldownTimer = DEFAULT_FIREDELAY;

                Instantiate(_bulletPrefab, transform.position, transform.rotation);
			}

		}
	}


}
