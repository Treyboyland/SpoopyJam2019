using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEventHandler : MonoBehaviour
{
    [SerializeField]
    RoundController roundController;

    [SerializeField]
    WeaponEquipper machineGunEquipper;

    public TimeRemaining OnTimeRemainingUpdated;


    // Start is called before the first frame update
    void Start()
    {
        roundController.OnUpdateRound.AddListener(HandleSpecialRoundEvent);
    }

    void HandleSpecialRoundEvent(int round)
    {
        //TODO: Special stuff
        if (round == 1)
        {
            //TODO: Equip Machine guns
            StartCoroutine(WaitThenEquip());
        }
    }

    IEnumerator WaitForTimeToEquip(float seconds, float secondsToEquip, WeaponEquipper equipper)
    {
        float elapsed = 0;
        bool hasEquipped = false;

        while (elapsed < seconds)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= secondsToEquip && !hasEquipped)
            {
                hasEquipped = true;
                equipper.EquipWeapons();
            }
            yield return null;
        }

        if (!hasEquipped)
        {
            equipper.EquipWeapons();
        }
    }

    IEnumerator WaitThenEquip()
    {
        roundController.OnChangeSpawn.Invoke(false);
        yield return StartCoroutine(WaitForTimeToEquip(5.0f, 2.0f, machineGunEquipper));
        roundController.OnChangeSpawn.Invoke(true);
    }
}
