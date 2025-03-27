using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStatue : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Play Eery Sound
        this.gameObject.GetComponent<AudioSource>().enabled = true;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        this.gameObject.GetComponent<ActivateStatue>().enabled = false;//Disable Script
    }
}
