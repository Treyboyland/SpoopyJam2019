using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputs
{
    public static float GetValueForVerticalAxis(PlayerCount playerCount, PlayerName playerName)
    {
        switch (playerCount)
        {
            case PlayerCount.SINGLE_PLAYER_KEYBOARD:
            case PlayerCount.TWO_PLAYER:

            default:
                return 0;
        }
    }
}


public enum PlayerCount
{
    SINGLE_PLAYER_KEYBOARD,
    SINGLE_PLAYER_MOUSE,
    TWO_PLAYER,
}

public enum PlayerName : uint
{
    PLAYER_ONE,
    PLAYER_TWO
}

public enum AxisType 
{
    HORIZONTAL,
    VERTICAL
}