using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStealer : MonoBehaviour
{
    [SerializeField]
    LifeCounter counter;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Character>();

        if (enemy != null && enemy.CharacterType == CharacterType.ENEMY)
        {
            enemy.OnDisableCharacter.Invoke();
            counter.NumLives--;
        }

    }
}
