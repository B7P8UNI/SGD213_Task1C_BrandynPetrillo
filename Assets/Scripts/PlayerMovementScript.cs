using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
            // SerializeField exposes this value to the Editor, but not to other Scripts!
            // It is "pseudo public"
            // HorizontalPlayerAcceleration indicates how fast we accelerate Horizontally
            [SerializeField]
            private float f_LRMovement = 5000f;

            private Rigidbody2D rb_Player;

    // Use this for initialization
    void Start() 
    {
        // Get OurRigidbodyComponent once at the start of the game and store a reference to it
        // This means that we don't need to call GetComponent more than once! This makes our game faster. (GetComponent is SLOW)
        rb_Player = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update() 
    {
        // Uses the Left Arrow or "A" key to move Left and the Right Arrow or "D" key to move Right.
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f) 
        {
            Vector2 ForceToAdd=Vector2.right*HorizontalInput*f_LRMovement*Time.deltaTime;
            rb_Player.AddForce(ForceToAdd);
            //print(HorizontalInput);
        } 
    } 
}
