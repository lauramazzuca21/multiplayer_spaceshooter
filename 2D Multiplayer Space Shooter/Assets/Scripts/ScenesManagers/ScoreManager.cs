using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int[] _scorePlayer;

    private int _maxKills;

    [SerializeField]
	private Text[] _textPlayerScore;

    private LevelManager levelManager;

	void Start()
    {
        Reset();
        _scorePlayer = new int[4];
        levelManager = FindObjectOfType<LevelManager>();
    }
			
	public void UpdateScore(int playerID) //player 0-3 = 1-4
    {
        Debug.Log("Scored points");
        _scorePlayer[playerID]++;
        _textPlayerScore[playerID].text = _scorePlayer.ToString();

        if (_scorePlayer[playerID] == _maxKills) {
            levelManager.LoadScene(Constants.GAMEOVER_SCENE);
        }
    }

    public void Reset()
    {
        for(int i = 0; i<_scorePlayer.Length; i++)
        {
            _scorePlayer[i] = 0;
            _textPlayerScore[i].text = _scorePlayer.ToString();
        }
    }
}
