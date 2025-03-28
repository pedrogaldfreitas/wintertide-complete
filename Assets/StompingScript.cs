using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingScript : MonoBehaviour
{
    //Having this script on the statue will automatically make the statue stomp while moving.
    AudioSource stompSound1;
    AudioSource stompSound2;
    public float stompSpeed;    //max. 2f

    void Start()
    {
        stompSound1 = GetComponents<AudioSource>()[2];
        stompSound2 = GetComponents<AudioSource>()[3];
        StartCoroutine(Stomp());

    }

    IEnumerator Stomp()
    {
        bool playSound1 = true;

        while (true)
        {
            if (playSound1)
            {
                stompSound1.Play();
            } else
            {
                stompSound2.Play();
            }

            playSound1 = !playSound1;
            yield return new WaitForSeconds(2f - stompSpeed);
        }
    }
}
