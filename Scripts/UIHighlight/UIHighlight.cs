using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighlight : MonoBehaviour
{
    public Camera characterCamera;

    public GameObject pressEpanel;

    public SimpleNoteSystem noteSystem;

    GameObject obj;
    Renderer objRenderer;
    public Material newMtl;
    Material oldMtl;

    // Update is called once per frame
    void Update()
    {
        // If the player is reading.
        if (noteSystem.isReading != true)
        {
            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);

            if (Physics.Raycast(ray, out RaycastHit oorInteractible, 4f))
            {
                if ((oorInteractible.transform.gameObject.layer == 6) || (oorInteractible.transform.gameObject.layer == 7))
                {
                    // If the object is on layer 6.
                    if (oorInteractible.transform.gameObject.layer == 6)
                    {
                        if (obj != oorInteractible.collider.gameObject)//If we're not pointing at the previous target
                        {

                            if (obj != null)//If previous target is set, reset its material

                            {
                                objRenderer.material = oldMtl;
                            }

                            obj = oorInteractible.collider.gameObject;//Store reference of target to a variable
                            objRenderer = obj.GetComponent<Renderer>();//Get targets Renderer
                            oldMtl = objRenderer.material;//Store targets current material
                            objRenderer.material = newMtl;//Set target to new material
                        }
                    }

                    // If the object is on layer 6.
                    if (oorInteractible.transform.gameObject.layer == 7)
                    {
                        if (obj != oorInteractible.collider.gameObject) //If we're not pointing at the previous target

                        {
                            obj = oorInteractible.collider.gameObject;//Store reference of target to a variable

                        }
                    }
                    var hitDistance = oorInteractible.distance;

                    // If distance is less than 2 (this equals within "if (Physics.Raycast(ray, out RaycastHit oorInteractible, 2f))" range.
                    if (hitDistance <= 2)
                    {
                        if ((oorInteractible.transform.gameObject.layer == 6) || (oorInteractible.transform.gameObject.layer == 7))
                        {
                            pressEpanel.SetActive(true);
                        }

                    }
                }
                // If layer hit is below 6 or above 7 turn off highlight. (else doesn't work following two different if statements)
                if ((oorInteractible.transform.gameObject.layer <= 5) || (oorInteractible.transform.gameObject.layer >= 8))
                {
                    if (obj != null)
                    {
                        objRenderer.material = oldMtl;//Reset targets material
                        obj = null;//Clear reference
                        pressEpanel.SetActive(false);
                    }
                }

            }

            // If the ray hits nothing turn off highlight.
            else
            if (obj != null)
            {
                objRenderer.material = oldMtl;//Reset targets material
                obj = null;//Clear reference
                pressEpanel.SetActive(false);
            }
        }

        // If the player is not reading turn off highlight.
        else
            if (obj != null)
        {
            objRenderer.material = oldMtl;//Reset targets material
            obj = null;//Clear reference
            pressEpanel.SetActive(false);
        }

    }
}
