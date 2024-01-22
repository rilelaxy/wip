using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 0.1f;
    public bool isGrounded;

    private Rigidbody rb;
    private Transform childTransform;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Assuming your sprite is a child object, find its Transform.
        childTransform = transform.Find("Player");
        // Assuming your sprite has a SpriteRenderer component.
        spriteRenderer = childTransform.GetComponent<SpriteRenderer>();
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Check the direction of movement and flip the child sprite renderer accordingly
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Do not flip when moving right.
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Flip when moving left.
        }
    }
}
