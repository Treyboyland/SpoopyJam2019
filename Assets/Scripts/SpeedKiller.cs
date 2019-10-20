using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedController))]
public class SpeedKiller : MonoBehaviour
{
    SpeedController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SpeedController>();
        GameManager.Manager.OnGameOver.AddListener(() =>
        {
            controller.Speed = 0;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
