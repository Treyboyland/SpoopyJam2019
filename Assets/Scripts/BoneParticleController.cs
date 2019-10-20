using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneParticleController : MonoBehaviour
{
    [SerializeField]
    BoneParticle prefab;

    ParticleSystemOnDemand boneParticlePool;

    [SerializeField]
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        boneParticlePool = GameObject.FindGameObjectWithTag("BoneParticlePool").GetComponent<ParticleSystemOnDemand>();
        GameManager.Manager.OnCharacterDefeated.AddListener(SpawnBones);
    }

    void SpawnBones(Character character)
    {
        Color c = character.GetComponent<SpriteRenderer>().color;
        c.a = 1;
        Vector3 pos = character.transform.position;
        pos += offset;
        var particle = boneParticlePool.GetObject(prefab);
        particle.SetColor(c);
        particle.transform.position = pos;
        particle.Activate();
    }
}
