using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponDataUi : MonoBehaviour
{
    [SerializeField]
    int playerNum;

    PlayerData data;

    // Start is called before the first frame update
    void Start()
    {
        if ((GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_KEYBOARD ||
            GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_MOUSE) && playerNum != 1)
        {
            this.Deactivate();
            return;
        }
    }


    void UpdatePlayerData(Player p)
    {
        if(p.PlayerInt == playerNum)
        {
            
        }
    }


}
