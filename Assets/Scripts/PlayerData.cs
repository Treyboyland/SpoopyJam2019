using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    List<Player> players;

    [SerializeField]
    LifeCounter counter;

    public UpdateUi OnUpdateUi;

    public UpdateLivesUi OnUpdateLives;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Player player in players)
        {
            player.OnPlayerDataUpdated.AddListener((p) => OnUpdateUi.Invoke(p));
            counter.OnLivesUpdated.AddListener((lives) => OnUpdateLives.Invoke(lives));
        }
    }
}
