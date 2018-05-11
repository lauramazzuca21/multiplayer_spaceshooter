using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	[SerializeField]
	private GameObject bulletPrefab;
	private float fireDelay = 0.25f;

	private float cooldownTimer = 0;

	// Use this for initialization
	private void Start () {
		
	}

	// Update is called once per frame
	private void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
			cooldownTimer = fireDelay;
           
			Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
	}
}
