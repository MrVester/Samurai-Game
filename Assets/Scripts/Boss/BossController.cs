using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 2f;
    private bool FacingRight = false;
    private BossAI bossAI;
    private bool isFacingRight = true;
    private void Start()
    {
        bossAI = GetComponent<BossAI>();
    }
    public void LookAtPlayer()
    {
        Vector3 characterPos = bossAI.GetPlayer().transform.position;
        if (characterPos.x - transform.position.x < 0 && FacingRight)

        {
            Flip();
        }
        else

        if (characterPos.x - transform.position.x > 0 && !FacingRight)

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
