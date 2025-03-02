using UnityEngine;

public class Coin : MonoBehaviour
{

    public int value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);
            Destroy(gameObject);
        }
    }
}
