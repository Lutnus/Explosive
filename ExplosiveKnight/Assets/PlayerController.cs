using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;


    private bool isGrounded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float JumpTimeCounter;
    public float JumpTime;
    private Rigidbody2D Rigidb;
    private bool canDash = true;
    private bool isdashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    bool IsJumping;

    [SerializeField] private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        Rigidb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (isdashing)
        {
            return;


        }




        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        Rigidb.velocity = new Vector2(moveInput * speed, Rigidb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isdashing)
        {
            return;

        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && canDash)
        {
            StartCoroutine(Dash());



        }








        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;


            JumpTimeCounter = JumpTime;
            Rigidb.velocity = Vector2.up * jumpForce;




        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;


        }


        {


        }
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                Rigidb.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }


        }

    }



    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }



    private IEnumerator Dash()
    {

        canDash = false;
        isdashing = true;
        float originalGravity = Rigidb.gravityScale;
        Rigidb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        Rigidb.gravityScale = 0f;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;


    }





}











