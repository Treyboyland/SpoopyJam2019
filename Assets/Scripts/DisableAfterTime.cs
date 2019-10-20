using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField]
    float secondsToWait;


    float secondsElapsed = 0;

    // Update is called once per frame
    void Update()
    {
        secondsElapsed += Time.deltaTime;

        if (secondsElapsed >= secondsToWait)
        {
            this.Deactivate();
        }
    }

    private void OnEnable()
    {
        secondsElapsed = 0;
    }
}
