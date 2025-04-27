using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// PlayerMovementScript handles all of the movement specifc state and behaviour for the player.
/// Update: I have Modified the Functionality of this to have the Functionality originally in the MoveConstantly and EnemyMovement Scripts,
/// thus effectively turning it into an ObjectMovement Script. the reason i have not modified the name is in case if i do it wrong and break the script.
/// Was going to put the Rotate Script Function in as well however the Game Engine was not happy with it.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    // horizontalPlayerSpeed indicates how fast we accelerate Horizontally
    [SerializeField]
    private float horizontalEntityAcceleration = 5000f;

    // local reference
    private Rigidbody2D ourRigidbody;

    // If IsShip is True Ignore the next 3 Variables and the HorizontalEntityAcceleration Variable if False
    [SerializeField]
    private bool IsShip = true;

    // the Amount up down momentum will Increase by
    [SerializeField]
    private float accelerationUpDown = 100f;

    // the Initial Speed of the Up Down Momentum
    [SerializeField]
    private float initialVelocityUpDown = 10f;

    [SerializeField]
    // our direction to move in
    private Vector2 directionUpDown = new Vector2(0, 1);


    /// <summary>
    /// Direction provides access to the direction variable used to direct the movement of our object.
    /// It is expected that when setting the direction, the provided Vector2 is a unit vector. If not,
    /// it will be automatically normalised.
    /// </summary>
    public Vector2 Direction
    {
        get
        {
            return directionUpDown;
        }
        set
        {
            if (value.magnitude == 1)
            {
                directionUpDown = value;
            }
            else
            {
                directionUpDown = value.normalized;
            }
        }
    }


    void Start()
    {
        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();

        // if this is NOT a Ship
        if (IsShip == false)
        {
            // Applies an Up down Force that is Multiplied by its up Down Direction.
            ourRigidbody.velocity = directionUpDown * initialVelocityUpDown;
        }
        else
        {
            // Disables the Update Function
            enabled = false;
        }
    }

    void Update()
    {
            // calculate our force to add, based on our provided direction, acceleration and delta time
            Vector2 forceToAddUpDown = directionUpDown * accelerationUpDown * Time.deltaTime;
            // add our forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAddUpDown);
    }

    /// <summary>
    /// MovePlayer takes a float representing the raw horizontal input, and applies a lateral force
    /// to ourRigidbody, based on the provided horizontal input, the horizontalPlayerAcceleration
    /// and the delta time.
    /// </summary>
    /// <param name="horizontalInput">Raw horizontal input value. Expected to be between -1 and 1. 
    /// Number outside this range increase movement speed. A value of 0 is ignored.</param>
    public void MovePlayer(float horizontalInput) {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (horizontalInput != 0) {
            //calculate our force to add
            Vector2 forceToAdd = Vector2.right * horizontalInput * horizontalEntityAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }

    public void MovePlayer(Vector2 direction)
    {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (direction.magnitude != 0)
        {
            //calculate our force to add
            Vector2 forceToAdd = direction * horizontalEntityAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }
}
