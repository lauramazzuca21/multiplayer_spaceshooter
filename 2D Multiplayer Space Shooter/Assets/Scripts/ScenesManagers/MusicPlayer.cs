using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer _instance = null;

    //this is best to implement the Singleton pattern for MusicPlayer instance
	private void Awake()
	{
		if (_instance != null) { Destroy(gameObject); }
        else 
		{
			_instance = this;
			DontDestroyOnLoad(gameObject); 
		}
	}
	// Use this for initialization
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }
}
