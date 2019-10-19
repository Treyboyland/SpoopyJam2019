using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    List<EnemyController> randomCharacterPrefabs;

    [SerializeField]
    List<Vector3> localPositions;

    [SerializeField]
    float waitTime;

    public float WaitTime
    {
        get
        {
            return waitTime;
        }
        set
        {
            waitTime = value;
        }
    }

    [SerializeField]
    bool hasRandomWaitTime;

    public bool HasRandomWaitTime
    {
        get
        {
            return hasRandomWaitTime;
        }
        set
        {
            hasRandomWaitTime = value;
        }
    }

    [SerializeField]
    Vector2 randomWaitTime;

    public Vector2 RandomWaitTime
    {
        get
        {
            return randomWaitTime;
        }
        set
        {
            randomWaitTime = value;
        }
    }


    [SerializeField]
    bool isRandomlyPlaced;

    [SerializeField]
    int countIfRandomlyPlaced;

    public int CountIfRandomlyPlaced
    {
        get
        {
            return countIfRandomlyPlaced;
        }
        set
        {
            countIfRandomlyPlaced = value;
        }
    }

    [SerializeField]
    Vector2 randomMin;

    public Vector2 RandomMin
    {
        get
        {
            return randomMin;
        }
        set
        {
            randomMin = value;
        }
    }

    [SerializeField]
    Vector2 randomMax;

    public Vector2 RandomMax
    {
        get
        {
            return randomMax;
        }
        set
        {
            randomMax = value;
        }
    }

    List<EnemyController> spawnedCharacters = new List<EnemyController>();

    public bool IsSpawnComplete { get; set; } = false;

    public bool IsWaveDefeated { get; set; } = false;

    CharacterPoolOnDemand characterPool;


    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void OnEnable()
    {
        spawnedCharacters.Clear();
        IsSpawnComplete = false;
        IsWaveDefeated = false;
        characterPool = GameObject.FindGameObjectWithTag("CharacterPool").GetComponent<CharacterPoolOnDemand>();
        StartCoroutine(SpawnStuffAndWait());
    }

    float GetWaitTime()
    {
        return hasRandomWaitTime ? UnityEngine.Random.Range(randomWaitTime.x, randomWaitTime.y) : waitTime;
    }

    bool AreActive()
    {
        foreach (var character in spawnedCharacters)
        {
            if (character.gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    Vector3 GetRandomVector3()
    {
        float x = Random.Range(randomMin.x, randomMax.x);
        float y = Random.Range(randomMin.y, randomMax.y);

        return new Vector3(x, 0, y);
    }

    IEnumerator SpawnStuffAndWait()
    {
        for (int i = 0; i < (isRandomlyPlaced ? countIfRandomlyPlaced : localPositions.Count); i++)
        {
            Vector3 localPos = isRandomlyPlaced ? GetRandomVector3() : localPositions[i];
            Spawn(localPos);
            yield return new WaitForSeconds(GetWaitTime());
        }
        IsSpawnComplete = true;

        while(AreActive())
        {
            yield return new WaitForSeconds(1.0f); //Doesn't need to be immediate..
        }

        IsWaveDefeated = true;
    }

    void Spawn(Vector3 localPos)
    {
        int index = Random.Range(0, randomCharacterPrefabs.Count);
        var toSpawn = randomCharacterPrefabs[index];
        var spawned = characterPool.GetObject(toSpawn);
        spawned.transform.SetParent(this.transform);
        spawned.transform.localPosition = localPos;
        spawned.Activate();
    }
}
