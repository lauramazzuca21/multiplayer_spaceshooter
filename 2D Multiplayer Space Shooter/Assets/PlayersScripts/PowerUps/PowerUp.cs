using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
	protected float lifeTimer;
	// Use this for initialization
	protected virtual void Start(){}

    // Update is called once per frame
	protected virtual void Update() {}
    
	protected virtual void OnTriggerEnter2D(Collider2D collision) {}
   
	protected void DestroyPowerUp()
	{
		Destroy(gameObject);
	}
}
