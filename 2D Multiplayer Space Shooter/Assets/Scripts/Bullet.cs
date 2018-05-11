using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {

		//** MOVE THE BULLET **//
        Vector3 pos = transform.position;
       
        Vector3 newPos = new Vector3(0, maxSpeed * Time.deltaTime, 0);

		pos += transform.rotation * newPos;
        transform.position = pos;
        
	}
}
