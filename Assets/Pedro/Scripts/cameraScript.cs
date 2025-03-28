using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    float mouseX;
    float mouseY;
    [SerializeField]
    float mouseSensitivity;
    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 144;
    }


    void FixedUpdate()
    {
        mouseX = Input.GetAxisRaw("Mouse X")*mouseSensitivity*Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y")*mouseSensitivity*Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up*mouseX);
    }

}
