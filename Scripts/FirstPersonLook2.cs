using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook2 : MonoBehaviour
{
    Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;
    private float rotX;
    private float rotY;
    public Transform theKey;
  public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    public float turnSpeed = 4.0f;
    public Camera theCam;

    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
         MouseAiming();
    }



 void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        
        // rotate the camera
        
        Vector3 camRot = theCam.transform.eulerAngles;
        camRot.x = -rotX;
        theCam.transform.eulerAngles = camRot;
       

        Vector3 body = transform.eulerAngles;
        body.y += y;
        transform.eulerAngles = body;


    }


        // Get smooth mouse look.
        // Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        // appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        // currentMouseLook += appliedMouseDelta;
        // currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);
        





}
