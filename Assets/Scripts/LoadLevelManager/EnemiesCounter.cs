using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    public static EnemiesCounter current;
    public event Action onAllEnemiesDead;
    public event Action onEnemiesAlive;
    private int enemiesAmount;


    private void Awake()
    {
        current = this;

    }

    void Start()
    {
        enemiesAmount = FindObjectsOfType<EnemyHealthController>().Length;
        Debug.Log("EnemiesAmount: " + enemiesAmount);
        if (enemiesAmount != 0)
            onEnemiesAlive();

    }

    public int CountEnemies()
    {
        return enemiesAmount;
    }

    public void DecrementEnemiesAmount()
    {
        Debug.Log("EnemiesAmount: " + enemiesAmount);
        enemiesAmount--;
        if (enemiesAmount <= 0)
        {
            enemiesAmount = 0;
            onAllEnemiesDead();
        }


    }



}
