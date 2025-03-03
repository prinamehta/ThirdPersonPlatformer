using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody playerRB;
    public float jumpForce = 7f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool isGrounded;
    private int jumpCount;
    private bool isDashing;
    private float lastDashTime;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDashing)
        {
            Move();
        }

        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            transform.forward = direction;
        }

        playerRB.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        playerRB.linearVelocity = new Vector3(playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);
        jumpCount++;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count on landing
        }
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        lastDashTime = Time.time;

        Vector3 dashDirection = transform.forward;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            playerRB.linearVelocity = dashDirection * dashSpeed;
            yield return null;
        }

        playerRB.linearVelocity = Vector3.zero;
        isDashing = false;
    }
}
