using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float attackCoolDown = 0.25f;
    public bool isWeaponForCharacter = true;
    public Transform attackPoint;
    public float attackRange = 0.25f;
    public float weaponDamage = 1;
    [SerializeField]
    private LayerMask damagableLayers;

    public void Start()
    {
        if (isWeaponForCharacter)
            damagableLayers = LayerMask.GetMask("EnemySoldier", "EnemyBoss");

        else

            damagableLayers = LayerMask.GetMask("Character");

    }
    public void Attack()
    {
        CallAttack();
    }

    protected abstract void CallAttack();

    public virtual void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damagableLayers);
        foreach (Collider2D collider in hitEnemies)
        {

            collider.gameObject.GetComponent<HealthController>().TakeDamage(weaponDamage);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}