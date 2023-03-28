using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{

    public AnimationClip myClip;
    public bool triggerIsOn;
    public GameObject OpenPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animation>().AddClip(myClip, "myClipName");
    }


    // Update is called once per frame
  void Update()
    {
        if (triggerIsOn && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animation>().Play("myClipName");
            Debug.Log("E was pressed");

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player detected");
            triggerIsOn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player left");
            triggerIsOn = false;
        }
    }
}

