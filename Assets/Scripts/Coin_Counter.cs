using UnityEngine;
using TMPro;

public class Coin_Counter : MonoBehaviour
{
    public static Coin_Counter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;
    public Main_Player mainPlayer;
    public GameObject winPanel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = $"Coins {currentCoins} / 100";
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = $"Coins {currentCoins} / 100";

        if (currentCoins >= 3)
        {
           mainPlayer.PauseAndShowPanel();
        }
    }
}
