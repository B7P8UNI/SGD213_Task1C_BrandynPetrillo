using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float f_MaximumSpinSpeed = 200;

    // Use this for initialization
    void Start()
    {
        // Rotates the Object at a Random Speed, from counter Clockwise to Clockwise depending on the "f_MaximumSpinSpeed"
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-f_MaximumSpinSpeed, f_MaximumSpinSpeed);
    }
}
