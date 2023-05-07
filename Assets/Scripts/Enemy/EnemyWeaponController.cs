using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public float attackRange = 2f;
    public Weapon Weapon;

    public void DealDamage()
    {
        Weapon.DealDamage();
    }
    public Weapon GetWeapon()
    {
        return Weapon;
    }
}
