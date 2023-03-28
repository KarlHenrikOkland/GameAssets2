using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class InteractiveAsset : MonoBehaviour
{
    public GameObject PostProcessing;
    public PostProcessProfile ppProfile;


   public bool isInRange;
   public KeyCode input;
   public UnityEvent interactAction;
   
    public GameObject fuse;
    public 
    
    // public AnimationClip RotationTop;
    // public AnimationClip RotatingFanEngine;
    // public GameObject Propeller;
    // Animator anim;


   
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<Animation>().AddClip(RotationTop, "RotationTop");
        // gameObject.GetComponent<Animation>().AddClip(RotatingFanEngine, "RotatingFanEngine");
               

    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
        

            if(Input.GetKeyDown(KeyCode.E))
            {
                //Interaction starts
                interactAction.Invoke();
                
                
                // gameObject.GetComponent<Animation>().Play("RotationTop");
                // gameObject.GetComponent<Animation>().Play("RotatingFanEngine");
                
                //deactivate emergency lights
                
                

            }
        
        }
    
    }
    
        private void OnTriggerEnter(Collider collision)
    
    
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
            
        
            
        }

    }    
        private void OnTriggerExit(Collider collision)
      
    {
        if(collision.gameObject.CompareTag("Player"))
       
        {
            isInRange = false;
            Debug.Log("Player not in range");
        }

    }


}
