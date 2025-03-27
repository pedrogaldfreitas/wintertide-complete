using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    public int sceneToLoadOnDeath;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("quadrangleScene"))
        {
            sceneToLoadOnDeath = 1;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BuildingMaze"))
        {
            sceneToLoadOnDeath = 2;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("parkingLot"))
        {
            sceneToLoadOnDeath = 3;
        }
    }
}
