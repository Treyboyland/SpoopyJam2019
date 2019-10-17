using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoBehaviourExtensions
{
    public static void Activate(this MonoBehaviour mono)
    {
        mono.gameObject.SetActive(true);
    }

    public static void Deactivate(this MonoBehaviour mono)
    {
        mono.gameObject.SetActive(false);
    }
}
