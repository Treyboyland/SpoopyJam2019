using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounterUi : MonoBehaviour
{
    [SerializeField]
    LifeCounter lifeCounter;

    PlayerData data;

    TextMeshProUGUI textbox;

    int lives = 0;

    private void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();
        data = GetComponentInParent<PlayerData>();
        ChangeLives(lifeCounter.NumLives);
        data.OnUpdateLives.AddListener(ChangeLives);
    }

    void ChangeLives(int numLives)
    {
        if (numLives != lives)
        {
            lives = numLives;
            textbox.text = "Lives: " + lives;
        }
    }
}
