using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float attackCoolDown = 0.25f;
    public Transform attackPoint;
    public float attackRange = 0.25f;
    public float weaponDamage = 1;
    public LayerMask enemyLayers;

    public void Start()
    {
        enemyLayers = LayerMask.GetMask("EnemySoldier", "EnemyBoss");
    }
    public void Attack()
    {
        CallAttack();
    }

    protected abstract void CallAttack();



    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D collider in hitEnemies)
        {
            collider.gameObject.GetComponent<EnemyHealthController>().TakeDamage(weaponDamage);
        }
    }
    public IEnumerator DealDamageCoroutine()
    {
        yield return new WaitForSeconds(0);
        DealDamage();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}