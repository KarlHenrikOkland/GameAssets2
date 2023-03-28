using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform target;
   public float distance = 5.0f;
   public float height = 3.0f;
   

   
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        Vector3 fwd = target.forward;

        pos -= fwd * distance;
        pos.y += height;
        transform.position = pos;
        transform.LookAt(target.position);

    }
}
