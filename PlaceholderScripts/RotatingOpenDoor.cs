using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOpenDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public bool isDoorOpen = false;

    public float speed = 25.0f;
    public Vector3 initialEulers;
    public float openAngle = 90.0f;
    public Transform theKey;
    public Vector3 eulers;
    public Transform thePlayer;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            transform.Rotate(0,  speed * Time.deltaTime , 0);
            if(transform.eulerAngles.y > initialEulers.y + openAngle)
            {
            

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isDoorOpen == false)
        {
          //we only allow player to pass
          Debug.Log("player hit");
          doorOpen = true;

          if(theKey == thePlayer)
          {
              doorOpen = true;
          }
        
        }

    }





}
