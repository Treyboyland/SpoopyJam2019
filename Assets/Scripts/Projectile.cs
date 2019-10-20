using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float secondsToLive;

    [SerializeField]
    float attack;

    public float Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }

    [SerializeField]
    string ammoName;

    public string AmmoName
    {
        get
        {
            return ammoName;
        }
    }

    [SerializeField]
    bool doesDamageOverTime;

    [SerializeField]
    int secondsDoTActive;

    public int SecondsDoTActive
    {
        get
        {
            return secondsDoTActive;
        }
        set
        {
            secondsDoTActive = value;
        }
    }

    [SerializeField]
    bool isPiercingShot;

    public Player BulletOwner
    {
        get; set;
    }

    public CharacterType CharacterType
    {
        get; set;
    }

    float elapsedSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds >= secondsToLive)
        {
            this.Deactivate();
        }
    }

    private void OnDisable()
    {
        elapsedSeconds = 0;
        BulletOwner = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogWarning(gameObject.name + " hit " + other.gameObject.name);
        var enemy = other.gameObject.GetComponent<Character>();
        if (enemy != null && enemy.CharacterType != CharacterType)
        {
            if (!doesDamageOverTime)
            {
                enemy.TakeDamage(Attack);
            }
            else
            {
                enemy.DoDamageOverTime(Attack, SecondsDoTActive);
            }
            if (!isPiercingShot)
            {
                this.Deactivate();
                return;
            }
        }
        var powerup = other.gameObject.GetComponent<IPowerup>();

        if (powerup != null && BulletOwner != null)
        {
            powerup.HandlePowerup(BulletOwner);
            if (!isPiercingShot)
            {
                this.Deactivate();
                return;
            }
        }

    }
}
