using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float turnSpeed = 200.0f;
    public string dialog = "ouch";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fwd = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        turn *= turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        Vector3 pos = transform.position;
        Vector3 forward = transform.forward;

        forward *= fwd * Time.deltaTime * walkSpeed;
        pos += forward;

        transform.position = pos;
    }
}
