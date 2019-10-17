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

    int currentAmmo;

    bool reloading = false;

    float currentReloadTime = 0;
    float currentTimeBetweenShots = 0;

    ProjectilePoolOnDemand bulletPool;

    private void Start()
    {
        bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<ProjectilePoolOnDemand>();
        RestoreAmmo();
    }

    void RestoreAmmo()
    {
        currentAmmo = maxAmmo;
        reloading = false;
        currentTimeBetweenShots = SecondsPerRound;
    }

    private void OnEnable()
    {
        RestoreAmmo();
    }

    bool CanFire()
    {
        return !reloading && currentTimeBetweenShots >= SecondsPerRound;
    }

    public Projectile Fire()
    {
        if (CanFire())
        {
            //TODO: Fire bullet
            return FireBullet();
        }
        else
        {
            //TODO: Click sound???
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
                RestoreAmmo();
            }
        }
        else
        {
            currentTimeBetweenShots = Mathf.Min(Time.deltaTime + currentTimeBetweenShots, SecondsPerRound);
        }
    }

}
