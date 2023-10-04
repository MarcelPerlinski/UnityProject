using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private Rigidbody2D rb;
    [SerializeField]private TrailRenderer tr;

    private bool facingRight = true;

    private bool isGrouned;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        isGrouned = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); 

        if(facingRight == false && moveInput > 0) {
            Flip();       
        } else if(facingRight == true && moveInput < 0) {
            Flip();  
        }
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        if(isGrouned == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

    else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrouned == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private IEnumerator Dash() 
    { 
        canDash = false; 
        isDashing = true; 
        float originalGravity = rb.gravityScale; 
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false; 
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
