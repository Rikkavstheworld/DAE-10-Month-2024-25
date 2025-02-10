using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private bool isGrounded;

    public GameObject spawnPoint; // Public reference to the spawn point

    void Start()
    {
        // Optionally, you could set the spawn point location at the start
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    void Update()
    {
        // Movement input
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        moveDirection.Normalize();

        // Apply horizontal movement
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Check if the player is grounded
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jump logic using Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ySpeed = jumpSpeed;
        }

        // Apply gravity
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Apply vertical movement
        Vector3 verticalMovement = new Vector3(0, ySpeed, 0);
        transform.Translate(verticalMovement * Time.deltaTime, Space.World);

        // Prevent falling indefinitely when grounded
        if (isGrounded && ySpeed < 0)
        {
            ySpeed = 0;
        }

        // Rotate towards movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    // Collision detection for objects with the tag "ob"
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ob"))
        {
            Debug.Log("detected");
            // Move the player to the spawn point position upon collision
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
                Debug.Log("Player moved to spawn point after collision with object tagged 'ob'.");
            }
            else
            {
                Debug.LogWarning("Spawn point not assigned!");
            }
        }
    }
}
