using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howManySwitchesLeft : MonoBehaviour
{
    public int switchesActivated;
    private GameObject ambienceSound;

    void Start()
    {
        switchesActivated = 0;
        ambienceSound = GameObject.Find("AmbienceSound");
    }

    public void ActivateOneMoreSwitch()
    {
        switchesActivated++;
        GetComponent<Text>().text = switchesActivated + "/4";
        switch(switchesActivated) {
            case 1:
                ambienceSound.GetComponents<AudioSource>()[0].volume += 0.35f;
                break;
            case 2:
                ambienceSound.GetComponents<AudioSource>()[1].volume += 0.30f;
                break;
            case 3:
                ambienceSound.GetComponents<AudioSource>()[0].volume += 0.25f;
                ambienceSound.GetComponents<AudioSource>()[1].volume += 0.35f;
                ambienceSound.GetComponents<AudioSource>()[3].Play();
                break;
            case 4:
                ambienceSound.GetComponents<AudioSource>()[2].Play();
                break;
        }
    }

    //Used for testing.
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateOneMoreSwitch();
        }*/
    }
}
