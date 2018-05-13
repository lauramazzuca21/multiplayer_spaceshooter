using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private static readonly float DEFAULT_SPEED = 5f;
	private static readonly float DEFAULT_DAMAGE = 5f;

	private float _timer = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		Movement();
	}


	//** MOVE THE BULLET **//
	private void Movement()
	{
		Vector3 pos = transform.position;

		Vector3 newPos = new Vector3(0, DEFAULT_SPEED * Time.deltaTime, 0);

		pos += transform.rotation * newPos;
		transform.position = pos;

		_timer -= Time.deltaTime;

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //destroy if it reaches the borders or if the timer rings
		if (pos.y > Camera.main.orthographicSize
			|| pos.y < -Camera.main.orthographicSize
			|| pos.x > widthOrtho
			|| pos.x < -widthOrtho
			|| _timer <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		ShipCollisionHandler shipCollidedWithHandler = collision.gameObject.GetComponent<ShipCollisionHandler>();
		if (shipCollidedWithHandler != null)
		{
			shipCollidedWithHandler.takeDamage(DEFAULT_DAMAGE);
			Destroy(gameObject);         
		}
	}
}
