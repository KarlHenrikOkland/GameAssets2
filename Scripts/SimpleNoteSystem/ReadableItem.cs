using UnityEngine;


/// Attach this class to make object readable.


public class ReadableItem : MonoBehaviour

{

    // Disables game object on read and enables it on exit.
    public bool DisableOnPickup;



    // Sprite that
    public Sprite newSpriteRef;


    // Slider to choose if the object is Note, Book or Other.
    [Range(1, 3)]
    public int Note1Book2Other3;

    // Plays photoSounds sound instead of otherSounds.
    public bool isPhoto;

    // Activates adaptable textobx for Other (3).
    public bool otherHasTextBox;

    //Sounds that play if you choose Other (3).
    public AudioClip [] otherSounds;
    //public AudioSource otherAudioSource;

  

    [TextArea]
    public string noteText = "noteText";


    


   
    /// Method called on initialization.

    private void Awake()
    {
     
       
    }
}

