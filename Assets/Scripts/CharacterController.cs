using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private LayerMask platformLayerMask;
    private Rigidbody2D rb;

    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private bool FacingRight = true;
    private bool isCharacterCanWalk = true;
    [Header("Movement")]
    public float moveVector;
    public float defaultSpeed = 1f;
    private float speed;

    [Header("Jumping")]
    public ParticleSystem LandParticles;
    private bool jump;
    public float JumpForce = 5f;

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

        SetAnimationsVar();
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

    void SetAnimationsVar()
    {
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    public void SetMoveVector(float value)
    {
        moveVector = value;
    }

    public void SetJump(bool value)
    {
        jump = value;
    }

    void Walk()
    {
        rb.velocity = new Vector2(moveVector, rb.velocity.y);
    }
    void Jump()
    {

        if (jump && isOnGround())
        {
            animator.Play("MC_Jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);


        }
    }
    private bool isOnGround()
    {
        if (isOnGroundLeft() || isOnGroundRight())
        {
            return true;
        }
        else
        {
            LandParticles.Play();
            return false;
        }
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
        if (moveVector < 0 && FacingRight)
        {
            Flip();
        }
        else
            if (moveVector > 0 && !FacingRight)
        {
            Flip();
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


