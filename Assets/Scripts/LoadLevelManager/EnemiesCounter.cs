using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    public static EnemiesCounter current;
    public event Action onAllEnemiesDead;
    private int enemiesAmount;


    private void Awake()
    {
        current = this;
    }

    void Start()
    {

        enemiesAmount = FindObjectsOfType<EnemyHealthController>().Length;
    }

    public int CountEnemies()
    {
        return enemiesAmount;
    }

    public void DecrementEnemiesAmount()
    {
        Debug.Log("Updated");
        enemiesAmount--;
        if (enemiesAmount <= 0)
        {
            onAllEnemiesDead();
        }
    }



}
