using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 2;

    public Vector3 attackOffset;
    public float attackRange = 3.5f;
    public float weaponSize = 1.5f;
    public LayerMask attackMask;


    private void Start()
    {

        attackMask = LayerMask.GetMask("Character");
    }
    public void Attack()
    {
        AudioController.current.PlayBossAttackSound();
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * FacingVectorX();
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, weaponSize, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealthController>().TakeDamage(attackDamage);
        }
    }

    private int FacingVectorX()
    {
        int x = (int)(transform.localScale.x / Mathf.Abs(transform.localScale.x));
        return x;
    }
    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * FacingVectorX();
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, weaponSize);
    }
}
