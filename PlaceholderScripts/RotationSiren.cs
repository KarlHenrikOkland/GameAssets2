using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSiren : MonoBehaviour
{
    //Declaring value of rotation
    public float RotationSpeed = 75.0f;

   

    // Update is called once per frame
    void Update()
    {
        //Rotation on Y Axis
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);

    }
}
