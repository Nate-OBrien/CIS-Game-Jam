using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNum = 0;
    public float speed = 7.5f;
    public float jumpForce = 15;

    private Rigidbody2D rb;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetAxis("jump" + playerNum) > 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("Jump with " + playerNum + " on " + gameObject.name);
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("horizontal" + playerNum) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + new Vector2(x, 0));
    }


    // Detect ground collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        // You can refine this with tags like "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
