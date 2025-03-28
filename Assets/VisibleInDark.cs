using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleInDark : MonoBehaviour
{
    public Material material;
    private Color originalColor;
    public float fadeSpeed = 1.0f;

    void Start()
    {
        originalColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        float lightLevel = RenderSettings.ambientIntensity;
        float alpha = Mathf.Clamp01(1.0f - lightLevel);
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
