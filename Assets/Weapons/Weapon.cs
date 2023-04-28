using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float AttackInterval = 0.25f;

    private float attackTimer;

    private void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (attackTimer <= 0)
        {
            CallAttack();
            attackTimer = AttackInterval;
        }
    }

    protected abstract void CallAttack();
}