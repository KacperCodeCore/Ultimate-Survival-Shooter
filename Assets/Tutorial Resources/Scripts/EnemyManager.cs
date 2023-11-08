using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        //spawnPoints = new Transform[spawnPoints.Length+1];
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) spawnPoints[i] = transform.GetChild(i);

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        if (spawnPoints.Length > 0) InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }


    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.iHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}
