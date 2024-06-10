using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float maxRotationAngle = 70.0f;

    private float currentRotationAngle = 0.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotationAngle += mouseX;

        currentRotationAngle = Mathf.Clamp(currentRotationAngle, -maxRotationAngle, maxRotationAngle);

        transform.localRotation = Quaternion.Euler(0, currentRotationAngle, 0);
    }
}
