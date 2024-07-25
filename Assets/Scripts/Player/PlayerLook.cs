using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    public float xRotation;


    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public bool isLowerDown;
    private Vector3 lowerDownPositon;
    private Vector3 standUpPositon;


    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }



    private void Update()
    {
        standUpPositon = transform.position + Vector3.up * 5.1f;
        lowerDownPositon = transform.position + Vector3.up * 3.9f;
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
        if(isLowerDown)
            if(Vector3.Distance(camera.transform.position, lowerDownPositon) > 0.01f)
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, lowerDownPositon, 0.02f);
    }

    public void StandUp()
    {
        if(!isLowerDown)
            if (Vector3.Distance(camera.transform.position, standUpPositon) > 0.01f)
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, standUpPositon, 0.02f);
    }
}
