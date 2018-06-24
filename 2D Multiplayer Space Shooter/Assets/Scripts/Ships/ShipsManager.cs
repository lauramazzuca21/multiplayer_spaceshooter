using UnityEngine;
using System.Collections;

public class ShipsManager : MonoBehaviour
{
    private ServerConnectionManager _server;

    [SerializeField]
    private Sprite[] FastShipSprites;
    [SerializeField]
    private Sprite[] ResistantShipSprites;
    [SerializeField]
    private Sprite[] StrongShipSprites;
    [SerializeField]
    private GameObject[] shipsPrefabs;

    private GameObject[] instantiatedShips;

    private bool[] isRespawning;
   
    // Use this for initialization
    void Start()
    {
        instantiatedShips = new GameObject[_server.ActivePlayers];
        isRespawning = new bool[_server.ActivePlayers];
        int j = 0;

        //ogni nave deve chiamre il suo? se si come?

        foreach (Transform child in transform)
        {
            if (j < _server.ActivePlayers)
            {
                instantiatedShips[j] = Instantiate(shipsPrefabs[(int)Ships.FAST], child);
                SpriteRenderer spriteRenderer = instantiatedShips[j].GetComponent<SpriteRenderer>();

                spriteRenderer.sprite = FastShipSprites[(int)Colours.BLUE];
                instantiatedShips[j].transform.parent = child;

                isRespawning[j] = false;
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
        isRespawning[deadShip] = false;

    }


    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < _server.ActivePlayers)
        {
            if (instantiatedShips[i].GetComponent<ShipLifeHandler>().IsDead && !isRespawning[i])
            {
                isRespawning[i] = true;
                StartCoroutine(this.waitAndRespawn(i));
            }
        }
    }
}
