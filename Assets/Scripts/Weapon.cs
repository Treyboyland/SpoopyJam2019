using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Projectile bullet;

    public Projectile Bullet
    {
        get
        {
            return bullet;
        }
        set
        {
            bullet = value;
        }
    }

    [SerializeField]
    int weaponId;

    public int WeaponId
    {
        get
        {
            return weaponId;
        }
    }

    Projectile normalBullet;

    [SerializeField]
    float roundsPerMinute;

    [SerializeField]
    float reloadTime;

    [SerializeField]
    int maxAmmo;

    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
        set
        {
            maxAmmo = value;
        }
    }

    float SecondsPerRound
    {
        get
        {
            return 60 / roundsPerMinute;
        }
    }

    public string WeaponName;

    int currentAmmo;

    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
    }

    bool reloading = false;

    public bool IsReloading
    {
        get
        {
            return reloading;
        }
    }

    float currentReloadTime = 0;
    float currentTimeBetweenShots = 0;

    ProjectilePoolOnDemand bulletPool;

    private void Start()
    {
        normalBullet = bullet;
        bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<ProjectilePoolOnDemand>();
        RestoreAmmo(false);
    }

    public void RestoreAmmo(bool playSound)
    {
        currentAmmo = maxAmmo;
        reloading = false;
        currentTimeBetweenShots = SecondsPerRound;
        if(playSound && SoundController.Controller != null)
        {
            SoundController.Controller.OnPlayReloadWeaponSound.Invoke();
        }
    }

    private void OnEnable()
    {
        bullet = normalBullet != null ? normalBullet : bullet;
        RestoreAmmo(false);
    }

    private void OnDisable()
    {
        //Reset ammmo
        RestoreAmmo(false);
    }

    bool CanFire()
    {
        return !reloading && currentTimeBetweenShots >= SecondsPerRound;
    }

    public Projectile Fire()
    {
        if (CanFire())
        {
            if (SoundController.Controller != null)
            {
                SoundController.Controller.OnPlayShootSound.Invoke();
            }
            //TODO: Fire bullet
            return FireBullet();
        }
        else
        {
            return null;
        }
    }

    Projectile FireBullet()
    {
        Projectile bullet = bulletPool.GetObject(this.bullet);
        currentAmmo--;
        currentTimeBetweenShots = 0;

        if (currentAmmo == 0)
        {
            StartReloading();
        }

        return bullet;
    }

    void StartReloading()
    {
        reloading = true;
        currentReloadTime = 0;
    }

    private void Update()
    {
        if (reloading)
        {
            currentReloadTime += Time.deltaTime;
            if (currentReloadTime >= reloadTime)
            {
                RestoreAmmo(true);
            }
        }
        else
        {
            currentTimeBetweenShots = Mathf.Min(Time.deltaTime + currentTimeBetweenShots, SecondsPerRound);
        }
    }

}
