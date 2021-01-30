using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    //private AnimationScript anim;

    [Space]
    [Header("Stats")]
    public float speed = 5;
    public float jumpForce = 2;
    public float slideSpeed = 5;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;

    [Space]
    [Header("Booleans")]
    public bool hasGravity;
    public bool hasLeg;
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    public bool isRed;

    [Space]

    private bool groundTouch;
    private bool hasDashed;


    public float x;

    public int side = 1;

    [Space]
    [Header("Polish")]

    public float timeWallGrab = 4.0f;

    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponentInChildren<AnimationScript>();

        collider = GetComponent<BoxCollider2D>();

    }

    void FixedUpdate()
    {

        x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        //anim.SetHorizontalMovement(x, y, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump"))
        {
            //anim.SetTrigger("jump");
            
            if (coll.onGround)
            {
                Jump(Vector2.up, false);
                Debug.Log("COUCOUC");
            }
                
            if (coll.onWall && !coll.onGround)
                WallJump();
        }

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        if (wallGrab || wallSlide || !canMove)
            return;

        if (x > 0)
        {
            side = 1;
            //anim.Flip(side);
        }
        if (x < 0)
        {
            side = -1;
            //anim.Flip(side);
        }

        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        
        
        if(col.gameObject.tag == "Red")
        {

            Debug.Log("Collide with RED");
            isRed = true;

            col.gameObject.SetActive(false);
        }
    }


    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;

        //side = anim.sr.flipX ? -1 : 1;

    }

    private void WallJump()
    {
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
            //anim.Flip(side);
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1.5f + wallDir / 1.5f), true);

        wallJumped = true;
    }

    private void WallSlide()
    {
        if (coll.wallSide != side)
            //anim.Flip(side * -1);

        if (!canMove)
            return;

        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;

        rb.velocity = new Vector2(push, -slideSpeed);
    }

    private void Walk(Vector2 dir)
    {
        
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        
    }

    private void Jump(Vector2 dir, bool wall)
    {

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }


}
