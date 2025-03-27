using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathButton : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;
    private string sceneToLoadString;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sceneToLoad = GameObject.Find("DONTDESTROYONLOAD").GetComponent<DontDestroyOnLoadScript>().sceneToLoadOnDeath;
    }

    public void onClickButtonPart1()
    {
        StartCoroutine(onClickRetryButton());
    }

    public IEnumerator onClickRetryButton()
    {
        StartCoroutine(FadeOutText(GameObject.Find("Text")));
        yield return StartCoroutine(FadeOutText(GameObject.Find("Hints")));
        if (sceneToLoad == 1)
        {
            sceneToLoadString = "quadrangleScene";
        } else if (sceneToLoad == 2)
        {
            sceneToLoadString = "BuildingMaze";
        } else if (sceneToLoad == 3)
        {
            sceneToLoadString = "parkingLot";
        }
        SceneManager.LoadScene(sceneToLoadString);
    }

    IEnumerator FadeOutText(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            obj.GetComponent<Text>().color = new Color(222f, 222f, 222f, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<Text>().color = new Color(222f, 222f, 222f, 0f);
    }

}
