using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : EnemyHealthController
{
    public HealthBar bossHPBar;

    private new void Start()
    {
        base.Start();
        bossHPBar.SetMaxHealth(maxHealth);
    }
    public override void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;

        if (!isDead)
        {
            _damageFlash.Flash(Color.white);
        }
        else
        {
            health = 0;
        }
        // if hp is less than 0, call EnemyDied event
        if (health <= 0 && !isDead)
        {
            bossHPBar.SetHealth(0);
            isDead = true;
            Debug.Log(isDead);
            EnemyDied();
        }

        else

        if (health > 0 && !isDead)
        {
            bossHPBar.SetHealth(health);

            Debug.Log("Enemy health: " + health);
        }



    }
    // Update is called once per frame
    private void EnemyDied()
    {
        enemyAnimator.SetTrigger("Dead");
        StartCoroutine(DestroyEnemy(secondsToDestroy));

    }

    IEnumerator DestroyEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
        EnemiesCounter.current.DecrementEnemiesAmount();
        bossHPBar.gameObject.SetActive(false);
        yield return null;
    }
}
