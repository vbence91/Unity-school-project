using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text deathText;

    private void Start()
    {
        coinText.text = "Soul Coins collected: " + PlayerPrefs.GetInt("coins") + "/" + PlayerPrefs.GetInt("totalCoins");
        deathText.text = "Death count: " + PlayerPrefs.GetInt("death");
    }
}
