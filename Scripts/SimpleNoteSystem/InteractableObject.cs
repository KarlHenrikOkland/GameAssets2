using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    // Amount of interaction cycle states.
    [Range(1, 3)]
    public int interactStates;

    // The current interaction cycle.
    [HideInInspector]
    public int interactionCycle;

    // References for events and sounds for each action cycle.
    public UnityEvent interactAction1;
    public AudioClip interactAction1sound;
    public UnityEvent interactAction2;
    public AudioClip interactAction2sound;
    public UnityEvent interactAction3;
    public AudioClip interactAction3sound;

    private void Start()
    {
        interactionCycle = 1;
    }
}


