using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DisableOnParticleFinished : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        FindReference();
    }

    void FindReference()
    {
        ps = ps == null ? GetComponent<ParticleSystem>() : ps;
    }

    private void OnEnable()
    {
        FindReference();
        StartCoroutine(WaitForFinishThenDisable());
    }

    IEnumerator WaitForFinishThenDisable()
    {
        ps.Play();
        while (ps.isPlaying || ps.isEmitting)
        {
            yield return null;
        }

        this.Deactivate();
    }
}
