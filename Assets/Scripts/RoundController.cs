using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    List<WavesWithRound> customRounds;

    [SerializeField]
    List<Wave> easyWaves;

    [SerializeField]
    List<Wave> mediumWaves;

    [SerializeField]
    List<Wave> hardWaves;

    [SerializeField]
    List<Wave> insaneWaves;

    int roundNum = 0;

    [SerializeField]
    Vector3 minSpawn;

    [SerializeField]
    Vector3 maxSpawn;

    Dictionary<int, List<Wave>> customRoundDictionary = new Dictionary<int, List<Wave>>();

    WavePoolOnDemand wavePool;

    // Start is called before the first frame update
    void Start()
    {
        wavePool = GameObject.FindGameObjectWithTag("WavePool").GetComponent<WavePoolOnDemand>();
        MakeDictionary();
        StartCoroutine(DoRounds());
    }

    void MakeDictionary()
    {
        for (int i = 0; i < customRounds.Count; i++)
        {
            if (!customRoundDictionary.ContainsKey(customRounds[i].Round))
            {
                customRoundDictionary.Add(customRounds[i].Round, customRounds[i].Waves);
            }
            else
            {
                Debug.LogWarning("Round: " + customRounds[i].Round + " appears multiple times: " + i);
            }
        }
    }

    List<Wave> GetWaves()
    {
        if (IsEasyRound)
        {
            return easyWaves;
        }
        if (IsMediumRound)
        {
            return mediumWaves;
        }
        if (IsHardRound)
        {
            return hardWaves;
        }
        return insaneWaves;
    }

    bool IsEasyRound
    {
        get
        {
            return roundNum < 10;
        }
    }

    bool IsMediumRound
    {
        get
        {
            return roundNum < 20;
        }
    }

    bool IsHardRound
    {
        get
        {
            return roundNum < 30;
        }
    }


    int GetWavesPerRound()
    {
        if (IsEasyRound)
        {
            return 3;
        }
        if (IsMediumRound)
        {
            return 5;
        }
        if (IsHardRound)
        {
            return 10;
        }
        return 20;
    }

    float GetWaveWaitProbability()
    {
        if (IsEasyRound)
        {
            return 1;
        }
        if (IsMediumRound)
        {
            return 0.75f;
        }
        if (IsHardRound)
        {
            return 0.5f;
        }
        return 0.25f;
    }

    IEnumerator WaitForWaveCompletion(Wave wave)
    {
        while (!wave.IsWaveDefeated)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

    bool AreWavesCompleted(List<Wave> waves)
    {
        foreach (var wave in waves)
        {
            if (!wave.IsWaveDefeated)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator WaitForRoundCompletion(List<Wave> waves)
    {
        while (!AreWavesCompleted(waves))
        {
            yield return new WaitForSeconds(5.0f);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = UnityEngine.Random.Range(minSpawn.x, maxSpawn.x);
        float y = UnityEngine.Random.Range(minSpawn.y, maxSpawn.y);
        float z = UnityEngine.Random.Range(minSpawn.z, maxSpawn.z);

        return new Vector3(x, y, z);
    }

    Wave SpawnWave(Wave toSpawn)
    {
        var wave = wavePool.GetObject(toSpawn);
        wave.transform.position = GetRandomPosition();
        wave.Activate();

        return wave;
    }

    IEnumerator DoRounds()
    {
        while (true)
        {
            bool isCustomRound = customRoundDictionary.ContainsKey(roundNum);
            var waves = isCustomRound ? customRoundDictionary[roundNum] : GetWaves();
            int count = isCustomRound ? customRoundDictionary[roundNum].Count : GetWavesPerRound();

            for (int i = 0; i < count; i++)
            {
                var wave = SpawnWave(waves[i]);
                float waveWait = UnityEngine.Random.Range(0.0f, 1.0f);
                if (waveWait <= GetWaveWaitProbability())
                {
                    yield return StartCoroutine(WaitForWaveCompletion(wave));
                }
            }

            roundNum++;
            yield return new WaitForSeconds(3.0f);
        }

    }
}
