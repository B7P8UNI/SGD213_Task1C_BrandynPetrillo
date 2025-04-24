using UnityEngine;
using System.Collections;
using System;

public class EntityMoveForward : MonoBehaviour 
{
    [SerializeField]
    private float f_Acceleration = 75f;
    [SerializeField]
    private float f_InitialVelocity = 2f;

    private Rigidbody2D rb_Entity;
    // is used to determine if Entity is Enemy or Bullet.
    [SerializeField]
    private bool bool_EntityType = true;

    // Use this for initialization
    void Start()
    {
        // Gets the Entities RigidBody2D
        rb_Entity = GetComponent<Rigidbody2D>();
        // Checks if the Entity is an Object (True) or a Bullet (False)
        if (bool_EntityType == true)
        {
            rb_Entity.velocity = Vector2.down * f_InitialVelocity;
        }
        else
        {
            rb_Entity.velocity = Vector2.up * f_InitialVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Moves Entity Down the screen at faster speeds (upto the Entities f_Acceleration) if True, and Up if False.
        if (bool_EntityType == true)
        {
            Vector2 SpeedIncrease = Vector2.down * f_Acceleration * Time.deltaTime;
            rb_Entity.AddForce(SpeedIncrease);
        }
        else
        {
            Vector2 SpeedIncrease = Vector2.up * f_Acceleration * Time.deltaTime;
            rb_Entity.AddForce(SpeedIncrease);
        }
        
    }
}
