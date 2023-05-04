using UnityEngine;
using System;
using UnityEditor.PackageManager;

public class CharacterEvents : MonoBehaviour
{
    public static CharacterEvents current;
    void Start()
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
            onDash();
    }

}