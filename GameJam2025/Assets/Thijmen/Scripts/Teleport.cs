using UnityEngine;

public class TeleportByTag : MonoBehaviour
{
    public string targetTag = "TeleportTarget";

    public Vector2 teleportOffset = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject target = GameObject.FindWithTag(targetTag);

            if (target != null)
            {
                collision.transform.position = (Vector2)target.transform.position + teleportOffset;
                Debug.Log($"Player teleported to {target.name} at position {target.transform.position}");
            }
            else
            {
                Debug.LogWarning($"Geen doel met de tag '{targetTag}' gevonden!");
            }
        }
    }
}

//het object waar je dit op gebruikt moet rigidbody 2d (zxy axis locked) en een boxcollider 2d met 'isTrigger' aan
//het object waar het heen teleport moet de tag 'TeleportTarget' hebben