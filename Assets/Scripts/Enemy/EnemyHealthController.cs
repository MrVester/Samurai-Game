using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float MaxHealth = 10.0f;
    [SerializeField]
    private float health;
    private Animator enemyAnimator;
    private bool isDead = false;
    public float seconds = 2f;
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        health = MaxHealth;
    }
    public void TakeDamage(float damage)
    {
        //BloodParticles.Play();

        // TODO: Add knockback
        health -= damage;
        // if hp is less than 0, call EnemyDied event
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log(isDead);
            EnemyDied();
        }
        else
        if (health > 0 && !isDead)
        {
            Debug.Log("Enemy health: " + health);
        }



    }
    // Update is called once per frame
    private void EnemyDied()
    {

        enemyAnimator.SetTrigger("Dead");
        StartCoroutine(DestroyEnemy(seconds));

    }

    IEnumerator DestroyEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
