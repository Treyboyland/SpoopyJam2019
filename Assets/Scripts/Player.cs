using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    Weapon initialWeapon;

    [SerializeField]
    List<int> canHaveBulletsReplaced;

    [SerializeField]
    PlayerReticle reticle;

    [SerializeField]
    PlayerName playerName;

    public PlayerName PlayerName
    {
        get
        {
            return playerName;
        }
    }

    Weapon equippedWeapon;

    public Weapon EquippedWeapon
    {
        get
        {
            return equippedWeapon;
        }
    }

    WeaponPoolOnDemand weaponPool;

    Camera worldCamera;

    public PlayerDataUpdated OnPlayerDataUpdated;

    bool canShoot = true;

    public bool CanShoot
    {
        get
        {
            return canShoot;
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        if ((GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_MOUSE ||
            GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_KEYBOARD) && playerName != PlayerName.PLAYER_ONE)
        {
            this.Deactivate();
            return;
        }

        GameManager.Manager.OnGameOver.AddListener(() =>
        {
            canShoot = false;
        });
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
        equippedWeapon.PlayerOwner = this;
        OnPlayerDataUpdated.Invoke(this);
    }

    public void ChangeAmmo(Projectile newBullet)
    {
        //Special ammor will only work with the initial weapon
        if (canHaveBulletsReplaced.Contains(equippedWeapon.WeaponId))
        {
            equippedWeapon.Bullet = newBullet;
            equippedWeapon.RestoreAmmo(true);
            OnPlayerDataUpdated.Invoke(this);
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (canShoot && PlayerInputs.GetFireButtonForPlayer(GameConstants.PlayerCount, playerName))
        {
            FireWeapon();
        }
        if (PlayerInputs.GetReloadButtonDownForPlayer(GameConstants.PlayerCount, playerName) && !equippedWeapon.IsReloading)
        {
            if (equippedWeapon.CurrentAmmo == 1)
            {
                equippedWeapon.RestoreAmmo(true);
                OnPlayerDataUpdated.Invoke(this);
            }
            else
            {
                equippedWeapon.StartReloading();
                OnPlayerDataUpdated.Invoke(this);
            }
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
            OnPlayerDataUpdated.Invoke(this);
        }
        else
        {
            if (PlayerInputs.GetFireButtonDownForPlayer(GameConstants.PlayerCount, playerName) && equippedWeapon.IsReloading && SoundController.Controller != null)
            {
                SoundController.Controller.OnPlayClipEmptySound.Invoke();
            }
        }
    }


}
