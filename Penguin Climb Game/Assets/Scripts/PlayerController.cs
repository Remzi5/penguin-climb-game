using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float autoClimbSpeed = 2f;
    public float jumpForce = 7f;
    public float fallLimit = -5f; // Game Over Y limit

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Auto climb ilə conflict olmaması üçün
    }

    void Update()
    {
        // 1️⃣ Left-right movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // 2️⃣ Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // 3️⃣ Auto climb
        transform.position += Vector3.up * autoClimbSpeed * Time.deltaTime;

        // 4️⃣ Game Over detection
        if (transform.position.y < fallLimit)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Buraya UI Game Over çağırmaq əlavə olunur
    }
}
