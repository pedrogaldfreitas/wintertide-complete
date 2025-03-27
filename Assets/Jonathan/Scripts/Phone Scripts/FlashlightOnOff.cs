using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOnOff : MonoBehaviour
{
    /// <summary>
    /// Determines when flashlight is on or off
    /// </summary>
    public bool activated;
    private Light flashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = this.gameObject.GetComponent<Light>();

        //disables flashlight to begin with
        flashlight.enabled = false;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && activated)
        {
            activated = false;
            flashlight.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.F) && !activated)
        {
            activated = true;
            flashlight.enabled = true;
        }
    }
}
