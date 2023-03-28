using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinStart : MonoBehaviour
{

    public AnimationClip myClip;
    public bool triggerIsOn;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
  

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
            audioSource.PlayOneShot(clip, volume);
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

