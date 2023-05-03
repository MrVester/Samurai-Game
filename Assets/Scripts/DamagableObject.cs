using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public float damage;
    public float damageCoolDown;
    PlayerHealthController healthController;
    private new Collider2D collider2D;
    private bool isDamagable = true;


    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            healthController = collider.gameObject.GetComponent<PlayerHealthController>();
            if (isDamagable)
            {
                collider2D.enabled = false;
                isDamagable = false;
                healthController.TakeDamage(damage);
                StartCoroutine(DamageCoroutine());


            }

        }

    }

    //Тикает, когда Player внутри коллайдера(даже когда стоит на месте, в отличие от OnTriggerStay)
    /* private void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.tag == "Player")
         {
             healthController = collider.gameObject.GetComponent<PlayerHealthController>();
             collider2D.enabled = false;
             healthController.TakeDamage(damage);
             collider2D.enabled = true;

         }

     }*/

    IEnumerator DamageCoroutine()
    {

        yield return new WaitForSeconds(damageCoolDown);
        isDamagable = true;
        collider2D.enabled = true;


    }
}
