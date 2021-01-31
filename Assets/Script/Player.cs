﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    private CharacterAnimation anim;

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
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    public bool isRed;
    public bool hasLeg;
    public bool hasEye;
    public bool hasArm;
    public bool hasTail;
    private string ControlAnim;
    private string oldControlAnim;
    private bool[] knowCompetence;

    [Space]

    private bool groundTouch;
    private bool hasDashed;

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
        anim = GetComponent<CharacterAnimation>();

        collider = GetComponent<BoxCollider2D>();


        knowCompetence = new bool[4];
    }

    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        anim.SetHorizontalMovement(x, y, rb.velocity.y);

        if (!hasLeg)
        {
            Vector3 temp = transform.position;
            temp.y = 0.5f;
            transform.position= temp;

            Vector2 PosColl = collider.offset;
            PosColl.y = 1f;
            collider.offset = PosColl;

            rb.gravityScale = 0.0f;
        }

        if (hasLeg)
        {
            rb.gravityScale = 1.0f;

            Vector2 PosColl = collider.offset;
            PosColl.y = -0.16f;
            collider.offset = PosColl;

            coll.bottomOffset.y = -1.13f;
        }

        if(hasLeg && hasTail)
        {
            Vector2 PosColl = collider.offset;
            PosColl.y = -0.95f;
            collider.offset = PosColl;

            coll.bottomOffset.y = -2f;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (hasLeg)
            {
                if (coll.onGround)
                {
                    anim.SetTrigger("jump");
                    Jump(Vector2.up, false);
                    
                }
            }
            else
            {
                Debug.Log("FLY DOWN");
                anim.SetTrigger("jump");
                Jump(Vector2.down, false);
            }    
            
        }

        if (x > 0)
        {

            Debug.Log("Side X +");
            side = 1;
            anim.Flip(side);
        }
        if (x < 0)
        {
            Debug.Log("Side X -");
            side = -1;
            anim.Flip(side);
        }

        

        ControlAnim = "CharacterAnimatorB";

        if (hasLeg)
            ControlAnim += "L";
        else
            knowCompetence[0] = false;

        if (hasEye)
            ControlAnim += "E";
        else
            knowCompetence[1] = false;

        if (hasTail)
            ControlAnim += "T";
        else
            knowCompetence[2] = false;

        if (hasArm)
            ControlAnim += "A"; 
        else
            knowCompetence[3] = false;

        Debug.Log("Competence : " + ControlAnim);

        if (ControlAnim != oldControlAnim)
        {
            anim.changeSprite(ControlAnim);
        }

        oldControlAnim = ControlAnim;



        Debug.Log("Comp = " + knowCompetence);

        
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

        side = anim.sr.flipX ? -1 : 1;

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
