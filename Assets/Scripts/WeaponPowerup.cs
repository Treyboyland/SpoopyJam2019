using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerup : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;


    public void EquipPowerupWeapon(Player player)
    {
        player.EquipWeapon(weapon);
        gameObject.SetActive(false);
    }
}
