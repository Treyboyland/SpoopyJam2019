using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Character body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<Character>();
        body.OnCharacterDefeated.AddListener((unused) =>
        {
            GameManager.Manager.OnSpawnPowerup.Invoke(transform.position);
            GameManager.Manager.OnCharacterDefeated.Invoke(body);
            this.Deactivate();
        });
        body.OnDisableCharacter.AddListener(() =>
        {
            this.Deactivate();
        });
    }

}
