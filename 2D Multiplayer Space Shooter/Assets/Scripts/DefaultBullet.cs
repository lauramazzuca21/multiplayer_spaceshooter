using UnityEngine;
using System.Collections;

public class DefaultBullet : Bullet
{
	protected static readonly float DEFAULT_SPEED = 8f;
    protected static readonly float DEFAULT_DAMAGE = 5f;
   
    // Use this for initialization
	protected override void Start()
    {
		WidthOrtho = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		this.Speed = DEFAULT_SPEED;
		this.Damage = DEFAULT_DAMAGE;
    }

    // Update is called once per frame
	protected override void Update()
    {
        Movement();
    }


    //** MOVE THE BULLET **//
	protected override void Movement()
    {
        Vector3 pos = transform.position;

		Vector3 newPos = new Vector3(0, Speed * Time.deltaTime, 0);

        pos += transform.rotation * newPos;
        transform.position = pos;
        
        //destroy if it reaches the borders or if the timer rings
        if (pos.y > Camera.main.orthographicSize
            || pos.y < -Camera.main.orthographicSize
            || pos.x > WidthOrtho
		    || pos.x < -WidthOrtho)
        {
            Destroy(gameObject);
        }
    }

	protected override void OnTriggerEnter2D(Collider2D collision)
    {

		ShipLifeHandler shipCollidedWithHandler = collision.gameObject.GetComponent<ShipLifeHandler>();
        if (shipCollidedWithHandler != null)
        {
			shipCollidedWithHandler.takeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
