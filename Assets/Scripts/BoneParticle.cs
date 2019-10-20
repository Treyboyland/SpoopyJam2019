using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneParticle : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        FindReferences();
    }

    void FindReferences()
    {
        ps = ps == null ? GetComponent<ParticleSystem>() : ps;
    }

    public void SetColor(Color c)
    {
        FindReferences();
        var mainModule = ps.main;
        mainModule.startColor = c;
    }
}
