using UnityEngine;

public class BirdsEyeCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 10, 0); 
    public float followSpeed = 5f; 

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            
            transform.rotation = Quaternion.Euler(90, 0, 0); 
        }
    }
}