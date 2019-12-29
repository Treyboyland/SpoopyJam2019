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
                return Input.GetAxis("VerticalPlayer");
            case PlayerCount.TWO_PLAYER:
                return Input.GetAxis("VerticalPlayer_" + (uint)playerName);
            default:
                return 0;
        }
    }

    public static float GetValueForHoriztontalAxis(PlayerCount playerCount, PlayerName playerName)
    {
        switch (playerCount)
        {
            case PlayerCount.SINGLE_PLAYER_KEYBOARD:
                return Input.GetAxis("HorizontalPlayer");
            case PlayerCount.TWO_PLAYER:
                return Input.GetAxis("HorizontalPlayer_" + (uint)playerName);
            default:
                return 0;
        }
    }

    public static bool GetFireButtonForPlayer(PlayerCount playerCount, PlayerName playerName)
    {
        switch (playerCount)
        {
            case PlayerCount.SINGLE_PLAYER_KEYBOARD:
            case PlayerCount.SINGLE_PLAYER_MOUSE:
                return Input.GetButton("Fire");
            case PlayerCount.TWO_PLAYER:
                return Input.GetButton("Fire_" + (uint)playerName);
            default:
                return false;
        }
    }

    public static bool GetFireButtonDownForPlayer(PlayerCount playerCount, PlayerName playerName)
    {
        switch (playerCount)
        {
            case PlayerCount.SINGLE_PLAYER_MOUSE:
            case PlayerCount.SINGLE_PLAYER_KEYBOARD:
                return Input.GetButtonDown("Fire");
            case PlayerCount.TWO_PLAYER:
                return Input.GetButtonDown("Fire_" + (uint)playerName);
            default:
                return false;
        }
    }

    public static bool GetReloadButtonDownForPlayer(PlayerCount playerCount, PlayerName playerName)
    {
        switch (playerCount)
        {
            case PlayerCount.SINGLE_PLAYER_MOUSE:
            case PlayerCount.SINGLE_PLAYER_KEYBOARD:
                return Input.GetButtonDown("Reload");
            case PlayerCount.TWO_PLAYER:
                return Input.GetButtonDown("Reload_" + (uint)playerName);
            default:
                return false;
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
    PLAYER_ONE = 1,
    PLAYER_TWO
}

public enum AxisType
{
    HORIZONTAL,
    VERTICAL
}