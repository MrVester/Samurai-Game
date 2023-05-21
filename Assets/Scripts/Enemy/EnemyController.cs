using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    private bool FacingRight = true;
    private EnemyAI enemyAI;

    private void Start()
    {
        CharacterEvents.current.onDeathScreenShown += DisactivateObject;
        enemyAI = GetComponent<EnemyAI>();
    }
    public void LookAtPlayer()
    {
        Vector3 characterPos = enemyAI.GetPlayer().transform.position;
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
    private void DisactivateObject()
    {
        gameObject.SetActive(false);
    }

}
