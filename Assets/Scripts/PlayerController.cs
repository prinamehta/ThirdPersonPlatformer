using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody playerRB;
    public float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, playerRB.linearVelocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            playerRB.linearVelocity = new Vector3(playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);
        }
        
    }
}
