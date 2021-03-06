﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected CharacterType characterType;

    public CharacterType CharacterType
    {
        get
        {
            return characterType;
        }
        set
        {
            characterType = value;
        }
    }

    [SerializeField]
    protected float maxHealth;

    protected float health;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Min(Mathf.Max(0, value), maxHealth);
        }
    }

    public bool IsDead
    {
        get
        {
            return health == 0;
        }
    }

    public CharacterDamaged OnCharacterDamaged;
    public CharacterDefeated OnCharacterDefeated;

    public DisableCharacter OnDisableCharacter;


    // Start is called before the first frame update
    protected void Start()
    {
        FullHeal();
    }

    private void OnEnable()
    {
        FullHeal();
    }

    /// <summary>
    /// Restore to full health
    /// </summary>
    void FullHeal()
    {
        health = maxHealth;
    }

    protected void Update()
    {
        if (IsDead)
        {
            OnCharacterDefeated.Invoke(this);
            if (characterType == CharacterType.ENEMY && SoundController.Controller != null)
            {
                SoundController.Controller.OnPlaySkeletonDeathSound.Invoke();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (damage > 0)
        {
            OnCharacterDamaged.Invoke(damage);
            if (characterType == CharacterType.ENEMY && SoundController.Controller != null)
            {
                SoundController.Controller.OnPlaySkeletonHurtSound.Invoke();
            }
        }
    }

    public void DoDamageOverTime(float damage, int seconds)
    {
        StartCoroutine(DamageOverTime(damage, seconds));
    }


    IEnumerator DamageOverTime(float damage, int seconds)
    {
        //NOTE: Assuming
        for (int i = 0; i < seconds; i++)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void Heal(float amount)
    {
        Health += amount;
    }

}
