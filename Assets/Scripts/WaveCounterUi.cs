using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WaveCounterUi : MonoBehaviour
{
    [SerializeField]
    RoundController roundController;

    TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        roundController.OnUpdateWaves.AddListener((waveNum) =>
        {
            textBox.text = "Wave: " + waveNum;
        });
    }
}
