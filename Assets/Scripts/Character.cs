using System.Collections;
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


    // Start is called before the first frame update
    protected void Start()
    {
        health = maxHealth;
    }

    protected void Update()
    {
        if (IsDead)
        {
            this.Deactivate();
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (damage > 0)
        {
            OnCharacterDamaged.Invoke(damage);
        }
    }

    public void Heal(float amount)
    {
        Health += amount;
    }

}
