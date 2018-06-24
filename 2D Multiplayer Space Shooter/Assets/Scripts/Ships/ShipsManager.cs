using UnityEngine;
using System.Collections;

public class ShipsManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] FastShipSprites;
    [SerializeField]
    private Sprite[] ResistantShipSprites;
    [SerializeField]
    private Sprite[] StrongShipSprites;
    [SerializeField]
    private GameObject[] shipsPrefabs;

	private GameObject[] instantiatedShips = null;

    private bool[] _isRespawning;

	private Ships[] _playersChoices;
	private int _activePlayers;

    // Use this for initialization
	public void InstantiateShips(int activePlayers, Ships[] choices)
    {
        instantiatedShips = new GameObject[activePlayers];
		_isRespawning = new bool[activePlayers];
		_playersChoices = choices;
		_activePlayers = activePlayers;
        

        int j = 0;

        //ogni nave deve chiamre il suo? se si come?

        foreach (Transform child in transform)
        {
            if (j < activePlayers)
            {
				instantiatedShips[j] = Instantiate(shipsPrefabs[(int) _playersChoices[j]], child);
                SpriteRenderer spriteRenderer = instantiatedShips[j].GetComponent<SpriteRenderer>();
                
				switch ((int)_playersChoices[j])
				{
					case 0:
						spriteRenderer.sprite = FastShipSprites[j];
						break;
					case 1:
						spriteRenderer.sprite = ResistantShipSprites[j];
                        break;
					case 2:
                        spriteRenderer.sprite = StrongShipSprites[j];
                        break;
					default:
						Debug.LogError("Should never reach this point");
						break;
				}
                
                instantiatedShips[j].transform.parent = child;

				_isRespawning[j] = false;
            }

            j++;
        }
    }


    /* IEnumerator grants the possibility to wait inactively 
 * for a certain amount of time and then continues to 
 * execute the code ater the yield call. */
    protected IEnumerator waitAndRespawn(int deadShip)
    {
        yield return new WaitForSeconds(1.0f);

        instantiatedShips[deadShip].SetActive(true);
		_isRespawning[deadShip] = false;

    }


    // Update is called once per frame
    void Update()
    {
		if (instantiatedShips != null)
		{
			int i = 0;
			while (i < _activePlayers)
			{
				if (instantiatedShips[i].GetComponent<ShipLifeHandler>().IsDead && !_isRespawning[i])
				{
					_isRespawning[i] = true;
					StartCoroutine(this.waitAndRespawn(i));
				}
			}
		}
    }
}
