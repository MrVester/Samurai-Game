using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private Weapon weapon;
    private float attackCoolDown;
    void Start()
    {
        anim = GetComponent<Animator>();
        weapon = GetComponent<EnemyWeaponController>().GetWeapon();
        attackCoolDown = 1 / weapon.attackCoolDown;
        player = FindObjectOfType<CharacterController>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("AttackCoolDown", attackCoolDown);
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
    }
    public GameObject GetPlayer()
    {
        return player;
    }
}
