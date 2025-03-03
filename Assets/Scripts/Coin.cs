using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Entered coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    Debug.Log("Collision detected with: " + other.name); 

    if (other.CompareTag("Player")) 
    {
        Debug.Log("Player collected the coin!"); 
        FindObjectOfType<GameManager>().AddCoin(value);
        Destroy(gameObject);
    }
    }

}
