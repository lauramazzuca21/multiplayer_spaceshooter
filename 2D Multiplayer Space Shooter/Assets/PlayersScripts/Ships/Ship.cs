using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	//if i declare them public i can change their values in unity
	//changing the number here now it only changes the default so if i create a new ship i get this but if i change it in unity that'll be the used one

	[SerializeField]
	protected float _maxSpeed;
	protected float _rotSpeed; //speed we can turn in 1 sec

	protected float _shipBoundaryRadius;

    

	// Use this for initialization
	protected void Start (){}
	
	// Update is called once per frame
    //where you check player input
    //it runs 30 to 60 fps
	protected void Update () {}

	protected virtual void Movement() {}

	protected Vector3 BoundariesRestrictions(Vector3 pos)
	{
		if (pos.y + _shipBoundaryRadius > Camera.main.orthographicSize)
		{
			pos.y = Camera.main.orthographicSize - _shipBoundaryRadius;
		}

		else if (pos.y - _shipBoundaryRadius < -Camera.main.orthographicSize)
		{
			pos.y = -Camera.main.orthographicSize + _shipBoundaryRadius;
		}

		//for x axis we need the ratio

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + _shipBoundaryRadius > widthOrtho)
		{
			pos.x = widthOrtho - _shipBoundaryRadius;
		}
        else if (pos.x - _shipBoundaryRadius < -widthOrtho)
		{
			pos.x = -widthOrtho + _shipBoundaryRadius;
		}

		return pos;
	}

	//protected virtual void PowerUpManager (PowerUp powerUp) 
	//{
	//	switch(powerUp.name)
	//	{
	//		case "SpeedBoost":
	//			SpeedBoostManager();
	//			break;
	//		case "Shield":
	//			ShieldManager();
	//			break;
	//		case "EnhancedShot":
	//			EnhancedShotManager();
	//			break;
	//		default:
	//			break;
	//	}
	//}

	public virtual void EnhancedShotOn(){}

	public virtual void ShieldsOn(){}

	public virtual void SpeedBoostOn(){}

	//Updates once per pick of the physics frame
	private void FixedUpdate () {}
}
