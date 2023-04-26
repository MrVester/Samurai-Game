using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public bool isJoystickControl = false;
    private LayerMask platformLayerMask;
    private Rigidbody2D rb;
    private float moveDir;
    public float defaultSpeed = 1f;
    private float speed;
    public float accSpeed = 1.5f;
    public float JumpForce = 5f;

    private bool Switch = true;
    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private bool FacingRight = true;
    private bool isFacingRight = true;
    private bool isCharacterCanWalk = true;


    public float dashSpeed = 40f;
    public float dashTime = 0.2f;
    public float dashCoolDown = 2f;
    public float lastDash;
    private float dashTimer;

    private bool jump;


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
        animator = GetComponent<Animator>();
        platformLayerMask = LayerMask.GetMask("Ground");
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
    }
    private void OnValidate()
    {
        speed = defaultSpeed;
    }
    private void Update()
    {
        Dash();
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


    public void SetMoveDir(float value)
    {
        moveDir = value;
    }

    public void SetJump(bool value)
    {
        jump = value;
    }

    void Walk()
    {
        rb.velocity = new Vector2(moveDir, rb.velocity.y);


        if (Input.GetKey(KeyCode.LeftShift) && Switch && Mathf.Abs(rb.velocity.x) > 0 && isOnGroundLeft())
        {

            speed = accSpeed;
            Switch = false;
        }

        if (rb.velocity.x == 0 && !Switch)
        {
            speed = defaultSpeed;
            Switch = true;
        }

    }
    void Jump()
    {

        if (((isJoystickControl && variableJoystick.Direction.y >= 0.5f) || (Input.GetKeyDown(KeyCode.Space) && !isJoystickControl)) && isOnGround())
        {
            animator.Play("MC_Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);


        }
    }

    void Dash()
    {

        dashTimer = Time.time + dashCoolDown;          //ИЗМЕНЕНИЕ ВРЕМЕНИ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashTimer - lastDash < dashCoolDown) //CoolDown for Dash
            {
                return;
            }
            lastDash = dashTimer;
            StartCoroutine(DashCoroutine());

        }
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time <= startTime + dashTime)
        {

            //rb.position += GetFacingVector() * new Vector3(1, 0.5f, 0) * dashSpeed * Time.deltaTime;
            rb.position += new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical) * dashSpeed * Time.deltaTime;

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
            return true;
        else
            return false;
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
        if (moveDir < 0 && FacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        else
            if (moveDir > 0 && !FacingRight)
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


