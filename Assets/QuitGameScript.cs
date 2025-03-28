using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameScript : MonoBehaviour
{
    private bool pressedEscOnce;
    private GameObject quitGameText; 

    private void Start()
    {
        pressedEscOnce = false;
        quitGameText = GameObject.Find("QuitText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pressedEscOnce)
            {
                StartCoroutine(PressAgainToQuit());
            } else
            {
                //Quit.
                Application.Quit();
            }
        }
    }

    IEnumerator PressAgainToQuit()
    {
        pressedEscOnce = true;
        quitGameText.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(8);
        quitGameText.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        pressedEscOnce = false;
    }
}
