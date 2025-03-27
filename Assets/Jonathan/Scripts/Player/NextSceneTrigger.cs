using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{

    [SerializeField] private string sceneName;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "NextScene") return;
        StartCoroutine(this.gameObject.GetComponentInChildren<cutsceneManager>().FadeIn(GameObject.Find("BlackScreen")));
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(5f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        Debug.Log("Loaded");
        while (!asyncLoad.isDone) yield return null;
    }
}
