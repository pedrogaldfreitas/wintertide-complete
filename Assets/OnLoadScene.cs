using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoadScene : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().itemCheck = "Phone";
        StartCoroutine(playDiag());
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("quadrangleScene"))
        {
            GameObject.Find("Statue").SetActive(true);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("busStop"))
        {
            GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 1f);
        }
    }

    IEnumerator playDiag()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BuildingMaze"))
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag1"));
        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("parkingLot"))
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag1"));
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("busStop"))
        {
            player.GetComponent<playerMovement>().enabled = false;
            yield return new WaitForSeconds(3f);
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag0"));
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag1"));
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag2"));
            player.GetComponent<playerMovement>().enabled = true;
            yield return StartCoroutine(GameObject.Find("CutsceneManager").GetComponent<cutsceneManager>().FadeOut(GameObject.Find("BlackScreen")));
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag4"));
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag5"));
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("quadrangleScene"))
        {
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag7"));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
