using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody playerRB;
    public float jumpForce = 7f;
    private bool isGrounded;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Normalized to avoid faster diagonal movement

    if (direction.magnitude > 0.1f) // Prevents jittery rotation when idle
    {
        transform.forward = direction; // Rotate player in movement direction
    }

    playerRB.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }


    void Jump()
    {
        playerRB.linearVelocity = new Vector3(playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
