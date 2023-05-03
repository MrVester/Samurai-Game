using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public PlayerHealthController playerHP;
    public int damage = 2;
    public float attackSpeed = 2f;
    public float speed = 2.0f;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
        player = enemy.GetComponentInParent<EnemyAI>().GetPlayer();
        playerHP = player.GetComponent<PlayerHealthController>();
    }
}
