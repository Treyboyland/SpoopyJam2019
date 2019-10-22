using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public PowerupTaken OnPowerupTaken;

}

public interface IPowerup
{
    void HandlePowerup(Player player);
}