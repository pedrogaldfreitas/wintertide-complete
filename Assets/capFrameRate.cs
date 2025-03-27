using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capFrameRate : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 30;
    }
}
