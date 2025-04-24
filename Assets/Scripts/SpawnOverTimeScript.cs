using UnityEngine;
using System.Collections;

public class SpawnOverTimeScript : MonoBehaviour
{
    // Objects to spawn
    [SerializeField]
    private GameObject SpawnEnemyObject;
    // Delay between spawns
    [SerializeField]
    private float SpawnDelay = 2f;
    private Renderer ourRenderer;

    // Use this for initialization
    void Start()
    {
        ourRenderer = GetComponent<Renderer>();

        // Stop our Spawner from being visible!
        ourRenderer.enabled = false;

        // Call the given function after spawnDelay seconds, 
        // and then repeatedly call it after spawnDelay seconds.
        InvokeRepeating("Spawn", SpawnDelay, SpawnDelay);
    }

    void Spawn()
    {
        // Gets the Location of the Render Space in the X axis.
        float x1 = transform.position.x - ourRenderer.bounds.size.x / 2;
        float x2 = transform.position.x + ourRenderer.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the object at the 'spawnPoint' position
        Instantiate(SpawnEnemyObject, spawnPoint, Quaternion.identity);
    }
}
