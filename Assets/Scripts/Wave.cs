using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    List<Character> randomCharacterPrefabs;

    [SerializeField]
    List<Vector2> localPositions;

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

    List<Character> spawnedCharacters = new List<Character>();

    public bool IsSpawnComplete { get; set; } = false;

    public bool IsWaveDefeated { get; set; } = false;

    CharacterPoolOnDemand characterPool;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        spawnedCharacters.Clear();
        IsSpawnComplete = false;
        IsWaveDefeated = false;
        characterPool = GameObject.FindGameObjectWithTag("CharacterPool").GetComponent<CharacterPoolOnDemand>();
    }

    bool AreActive()
    {
        foreach (Character character in spawnedCharacters)
        {
            if (character.gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    Vector2 GetRandomVector2()
    {
        float x = Random.Range(randomMin.x, randomMax.x);
        float y = Random.Range(randomMin.y, randomMax.y);

        return new Vector2(x, y);
    }

    IEnumerator SpawnStuffAndWait()
    {
        for (int i = 0; i < (isRandomlyPlaced ? countIfRandomlyPlaced : localPositions.Count); i++)
        {
            Vector2 localPos = isRandomlyPlaced ? GetRandomVector2() : localPositions[i];
            yield return null;
        }
    }

    void Spawn()
    {

    }
}
