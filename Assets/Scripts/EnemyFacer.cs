using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacer : MonoBehaviour
{
    static GameObject moveTowards;


    // Start is called before the first frame update
    void Start()
    {
        FindReference();
    }

    void FindReference()
    {
        if (moveTowards == null)
        {
            moveTowards = GameObject.FindGameObjectWithTag("GameCenter");
        }
    }

    private void OnEnable()
    {
        FindReference();
        transform.LookAt(moveTowards.transform);
    }

}
