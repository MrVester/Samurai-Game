using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public float damage;
    public float damageCoolDown;
    HealthController healthController;
    private new BoxCollider2D collider2D;
    private bool isDamagable = true;
    private LayerMask damagableLayers;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
        damagableLayers = LayerMask.GetMask("Character", "EnemySoldier", "EnemyBoss");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Enemy"))
        {
            if (isDamagable)
            {
                Collider2D[] hitEntities = Physics2D.OverlapBoxAll(collider2D.offset + new Vector2(transform.position.x, transform.position.y), collider2D.size, transform.rotation.x, damagableLayers);
                foreach (Collider2D hitEntity in hitEntities)
                {
                    hitEntity.gameObject.GetComponent<HealthController>().TakeDamage(damage);


                }
                collider2D.enabled = false;
                isDamagable = false;
                StartCoroutine(DamageCoroutine());
            }

        }




    }
    //while Player or enemy is inside collider, method is updating, unlike OnTriggerStay method, which is updating on only moving inside collider)
    /*  private void OnTriggerEnter2D(Collider2D collider)
      {
          if (collider.CompareTag("Player") || collider.CompareTag("Enemy"))
          {
              healthController = collider.gameObject.GetComponent<HealthController>();
              collider2D.enabled = false;
              healthController.TakeDamage(damage);
              collider2D.enabled = true;

          }

      }
  */
    IEnumerator DamageCoroutine()
    {

        yield return new WaitForSeconds(damageCoolDown);
        isDamagable = true;
        collider2D.enabled = true;


    }
}
