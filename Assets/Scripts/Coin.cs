using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Coin_Counter.instance.IncreaseCoins(value);
        }
    }
}
