using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int coins;

    private int totalCoins;

    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource itemCollectSoundEffect;
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2) // coins on scene no.2 only
        {
            totalCoins = TotalCoins();
            PlayerPrefs.SetInt("totalCoins", totalCoins);
            coinText.text = "Soul coins: " + coins + "/" + totalCoins;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            itemCollectSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            //Debug.Log($"Coins: {coins}");
            coinText.text = "Soul coins: " + coins + "/" + totalCoins;
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    private int TotalCoins()
    {
        GameObject[] allCoins = GameObject.FindGameObjectsWithTag("Coin");

        return allCoins.Length;
    }
}
