using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject objectToTeleport;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportObject();
        }
    }

    private void TeleportObject()
    {
        if (objectToTeleport != null && waypoints.Length > 0)
        {
            objectToTeleport.transform.position = waypoints[currentWaypointIndex].position;
            Debug.Log(objectToTeleport.name + " geteleporteerd naar " + waypoints[currentWaypointIndex].position);

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            Debug.LogWarning("Teleport mislukt! Zorg ervoor dat objectToTeleport en waypoints correct zijn ingesteld.");
        }
    }
}
