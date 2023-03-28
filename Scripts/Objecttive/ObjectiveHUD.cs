using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveHUD : MonoBehaviour
{

    public GameObject objectiveUI;
    private float seconds;
    public float objectiveStep;
    public Text objectiveTextUI;

    // Start is called before the first frame update
    void Start()
    {
        //seconds=0;
        objectiveStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds<=5)
        {
            seconds += Time.deltaTime;
            Debug.Log(seconds);
        }


        if ((seconds >= 5) && (objectiveStep == 0))
        {
            objectiveUI.SetActive(true);
            objectiveStep = 1;
            Debug.Log(objectiveStep);
        }


    }
    private void OnTriggerEnter(Collider collision)
    {
        var objectiveCollider = collision.gameObject.GetComponent<ObjectiveCollision>();
        if ((collision.gameObject.tag == "Objective")&&(objectiveStep==objectiveCollider.collisionStep))  
        {
            objectiveStep+=1;
            objectiveTextUI.text = objectiveCollider.objectiveText;
            Destroy(objectiveCollider.gameObject);
            Debug.Log(objectiveStep);
        }
    }

}
