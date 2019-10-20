using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFlipper : MonoBehaviour
{
    [SerializeField]
    Vector3 multiplier;

    [SerializeField]
    float secondsBeforeFlip;

    float seconds = 0;

    bool originalGotten = false;

    Vector3 originalScale;
    
    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= secondsBeforeFlip)
        {
            PerformFlip();
            seconds = 0;
        }
    }

    void PerformFlip()
    {
        Vector3 newVector3 = transform.localScale;
        newVector3.x *= multiplier.x;
        newVector3.y *= multiplier.y;
        newVector3.z *= multiplier.z;
        transform.localScale = newVector3;
    }

    void GetOriginalScale()
    {
        if (!originalGotten)
        {
            originalScale = transform.localScale;
            originalGotten = true;
        }
    }


    void OnEnable()
    {
        GetOriginalScale();
        seconds = 0;
        transform.localScale = originalScale;
    }
}
