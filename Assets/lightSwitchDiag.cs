using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitchDiag : MonoBehaviour
{
    private bool flag = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&&(flag == false))
        {
            flag = true;
            StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag9"));
        }
    }
}
