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
            if (numLives == 0)
            {
                GameManager.Manager.OnGameOver.Invoke();
            }
        }
    }

    public LivesUpdated OnLivesUpdated;
}
