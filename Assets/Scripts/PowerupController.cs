using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    Powerup powerup;
    // Start is called before the first frame update
    void Start()
    {
        powerup = GetComponentInChildren<Powerup>();
        powerup.OnPowerupTaken.AddListener(() =>
        {
            //Debug.LogWarning(gameObject.name + ": Powerup taken.");
            this.Deactivate();
        });
    }
}
