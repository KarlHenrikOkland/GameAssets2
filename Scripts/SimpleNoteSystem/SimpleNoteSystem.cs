using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;


public class SimpleNoteSystem : MonoBehaviour
{
    // Reference to the text linked from the
    public Text noteText;
    public Text noteBookText;
    public Text noteOtherText;

    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;

    // Reference to the currently picked item.
    private ReadableItem pickedItem;

    // Whether a an effect has been played this cycle
    private bool hasPlayed;

    // Whether player is reading (ref for UIHighligh).
    public bool isReading;

    // Reference to parents of the different UI image+text.
    public GameObject noteUI;
    public GameObject noteBookUI;
    public GameObject noteOtherUI;
    public GameObject canvasNoteOtherPanel;
    public GameObject pressToExitUI;

    // Audio arrays to put sounds for Note (1) and Book (2) and isPhoto=true.
    public AudioClip[] noteSounds;
    public AudioClip[] bookSounds;
    public AudioClip[] photoSounds;

    // Reference for the PostProcessingLayer.
    public PostProcessLayer v2_PostProcess;

    // Reference to the audio source and setting it to the component audio source of this gameobject.
    private AudioSource source;

    void Start()
    {
        // Get audio source of player.
        source = GetComponent<AudioSource>();
    }
    
    private void Update()
    {

        // Execute logic only on button pressed
        if (Input.GetKeyDown("e"))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
            }

            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);

                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out RaycastHit item, 2f))
                {
                    // Check if object is pickable
                    var pickable = item.transform.GetComponent<ReadableItem>();

                    // If object has PickableItem class
                    if (pickable)
                    {
                        // Pick it
                        PickItem(pickable);
                    }

                    // Check if object is interactible
                    var interactable = item.transform.GetComponent<InteractableObject>();

                    // If object has InteractibleAsset class
                    if (interactable)
                    {

                        // Ready the bool before the cycle begins for the cycle 2 and 3 checks.
                        hasPlayed = false;

                        // Check that the interaction cycle is 1.
                        if (interactable.interactionCycle == 1)
                        {
                            {
                                // Invoke the UnityEvent for cycle 1.
                                interactable.interactAction1.Invoke();

                                // Play the cycle 1 soundclip.
                                source.clip = interactable.interactAction1sound;
                                source.Play();

                                //Check if is more than 1 interaction states.
                                if (interactable.interactStates >= 1)
                                {
                                    // Set the interaction cycle to 2.
                                    interactable.interactionCycle = 2;
                                }

                            }

                            // State that an action has played this cycle.
                            hasPlayed = true;
                        }

                        // Check that no action has played this cycle, and that we're on the 2nd cycle.
                        if ((hasPlayed == false) && (interactable.interactionCycle == 2))
                        {
                            {
                                interactable.interactAction2.Invoke();

                                source.clip = interactable.interactAction2sound;
                                source.Play();

                                // Check whether there's 3 interaction states and increase the cycle count or reset it.
                                if (interactable.interactStates == 3)
                                {
                                    interactable.interactionCycle = 3;
                                }
                                else
                                {
                                    interactable.interactionCycle = 1;
                                }
                            }
                            hasPlayed = true;
                        }

                        if ((hasPlayed == false) && (interactable.interactionCycle == 3))
                        {
                            {
                                interactable.interactAction3.Invoke();

                                source.clip = interactable.interactAction3sound;
                                source.Play();

                                interactable.interactionCycle = 1;
                            }
                        }
                    }
                }
            }
        }

        // Create list of active post-process volumes. new is used as a declaration modifier.
        List<PostProcessVolume> volList = new List<PostProcessVolume>();

        // Get active volumes within the singleton active PostProcessManager.
        PostProcessManager.instance.GetActiveVolumes(v2_PostProcess, volList, true, true);

        // If the player is reading.
        if (isReading)
        {
            // For each active volume..
            foreach (PostProcessVolume vol in volList)
            {
                // Get their profile..
                PostProcessProfile ppp = vol.profile;
                if (ppp)
                {
                    DepthOfField dph;

                    //Try to get setting DepthOfField from the pp profile, and if true..
                    if (ppp.TryGetSettings<DepthOfField>(out dph))
                    {
                        // Activate DepthOfField and decrease it by 20 for each second until it reaches 0.1.
                        dph.active = true;
                        if (dph.focusDistance.value >= 0.1f)
                        {
                            dph.focusDistance.value -= 20*Time.deltaTime;
                        }
                    }
                }
            }
        }
    }


    // Method for picking up item.
    private void PickItem(ReadableItem item)
    {

        // Set the player to reading.
        isReading = true;

        // Press E to exit UI
        pressToExitUI.SetActive(true);

        //Reference script of the ReadableItem holding gameobject.
        ReadableItem note = item.transform.GetComponent<ReadableItem>();

        
        // If the object is set to Note (1):
        if (note.Note1Book2Other3 == (1))

        {
            // Set the connected noteText UI gameobject text component to be what's in the note noteText textbox.
            noteText.text = note.noteText;

            // Play sounds from the noteSounds array.
            source.clip = noteSounds[Random.Range(0, noteSounds.Length)];
            source.Play();

            // Activate the UI for Note (1).
            noteUI.SetActive(true);

        }

        // If the object is set to Book (2):
        if (note.Note1Book2Other3 == (2))
        {
            noteBookText.text = note.noteText;

            // Play sounds from the bookSounds array.
            source.clip = bookSounds[Random.Range(0, bookSounds.Length)];
            source.Play();

            // Activate the UI for Book (2).
            noteBookUI.SetActive(true);

        }

        // If the object is set to Other (3):
        if (note.Note1Book2Other3 == (3))

        {
            noteOtherText.text = note.noteText;

            // Play photoSounds if isPhoto is on, otherSounds if not.
            if (note.isPhoto == true)
            {
                
                source.clip = photoSounds[Random.Range(0, photoSounds.Length)];
                source.Play();
            }

            // Play sounds from the otherSounds array in the ReadableItem script.
            else
            {
                    source.clip = note.otherSounds[Random.Range(0, note.otherSounds.Length)];
                    source.Play();
            }

            // Check to if to only have a textbox and no picture.
            if (note.otherHasTextBox == true)
            {
                canvasNoteOtherPanel.SetActive(true); 
            }

            else
            {
                // Activate the UI for Other (3).
                noteOtherUI.SetActive(true);

                // Set this sprite as the new image.
                noteOtherUI.GetComponent<Image>().sprite = (note.newSpriteRef);
            }
          
        }

        // Check if to disable the note object when picked up.
        if (note.DisableOnPickup == true)

        {
            note.gameObject.SetActive(false);
        }

        // Assign reference
        pickedItem = item;

        // Disable the player.
        GameObject.Find("First person controller full").GetComponent<FirstPersonMovement>().enabled = false;
       
    }

    // Method for dropping item.
    private void DropItem(ReadableItem item)

    {
        List<PostProcessVolume> volList = new List<PostProcessVolume>();
        PostProcessManager.instance.GetActiveVolumes(v2_PostProcess, volList, true, true);

        foreach (PostProcessVolume vol in volList)
        {
            PostProcessProfile ppp = vol.profile;
            if (ppp)
            {
                // Deactivate and reset DepthOfField.
                DepthOfField dph;
                if (ppp.TryGetSettings<DepthOfField>(out dph))
                {
                    dph.active = false;
                    dph.focusDistance.value = 2.8f;
                }
            }
        }

        isReading =false;
        pressToExitUI.SetActive(false);
        ReadableItem note = item.transform.GetComponent<ReadableItem>();

        // Play the connected sounds again and deactivate UI elements.
        if (note.Note1Book2Other3 == (1))

        {
            noteText.text = note.noteText;

            source.clip = noteSounds[Random.Range(0, noteSounds.Length)];
            source.Play();

            noteUI.SetActive(false);
        }

        if (note.Note1Book2Other3 == (2))

        {
            noteBookText.text = note.noteText;

            source.clip = bookSounds[Random.Range(0, bookSounds.Length)];
            source.Play();

            noteBookUI.SetActive(false);
        }

        if (note.Note1Book2Other3 == (3))

        {
            // Play photoSounds if isPhoto is on, otherSounds if not.
            if (note.isPhoto == true)
            {
                noteOtherText.text = note.noteText;

                source.clip = photoSounds[Random.Range(0, photoSounds.Length)];
                source.Play();
            }

            else
            {
                source.clip = note.otherSounds[Random.Range(0, note.otherSounds.Length)];
                source.Play();
     
            }
            
                canvasNoteOtherPanel.SetActive(false);

            noteOtherUI.SetActive(false);
        }

        note.gameObject.SetActive(true);

        // Remove reference
        pickedItem = null;

        // Enable movement again.
        GameObject.Find("First person controller full").GetComponent<FirstPersonMovement>().enabled = true;
        
    }
}