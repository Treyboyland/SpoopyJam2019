using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    int numLives;

    public int NumLives
    {
        get
        {
            return numLives;
        }
        set
        {
            if (numLives > value && SoundController.Controller != null)
            {
                SoundController.Controller.OnPlayPlayerHurtSound.Invoke();
            }
            numLives = value;
            OnLivesUpdated.Invoke(NumLives);
        }
    }

    public LivesUpdated OnLivesUpdated;
}
