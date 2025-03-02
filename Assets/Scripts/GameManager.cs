using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentCoin;
    public TextMeshProUGUI coinText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddCoin(int coinToAdd)
    {
        currentCoin += coinToAdd;
        coinText.text = "Score: " + currentCoin;
    }

}
