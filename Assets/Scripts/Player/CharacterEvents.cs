using UnityEngine;
using System;

public class CharacterEvents : MonoBehaviour
{
    public static CharacterEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action onTakeDamage;
    public void TakeDamage()
    {
        if (onTakeDamage != null)
            onTakeDamage();
    }
    public event Action onDeath;

    public void Death()
    {
        if (onDeath != null)
            onDeath();
    }
    public event Action onAttack;
    public void Attack() 
    {
        if (onAttack != null)
            onAttack();
    }
    public event Action onDash;
    public void Dash()
    {
        if (onDash != null)
        {
            onDash();
        }
            
    }

}