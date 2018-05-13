using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour
{
	private float yBoundaries;
	private float xBoundaries;
	private float TIMER_VALUE = 10f;
	private float timer;
	private Vector3 randomSpawn;
	[SerializeField]
	private GameObject _speedBoostPrefab;
	[SerializeField]
    private GameObject _enhancedShotPrefab;
    // Use this for initialization
    void Start()
    {
		timer = TIMER_VALUE;
		randomSpawn = new Vector3();
		yBoundaries = Camera.main.orthographicSize - 1f;
		xBoundaries = (Camera.main.orthographicSize - 1f) * ((float)Screen.width / (float)Screen.height);
    } 

    // Update is called once per frame
    void Update()
    {
		timer -= Time.deltaTime;

        if (timer <= 0)
		{
			//**temporary**\\
			//int powerToGenerate = (int) (Random.value * 100) % powerUps.Length;
			randomSpawn.y = Random.Range(-yBoundaries, yBoundaries);
			randomSpawn.x = Random.Range(-xBoundaries, xBoundaries);
			if (((int)Random.value % 2) == 1) 
			{
				Instantiate(_speedBoostPrefab, randomSpawn, new Quaternion(0, 0, 0, 0));
			}
			else
			{
				Instantiate(_enhancedShotPrefab, randomSpawn, new Quaternion(0, 0, 0, 0));

			}
			timer = TIMER_VALUE;
		}
    }
}
