using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    public float xRotation;

    public bool isLowerDown;

    [Header("Camera Height")]
    public float lowerDownHeight = 5.3f;
    public float standUpHeight = 6.8f;

    [Header("Camera Movement")]
    public float cameraMoveSpeed = 2f;

    private Vector3 lowerDownPosition;
    private Vector3 standUpPosition;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * Variable.Sensitivity;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(
            Vector3.up * (mouseX * Time.deltaTime) * Variable.Sensitivity
        );
    }

    private void Update()
    {
        standUpPosition = transform.position + Vector3.up * standUpHeight;
        lowerDownPosition = transform.position + Vector3.up * lowerDownHeight;

        if (isLowerDown)
        {
            LowerDown();
        }
        else
        {
            StandUp();
        }
    }

    public void LowerDown()
    {
        if (isLowerDown)
        {
            camera.transform.position = Vector3.MoveTowards(
                camera.transform.position,
                lowerDownPosition,
                cameraMoveSpeed * Time.deltaTime
            );
        }
    }

    public void StandUp()
    {
        if (!isLowerDown)
        {
            camera.transform.position = Vector3.MoveTowards(
                camera.transform.position,
                standUpPosition,
                cameraMoveSpeed * Time.deltaTime
            );
        }
    }
}