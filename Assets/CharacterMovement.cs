using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5.0f;
    public float jumpForce = 0.1f;
    public bool isGrounded;
    public bool walking;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true; // Track the direction the character is facing

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found in children.");
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed);
        rb.velocity = movement;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Check if the direction has changed and flip the sprite accordingly
        if (horizontalInput > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight; // Toggle the direction
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the sprite by reversing its x scale
        transform.localScale = scale;
    }
}
