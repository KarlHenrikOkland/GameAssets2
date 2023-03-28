using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelection : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string HighlightableTag = "Highlightable";
    
    private Transform _selection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(_selection != null)
        // {
        //     var selectionRenderer = _selection.GetComponent<Renderer>();
        //     selectionRenderer.material = defaultMaterial;
        //     _selection = null;
        // }
        // //Gives off a ray from camera to wherever the camera is pointing
        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // if(Physics.Raycast(ray, out hit))
        // {
        //     var selection = hit.transform;
        //     if(selection.CompareTag(HighlightableTag))
        //     {
        //         var selectionRenderer = selection.GetComponent<Renderer>();
        //         if(selectionRenderer != null)
        //         {
        //             selectionRenderer.material = highlightMaterial;
        //             Debug.Log("Material Applied");
        //         }
        //         _selection = selection;
        //     }
        // }
    }
}
