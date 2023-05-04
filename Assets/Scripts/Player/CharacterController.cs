using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CharacterController : MonoBehaviour
{
    [HideInInspector]
    private LayerMask platformLayerMask;
    private Rigidbody2D rb;


    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private bool FacingRight = true;
    private bool isCharacterCanWalk = true;
    private bool isInAir = false;
    [Header("Movement")]
    public float maxCharacterSpeed = 6f;
    public float defaultSpeed = 1f;
    private float speed;
    private Vector2 joystickInput;

    [Header("Jumping")]
    private ParticleSystem LandParticles;
    private bool jump;
    public float JumpForce = 5f;

    [Header("Dash")]
    private float lastDash;
    private float dashTimer;



    private bool isFacingRight = true;


    public bool IsCharacterCanWalk
    {
        get
        {
            return isCharacterCanWalk;
        }
        set
        {
            isCharacterCanWalk = value;
        }
    }
    void Start()
    {
        
        LandParticles = transform.Find("Particles/LandParticle").GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        platformLayerMask = LayerMask.GetMask("Ground");
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;

        CharacterEvents.current.onDash += DashPlayer;
    }
    private void OnValidate()
    {
        speed = defaultSpeed;
        
    }
    private void Update()
    {
        
        SetAnimationsVariables();
        FlipCharacter();
        Jump();

        if (isOnGround())
        {
            animator.SetBool("IsOnGround", true);
        }
        else
        {
            animator.SetBool("IsOnGround", false);
        }
        if (isOnGround() && isInAir)
        {
            //JustGrounded
            isInAir = false;
            LandParticles.Play();


        }
        if (isCharacterCanWalk)
        {
            Walk();
        }
        // Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.min.y), Vector2.down * 0.1f, Color.blue);
        // Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.min.y), Vector2.down *  0.1f, Color.blue);
    }

    void SetAnimationsVariables()
    {
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void SetHorizontal(float value)
    {
        joystickInput.x = value;
    }

    public void SetVertical(float value)
    {
        joystickInput.y = value;
    }

    public void SetJump(bool value)
    {
        jump = value;
    }

    void Walk()
    {
        rb.velocity = new Vector2(joystickInput.x * maxCharacterSpeed, rb.velocity.y);
    }
    void Jump()
    {

        if (jump && isOnGround())
        {
            animator.Play("MC_Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);

            StartCoroutine(SetBoolTrueAfterSecs(0.5f));
        }
    }

    void DashPlayer()
    {

        dashTimer = Time.time + CharacterParameters.DashCoolDown;          //ИЗМЕНЕНИЕ ВРЕМЕНИ

            if (dashTimer - lastDash < CharacterParameters.DashCoolDown) //CoolDown for Dash
            {
                return;
            }
            lastDash = dashTimer;
            Debug.Log("Dash");
            StartCoroutine(DashCoroutine());

    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time <= startTime + CharacterParameters.DashTime)
        {

            //rb.position += GetFacingVector() * new Vector2(1, 0.5f) * CharacterParameters.DashSpeed * Time.deltaTime;
            rb.position += new Vector2(joystickInput.x, joystickInput.y) * CharacterParameters.DashSpeed * Time.deltaTime;

            yield return null;
        }

    }
    int GetFacingVector()
    {
        if (isFacingRight)
            return 1;
        return -1;

    }
    private bool isOnGround()
    {
        if (isOnGroundLeft() || isOnGroundRight())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator SetBoolTrueAfterSecs(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isInAir = true;
    }
    private bool isOnGroundLeft()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }

    private bool isOnGroundRight()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }

    /* private bool isNearWall() //�������
     {
         float additionalValue = 0.001f;
         RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.right, capsuleCollider2D.bounds.extents.y, platformLayerMask);
         Color rayColor;
         if (raycastHit.collider != null)
         {
             rayColor = Color.red;
         }
         else
         {
             rayColor = Color.green;
         }
         Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.right* (capsuleCollider2D.bounds.extents.y ), rayColor);
         return raycastHit.collider != null;
     }*/
    private void FlipCharacter()
    {

        if (joystickInput.x < 0 && FacingRight)

        {
            Flip();
            isFacingRight = false;
        }
        else
            if (joystickInput.x > 0 && !FacingRight)

        {
            Flip();
            isFacingRight = true;
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }



}


