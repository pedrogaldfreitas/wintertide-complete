using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBoxScript : MonoBehaviour
{
    public bool flicked;
    public GameObject otherLight;
    private AudioSource switchFlipAudio;

    private void Start()
    {
        switchFlipAudio = transform.Find("Cube").GetComponents<AudioSource>()[1];        
    }

    private void Update()
    {
        if (flicked == false)
        {
            transform.Find("Point Light").GetComponent<Light>().color = Color.red;
        } else
        {
            transform.Find("Point Light").GetComponent<Light>().color = Color.green;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Crosshair" && !flicked)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                flicked = true;
                switchFlipAudio.Play();
                otherLight.GetComponent<Light>().color = Color.green;
            }
        }
    }
}
