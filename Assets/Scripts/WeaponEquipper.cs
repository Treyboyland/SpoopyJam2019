using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipper : MonoBehaviour
{
    [SerializeField]
    List<Player> players;

    [SerializeField]
    Weapon weaponToGive;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EquipWeapons()
    {
        foreach (Player p in players)
        {
            p.EquipWeapon(weaponToGive);
        }
    }
}
