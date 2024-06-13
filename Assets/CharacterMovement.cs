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
    private bool facingRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        animator.SetFloat("Speed", Mathf.Abs(verticalInput));

        
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

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
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
