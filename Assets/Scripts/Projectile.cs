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

    public CharacterType CharacterType
    {
        get;set;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogWarning(gameObject.name + " hit " + other.gameObject.name);
        var enemy = other.gameObject.GetComponent<Character>();
        if(enemy != null && enemy.CharacterType != CharacterType)
        {
            enemy.TakeDamage(Attack);
            this.Deactivate();
        }
        
    }
}
