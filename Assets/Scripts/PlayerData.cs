using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    LifeCounter counter;

    public UpdateUi OnUpdateUi;

    public UpdateLivesUi OnUpdateLives;

    // Start is called before the first frame update
    void Start()
    {
        player.OnPlayerDataUpdated.AddListener((p) => OnUpdateUi.Invoke(p));
        counter.OnLivesUpdated.AddListener((lives) => OnUpdateLives.Invoke(lives));
    }
}
