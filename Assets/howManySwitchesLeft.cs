using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howManySwitchesLeft : MonoBehaviour
{
    public int switchesLeft;

    void Start()
    {
        switchesLeft = 0;
    }

    public void ActivateOneMoreSwitch()
    {
        switchesLeft++;
        GetComponent<Text>().text = switchesLeft + "/4";
    }
}
