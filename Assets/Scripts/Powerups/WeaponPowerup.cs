using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerup : Powerup, IPowerup
{
    [SerializeField]
    Weapon weapon;

    public void HandlePowerup(Player player)
    {
        player.EquipWeapon(weapon);
        OnPowerupTaken.Invoke();
    }
}
