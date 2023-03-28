using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;
    public AudioSource source;
    public AudioClip footstepLeft;
    public AudioClip footstepRight;
    private float stepRate;
    private bool leftFoot;

    private void Start()
    {
        leftFoot = true;
    }

    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
        if((velocity.y!=0) || (velocity.x!=0))
            {
            stepRate += 1;
            }

        if (stepRate == 30)
            {
            if (leftFoot == true)
               {
                source.clip = footstepLeft;
                source.Play();
                stepRate = 0;
                leftFoot = false;
               }
            else
               {
                source.clip = footstepRight;
                source.Play();
                stepRate = 0;
                leftFoot = true;
               }
           }


    }
}
