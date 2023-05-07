using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Animator anim;
    public GameObject player;
    public float attackCoolDown = 1f;
    private float coolDown;

    void Start()
    {
        anim = GetComponent<Animator>();

        coolDown = 1 / attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("AttackCoolDown", coolDown);
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
    }
    public GameObject GetPlayer()
    {
        return player;
    }
}
