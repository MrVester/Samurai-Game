using UnityEngine;
public class PlayerWeaponController : MonoBehaviour
{
    public Weapon Weapon;

    public void Attack()
    {
        Weapon.Attack();
    }
    public void DealDamage()
    {
        Weapon.DealDamage();
    }
}