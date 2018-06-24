using UnityEngine;
using System.Collections;

public class ShipsManager : MonoBehaviour
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

    private GameObject[] instantiatedShips;

    private bool[] isRespawning;


    // Use this for initialization
    void Start()
    {
        instantiatedShips = new GameObject[4];
        isRespawning = new bool[4];
        int j = 0;

        //ogni nave deve chiamre il suo? se si come?

        foreach (Transform child in transform)
        {
            instantiatedShips[j] = Instantiate(shipsPrefabs[(int)Ships.FAST], child);
            SpriteRenderer spriteRenderer = instantiatedShips[j].GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = FastShipSprites[(int)Colours.BLUE];
            instantiatedShips[j].transform.parent = child;

            isRespawning[j] = false;


            j++;
        }
    }


    /* IEnumerator grants the possibility to wait inactively 
 * for a certain amount of time and then continues to 
 * execute the code ater the yield call. */
    protected IEnumerator waitAndRespawn(int deadShip)
    {
        yield return new WaitForSeconds(10.0f);

        instantiatedShips[deadShip].SetActive(true);
        isRespawning[deadShip] = false;

    }


    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < 4)
        {
            if ((instantiatedShips[i].GetComponent<ShipLifeHandler>().GetIsDead()) == true && (isRespawning[i] == false))
            {
                StartCoroutine(this.waitAndRespawn(i));
            }
        }
    }
}
