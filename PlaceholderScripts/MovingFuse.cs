using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFuse : MonoBehaviour
{
    public Vector3 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            if(opening)
            {
                MoveFuse(endPos);
            }
            else
            {
                MoveFuse(startPos);
            }
        }
    }

    void MoveFuse(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);
        if(dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if(opening)
            {
                delay += Time.deltaTime;
                if(delay > 1.5f)
                {
                    opening = false;
                }
            }
        }

    }

    public bool Moving 
    {
        get {return moving; }
        set {moving = value; }

    }

}
