using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager Manager
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    List<BehaviourAndProbability> initialPowerups;

    BehaviourProabilityList possiblePowerups;

    [SerializeField]
    float powerupProbability;

    public SpawnPowerup OnSpawnPowerup;

    int powerupMax;

    PowerupPoolOnDemand powerupPool;

    public CharacterDefeated OnCharacterDefeated;

    public GameOver OnGameOver;

    private void Awake()
    {
        // if (_instance != null && this != _instance)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        possiblePowerups = new BehaviourProabilityList(initialPowerups);
        OnSpawnPowerup.AddListener(CheckForSpawn);
        powerupPool = GameObject.FindGameObjectWithTag("PowerupPool").GetComponent<PowerupPoolOnDemand>();
        SetPowerupMax();
    }

    void SetPowerupMax()
    {
        foreach (var powerup in possiblePowerups)
        {
            powerupMax += powerup.Probability;
        }
    }

    void CheckForSpawn(Vector3 worldPosition)
    {
        float powerupRoll = UnityEngine.Random.Range(0.0f, 1.0f);
        if (powerupRoll < powerupProbability)
        {
            SpawnPowerup((PowerupController)possiblePowerups.GetRandomObject(), worldPosition);

        }
    }

    void SpawnPowerup(PowerupController powerup, Vector3 worldPosition)
    {
        var obj = powerupPool.GetObject(powerup);
        obj.transform.position = worldPosition;
        obj.Activate();
    }
}
