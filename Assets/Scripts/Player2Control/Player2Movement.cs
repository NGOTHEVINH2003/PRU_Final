using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Anim;
    [SerializeField] private Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    private float horizontalValue;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpPower = 50;
    private bool jump = false;
    private bool crouch = false;
    public bool isGrounded = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal2");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jump = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            crouch = true;
            rb.drag = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
            rb.drag = 0;
        }
        Anim.SetFloat("yVelocity", rb.velocity.y);
        Anim.SetFloat("xVelocity", rb.velocity.x);
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump, crouch);
    }
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            Anim.SetBool("GroundCheck", true);
        }
        Anim.SetBool("jumping", !isGrounded);
    }
    void Move(float dir, bool jump, bool crouch)
    {
        if (isGrounded && crouch)
        {
            Anim.SetBool("Crouching", true);
        }
        else
        {
            Anim.SetBool("Crouching", false);
        }
        if (isGrounded && jump)
        {
            jump = false;
            Anim.SetBool("GroundCheck", false);
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        #region Move
        if (!crouch && !GlobalVarieties.global.p2isBlocking)
        {
            float xVal = dir * speed * Time.deltaTime * 100;
            Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
            rb.velocity = targetVelocity;
        }

        #endregion
    }
}
