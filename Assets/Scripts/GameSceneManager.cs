using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    [SerializeField]
    string titleScenePath;

    [SerializeField]
    string gameScenePath;

    static GameSceneManager _instance;

    public static GameSceneManager Manager
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void LoadTitleScene()
    {
        SceneManager.LoadScene(titleScenePath, LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScenePath, LoadSceneMode.Single);
    }
}
