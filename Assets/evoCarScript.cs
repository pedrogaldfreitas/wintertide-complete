using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class evoCarScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EndGame();
    }

    void EndGame()
    {
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        GameObject.Find("Player").GetComponent<Animator>().SetFloat("Horizontal", 0f);
        GameObject.Find("Player").GetComponent<Animator>().SetFloat("Vertical", 0f);
        GameObject.Find("Main Camera").GetComponent<cameraScript>().enabled = false;
        GameObject.Find("Statue").GetComponent<statueScript>().enabled = false;
        GameObject.Find("StatueSoundEffect").GetComponent<AudioSource>().Stop();
        GameObject.Find("Statue").GetComponents<AudioSource>()[0].Stop();
        GameObject.Find("Statue").GetComponents<AudioSource>()[1].Stop();
        GameObject.Find("HorrorSounds").GetComponents<AudioSource>()[0].Stop();
        GameObject.Find("HorrorSounds").GetComponents<AudioSource>()[1].Stop();
        GameObject.Find("HorrorSounds").GetComponents<AudioSource>()[2].Stop();

        GameObject.Find("AmbienceSound").GetComponent<AudioSource>().Stop();



        GetComponent<AudioSource>().Play();
        StartCoroutine(ending());
    }

    IEnumerator ending()
    {
        yield return StartCoroutine(GameObject.Find("CutsceneManager").GetComponent<cutsceneManager>().FadeIn(GameObject.Find("BlackScreen")));
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag3"));
        yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag4"));
        yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag5"));
        yield return StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiagLong("diag6"));
        yield return new WaitForSeconds(5f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");

    }
}
