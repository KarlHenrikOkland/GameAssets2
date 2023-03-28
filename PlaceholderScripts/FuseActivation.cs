using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseActivation : MonoBehaviour
{
    public bool isInRange;
     public GameObject fuse;
    // Start is called before the first frame update
    void Start()
    {
        fuse = GameObject.FindGameObjectWithTag("Fuse");
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider collision)
        {
            if(collision.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log("Player now in range");
            
                if(Input.GetKeyDown(KeyCode.E))
                {
                    fuse.SetActive(true);
                }
            
            
        
            
            }

        }  
    
    
    }














}
