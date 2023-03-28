using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseController : MonoBehaviour
{
    public bool isPlaced;
    public Animator animator;

    public void PlaceFuse()
    {
        if(isPlaced)
        {
            isPlaced = true;
            animator.SetBool("isPlaced",isPlaced);

        }



    }

}
