using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class PlayerWeaponDataUi : MonoBehaviour
{
    [SerializeField]
    int playerNum;

    PlayerData data;

    TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        if ((GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_KEYBOARD ||
            GameConstants.PlayerCount == PlayerCount.SINGLE_PLAYER_MOUSE) && playerNum != 1)
        {
            this.Deactivate();
            return;
        }

        data = GetComponentInParent<PlayerData>();
        data.OnUpdateUi.AddListener(UpdatePlayerData);
    }


    void UpdatePlayerData(Player p)
    {
        if (p.PlayerInt == playerNum)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("" + p.PlayerInt + ": ");
            sb.Append(p.EquippedWeapon.WeaponName + " ");
            if (p.EquippedWeapon.IsReloading)
            {
                sb.Append("(Reloading: " + p.EquippedWeapon.GetReloadTimeRemaining() + ") ");
            }
            else
            {
                sb.Append("(" + p.EquippedWeapon.CurrentAmmo + "/" + p.EquippedWeapon.MaxAmmo + ") ");
            }

            sb.Append("Ammo: " + p.EquippedWeapon.Bullet.AmmoName);

            textBox.text = sb.ToString();
        }
    }


}
