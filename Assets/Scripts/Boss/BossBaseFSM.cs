using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseFSM : StateMachineBehaviour
{
    public GameObject boss;
    public GameObject player;
    public PlayerHealthController playerHealth;
    public Rigidbody2D rb;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.gameObject;
        player = boss.GetComponentInParent<BossAI>().GetPlayer();
        playerHealth = player.GetComponent<PlayerHealthController>();
        rb = boss.GetComponent<Rigidbody2D>();
    }
}
