using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private int movementSpeed = 7;
    [SerializeField] private int jumpPower = 14;

    private float xMovement = 0f;
    private enum MovementState { Idle, Running, Jump, Falling }
    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(xMovement * movementSpeed, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rigidbody.velocity.x, jumpPower);
            jumpSoundEffect.Play();
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (xMovement > 0)
        {
            state = MovementState.Running;
            spriteRenderer.flipX = false;
        }
        else if (xMovement < 0)
        {
            state = MovementState.Running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rigidbody.velocity.y > 0.1f)
        {
            state = MovementState.Jump;
        }
        else if (rigidbody.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
