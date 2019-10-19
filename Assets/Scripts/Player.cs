﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    Weapon initialWeapon;

    [SerializeField]
    List<Weapon> canHaveBulletsReplaced;

    [SerializeField]
    PlayerReticle reticle;

    Weapon equippedWeapon;

    WeaponPoolOnDemand weaponPool;

    Camera worldCamera;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        worldCamera = GetComponentInParent<Camera>();
        weaponPool = GameObject.FindGameObjectWithTag("WeaponPool").GetComponent<WeaponPoolOnDemand>();
        EquipWeapon(initialWeapon);
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon != equippedWeapon && equippedWeapon != null)
        {
            equippedWeapon.Deactivate();
        }
        equippedWeapon = weaponPool.GetObject(weapon);
        equippedWeapon.Activate();
    }

    public void ChangeAmmo(Projectile newBullet)
    {
        //Special ammor will only work with the initial weapon
        if (canHaveBulletsReplaced.Contains(equippedWeapon))
        {
            equippedWeapon.Bullet = newBullet;
            equippedWeapon.RestoreAmmo();
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (Input.GetButton("Fire1"))
        {
            FireWeapon();
        }
    }

    void FireWeapon()
    {
        var bullet = equippedWeapon.Fire();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.LookAt(reticle.transform);
            bullet.CharacterType = characterType;
            bullet.BulletOwner = this;
            bullet.Activate();
        }
    }


}
