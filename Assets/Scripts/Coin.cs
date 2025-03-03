using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    
    private void OnTriggerEnter(Collider other)
    {
    
    if (other.CompareTag("Player")) 
    { 
        FindObjectOfType<GameManager>().AddCoin(value);
        Destroy(gameObject);
    }
    }

}
