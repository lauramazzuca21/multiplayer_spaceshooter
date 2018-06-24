using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnectionManager : MonoBehaviour {

    public int ActivePlayers = 3;

	private Ships[] playersChoices;

	[SerializeField]
	private ShipsManager _shipsManager;

    // Use this for initialization
    void Start () {
		playersChoices = new Ships[ActivePlayers];

		SetPlayerChoice(0, Ships.FAST);
		SetPlayerChoice(1, Ships.STRONG);
		//SetPlayerChoice(2, Ships.RESISTANT);

		_shipsManager.InstantiateShips(ActivePlayers, this.playersChoices);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetPlayerChoice(int playerID, Ships ship) {
		playersChoices[playerID] = ship;
        
	}
}
