using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushDialogueTrigger : MonoBehaviour
{
    private bool flag = false;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&&(flag == false))
        {
            flag = true;
            GameObject.Find("Crosshair").GetComponent<objectInteraction>().BushDiag();
        }
    }
}
