using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    [SerializeField]private Material[] icons;
    private Light iconLight;
    private MeshRenderer planeRenderer;

    private void Awake()
    {
        iconLight = GetComponentInChildren<Light>();
        planeRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var activeFlash = GameObject.Find("FlashLight").GetComponent<FlashlightOnOff>().activated;

        if (activeFlash) { planeRenderer.material = icons[1]; iconLight.color = Color.green; return;}
        iconLight.color = Color.white;
        planeRenderer.material = icons[0];
    }
}
