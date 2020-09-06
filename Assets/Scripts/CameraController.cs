using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotation = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputControls();
    }

    void InputControls()
    {
        

        if (Input.GetKey(KeyCode.W)) // Move Forward
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.S)) // Move Backward
        {
            transform.position -= transform.forward * (speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D)) // Move Right
        {
            transform.position += transform.right * (speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A)) // Move Left
        {
            transform.position -= transform.right * (speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q)) //Rotate Anticlockwise
        {
            transform.Rotate(0.0f, -rotation * Time.deltaTime, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.E)) //Rotate Clockwise

            transform.Rotate(0.0f, rotation * Time.deltaTime, 0.0f, Space.World);

    }
}
