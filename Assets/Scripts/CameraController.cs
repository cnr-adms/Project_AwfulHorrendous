using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera sceneCamera;

    // Movement and rotation variables
    public float speed = 1.0f,
                 rotation = 10.0f;

    // Zooming variables
    float zoomTime,
          zoomTarget,
          lastScrollWheelDirection;

    public float scrollSpeed = 10.0f,
                 yMin = -30.0f,
                 yMax = 100.0f;

    private float scrollWheel
    {
        get { return Input.GetAxis("Mouse ScrollWheel"); }
    }


    // Start is called before the first frame update
    void Start()
    {
        sceneCamera = Camera.main;
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
        {
            transform.Rotate(0.0f, rotation * Time.deltaTime, 0.0f, Space.World);
        }

        ZoomControl();

    }

    void ZoomControl()
    {
        //Resets zoomTarget if direction of zoom direction changes
        if ((lastScrollWheelDirection > 0 && scrollWheel < 0) ||
            (lastScrollWheelDirection < 0 && scrollWheel > 0))
        {
            zoomTarget = 0;
        }
        if (scrollWheel != 0)
        {
            lastScrollWheelDirection = scrollWheel;
        }

        // zoomTarget defined. Amount left to be zoomed
        zoomTarget += scrollWheel * scrollSpeed;

        // zoomTime defined. Change in scrollWheel resets zoomTime, restarts .Lerp
        if (scrollWheel != 0)
        {
            zoomTime = 0;
        }

        if (zoomTarget != 0)
        {
            zoomTime += Time.deltaTime;

            // Calculating interpolation. scrollSpeed, or zoomTime's divisor can alter speed of zoom
            float zoomInt = Mathf.Lerp(0, zoomTarget, zoomTime / 4.0f);
            Vector3 translation = new Vector3(0, zoomInt, 0);

            // Zoom camera amount calculated this frame
            transform.position -= translation;

            // Decrease zoomTarget amount moved this frame
            zoomTarget -= translation.y;
    
        }

        // Sets limits for zooming
        var camPos = sceneCamera.transform.position.y;
        var yRange = Mathf.Clamp(camPos, yMin, yMax);
        //float xShift = 1.0f;
        
        if (camPos < yMin || camPos > yMax)
        {
            sceneCamera.transform.position = new Vector3(sceneCamera.transform.position.x, yRange, sceneCamera.transform.position.z);
        }

        /* Will probably replace with for loops as there is a defined endpoint? Affecting the the cameraRig rotation doesn't have the desired effect
        
        while (camPos < 20.0f && camPos--)
        {
            Vector3 xRotation = new Vector3(-xShift * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            Quaternion rotation = Quaternion.Euler(xRotation);
            transform.rotation = rotation;
        }
        
        while (camPos < 20.0f && camPos++)
        {
            Vector3 xRotation = new Vector3(xShift * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            Quaternion rotation = Quaternion.Euler(xRotation);
            transform.rotation = rotation;
        }
        */
    }

    void DefaultCameraPosition ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //sceneCamera.transform.localPosition.x = Vector3.zero;
            //var restoreX = Mathf.Lerp(sceneCamera.localPostition.x, 35, Time.deltaTime);
            //transform.postiion = restoreX;
        }
    }

    
}
