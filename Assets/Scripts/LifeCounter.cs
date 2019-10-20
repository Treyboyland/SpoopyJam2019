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
            numLives = value;
            OnLivesUpdated.Invoke(NumLives);
        }
    }

    public LivesUpdated OnLivesUpdated;
}
