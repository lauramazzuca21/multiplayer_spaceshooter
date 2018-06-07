using UnityEngine;
using System.Collections;

public class ShipsController : MonoBehaviour
{
	private enum Ships { FAST, RESISTANT, STRONG };
	private enum Colours { BLUE, GREEN, ORANGE, RED };

	[SerializeField]
	private Sprite[] FastShipSprites;
	[SerializeField]
	private Sprite[] ResistantShipSprites;
	[SerializeField]
    private Sprite[] StrongShipSprites;
	[SerializeField]
	private GameObject[] shipsPrefabs;

    
    // Use this for initialization
    void Start()
    {

		foreach (Transform child in transform) {
			GameObject ship = Instantiate(shipsPrefabs[(int) Ships.FAST], child);
			SpriteRenderer spriteRenderer = ship.GetComponent<SpriteRenderer>();
            
			spriteRenderer.sprite = FastShipSprites[(int) Colours.BLUE];
			ship.transform.parent = child;
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
