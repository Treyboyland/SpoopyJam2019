using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerup : Powerup, IPowerup
{

    [SerializeField]
    int numExtraLives;

    static LifeCounter counter;

    void FindReference()
    {
        //Life counter is on the main camera
        counter = counter == null ? GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LifeCounter>() : counter;
    }

    public void HandlePowerup(Player p)
    {
        FindReference();
        if (counter != null)
        {
            counter.NumLives += numExtraLives;
        }
        else
        {
            Debug.LogWarning("" + gameObject.name + "NOTE: Unable to find LifeCounter");
        }

        OnPowerupTaken.Invoke();
    }
}
