using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float maxSpeed = 5f;
	public float timer = 1f;

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
       
		timer -= Time.deltaTime;
        
		float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.y > Camera.main.orthographicSize
            || pos.y < -Camera.main.orthographicSize
            || pos.x > widthOrtho
            || pos.x < -widthOrtho
            || timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
