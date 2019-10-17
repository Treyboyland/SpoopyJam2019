using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField]
    float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    void MoveForward()
    {
        var pos = transform.position;
        pos += speed * transform.forward * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
