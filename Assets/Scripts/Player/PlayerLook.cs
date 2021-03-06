using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float xRotation = 0f;

    public Camera cam;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        if (MobileManager.usingMobile)
        {
            // Increase look sensitivity if on mobile
            xSensitivity = 100f;
            ySensitivity = 100f;
        }

        float mouseX = input.x;
        float mouseY = input.y;

        // calculating camera rotation to look up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply to camera
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate player
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
