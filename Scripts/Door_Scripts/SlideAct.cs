using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideAct : MonoBehaviour
{
    public bool triggerIsOn;
    //public Text Text;
    public GameObject DoorUI;
    [SerializeField]
    private Camera characterCamera;

    //void Start()
    //
    //    Text.text = ("Press E");
    //}
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
           
            Debug.Log("Pressed E");

           





            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
           
            if (Physics.Raycast(ray, out RaycastHit item, 2f)) 
            { 
            var pickable = item.transform.GetComponent<SlideAct>();
             Debug.Log("Ray it");
            if (pickable)
            {
                // Pick it
             gameObject.GetComponent<Animation>().Play();
             //gameObject.GetComponent<BoxCollider>().enabled = false;
             //gameObject.GetComponent<BoxCollider>().enabled = true;

            }
            }
            
        }
    }

    //void OnTriggerEnter(Collider other)

    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Object Entered the trigger");
    //        triggerIsOn = true;
    //        DoorUI.SetActive(true);
        
        
          
    //    }
    //}

    //void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Object is within trigger");
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Object Exited the trigger");
    //        triggerIsOn = false;
    //        DoorUI.SetActive(false);



    //    }

    //}
}