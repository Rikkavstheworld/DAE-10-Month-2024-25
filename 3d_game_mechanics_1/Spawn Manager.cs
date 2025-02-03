using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPoint; // Assign the spawn point in the Inspector

    void Start()
    {
        if (spawnPoint == null)
        {
            Debug.LogWarning("Spawn point not set! Please assign a spawn point in the Inspector.");
        }
    }

    void Update()
    {
        // Check for "R" key press to respawn the player
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn(gameObject); // Respawn the player
        }
    }

    public void Respawn(GameObject player)
    {
        if (spawnPoint != null)
        {
            // Move the player to the spawn point's posiion and rotation
            //player.transform.position = spawnPoint.position;
            //player.transform.rotation = spawnPoint.rotation;

            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }

            Debug.Log("Player respawned.");
        }
        else
        {
            Debug.LogError("Spawn point is not set! Respawn failed.");
        }
    }
}