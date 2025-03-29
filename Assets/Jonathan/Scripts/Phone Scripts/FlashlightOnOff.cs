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
    public bool dimmerFlashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = this.gameObject.GetComponent<Light>();

        flashlight.enabled = true;
        activated = true;

        //When inside the building, the flashlight shoudl be dimmer. It's too strong when outside.
        if (dimmerFlashlight)
        {
            Light light = GetComponent<Light>();
            light.range = 15;
            light.intensity = 1.5f;
        }
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
