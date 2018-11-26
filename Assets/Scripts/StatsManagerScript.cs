using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManagerScript : MonoBehaviour {

    private int coinAmount = 0;

	// Use this for initialization
	void Start () {
		coinAmount = PlayerPrefs.GetInt("CoinCount")
	}
	
}
