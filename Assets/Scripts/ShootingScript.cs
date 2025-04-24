using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    private float f_LastFiredTime = 0f;

    [SerializeField]
    private float f_FireDelay = 1f;
    [SerializeField]
    private float f_BulletOffset = 2f;

    void Start()
    {
        // Do some math to perfectly spawn bullets in front of us
        f_BulletOffset = GetComponent<Renderer>().bounds.size.y / 2 // Half of our size
            + bullet.GetComponent<Renderer>().bounds.size.y / 2; // Plus half of the bullet size
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            float CurrentTime = Time.time;

            // Have a delay so we don't shoot too many bullets
            if (CurrentTime - f_LastFiredTime > f_FireDelay)
            {
                // Fires Bullet
                Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + f_BulletOffset);

                Instantiate(bullet, spawnPosition, transform.rotation);
                // Resets Current Time so you cannot Fire Again
                f_LastFiredTime = CurrentTime;
            }

            //print("Shoot!");
        }
    }

    /// <summary>
    /// SampleMethod is a sample of how to use abstraction by
    /// specification. It converts a provided integer to a float.
    /// </summary>
    /// <param name="number">any integer</param>
    /// <returns>the number parameter as a float</returns>
    public float SampleMethod(int number) {
        return number;
    }

}
