using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManagerScript : MonoBehaviour {

    private int coinAmount = 0;
    public Text coinText;

	// Use this for initialization
	void Start () {
        coinAmount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinAmountText();
	}

    private void UpdateCoinAmountText()
    {
        int numberAmount = 4;
        string coinAmountString;
        coinAmountString = coinAmount.ToString();
        while (coinAmountString.Length < numberAmount)
        {
            coinAmountString = "0" + coinAmountString;
        }
        coinText.text = "Coins: " + coinAmountString;
    }
    private void SaveCoinAmount()
    {
        PlayerPrefs.SetInt("CoinCount", coinAmount);
    }

    public void AddCoins(int newCoinsAmount)
    {
        coinAmount = coinAmount + newCoinsAmount;
        UpdateCoinAmountText();
        SaveCoinAmount();
    }
	
}
