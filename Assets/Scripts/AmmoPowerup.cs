using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerup : Powerup, IPowerup
{
    [SerializeField]
    Projectile bullet;

    public void HandlePowerup(Player player)
    {
        player.ChangeAmmo(bullet);
        OnPowerupTaken.Invoke();
    }
}
