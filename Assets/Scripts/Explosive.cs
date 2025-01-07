using UnityEngine;

public class Explosive : MonoBehaviour
{
    public AudioSource fuseSound;       // AudioSource for the fuse sound
    public AudioSource explosionSound;  // AudioSource for the explosion sound
    public float fuseTime = 5f;         // Time in seconds before explosion
    public float firstTeleportDelay = 0.1f; // Time before the first teleportation
    public float secondTeleportDelay = 0.1f; // Time before the second teleportation

    public Transform firstTeleportLocation; // First teleport location
    public Transform secondTeleportLocation; // Second teleport location
    private bool isExploding = false;   // To track if the explosive is triggered

    private void OnEnable()
    {
        // Play the fuse sound
        if (fuseSound != null)
        {
            fuseSound.Play();
        }

        // Start the fuse timer
        Invoke(nameof(TriggerExplosion), fuseTime);
    }

    private void TriggerExplosion()
    {
        if (isExploding) return;

        isExploding = true;

        // Play explosion sound
        if (explosionSound != null)
        {
            explosionSound.Play();
        }

        // Teleport the player at two intervals to different locations
        StartCoroutine(TeleportPlayerAtIntervals());
    }

    private System.Collections.IEnumerator TeleportPlayerAtIntervals()
    {
        // Wait for the first teleport interval
        yield return new WaitForSeconds(firstTeleportDelay);
        TeleportPlayer(firstTeleportLocation);
        yield return new WaitForSeconds(secondTeleportDelay);
        TeleportPlayer(secondTeleportLocation);
        Destroy(gameObject);
    }

    private void TeleportPlayer(Transform teleportLocation)
    {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportLocation.position; 
    }
}
