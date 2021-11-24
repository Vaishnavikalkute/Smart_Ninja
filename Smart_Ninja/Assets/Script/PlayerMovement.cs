using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D colli;

    [SerializeField] private LayerMask Jumpground;

    //Global variable
    private float dirX = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 14f;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("space")&& isGrounded())//if either of this false no jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .2f)
        {
            state = MovementState.jumping;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);//to access the int values of animation
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(colli.bounds.center, colli.bounds.size, 0f, Vector2.down, .1f, Jumpground);
    }
}
