using UnityEngine;
using UnityEngine.UI;

public class ResetHeight : MonoBehaviour
{
    // References for VR Player and Points
    public Transform vrPlayer; // The player object to modify
    public Transform respawnPoint; // The point to respawn the player

    // UI Buttons
    public Button respawnButton; // Button to respawn player
    public Button increaseHeightButton; // Button to increase player height
    public Button decreaseHeightButton; // Button to decrease player height

    // Height adjustment step (adjusted to a smaller number)
    public float heightAdjustmentStep = 0.02f; // Amount to increase or decrease height (smaller value for smoother transition)

    // Minimum and Maximum height for the player and collider size
    public float minHeight = 1.0f; // Minimum allowed height
    public float maxHeight = 2.5f; // Maximum allowed height

    // Player collider reference (BoxCollider)
    public BoxCollider playerCollider; // Collider to adjust along with height

    private void Start()
    {
        if (respawnButton != null)
        {
            respawnButton.onClick.AddListener(RespawnPlayer);
        }

        if (increaseHeightButton != null)
        {
            increaseHeightButton.onClick.AddListener(IncreasePlayerHeight);
        }

        if (decreaseHeightButton != null)
        {
            decreaseHeightButton.onClick.AddListener(DecreasePlayerHeight);
        }
    }
    
    /// <summary>
    /// Respawns the player at the designated respawn point.
    /// </summary>
    public void RespawnPlayer()
    {
        if (vrPlayer != null && respawnPoint != null)
        {
            vrPlayer.position = respawnPoint.position;
            Debug.Log($"Player respawned at {respawnPoint.position}");
        }
        else
        {
            Debug.LogWarning("Respawn failed: vrPlayer or respawnPoint is not assigned.");
        }
    }

    /// <summary>
    /// Increases the player's height by a predefined step, moving the collider down.
    /// </summary>
    public void IncreasePlayerHeight()
    {
        if (vrPlayer != null && playerCollider != null)
        {
            // Check if the current height + the adjustment step does not exceed maxHeight
            float newHeight = playerCollider.size.y + heightAdjustmentStep;
            
            if (newHeight <= maxHeight)
            {
                // Move the collider down to increase the apparent height
                playerCollider.center = new Vector3(playerCollider.center.x, playerCollider.center.y - heightAdjustmentStep, playerCollider.center.z);
                playerCollider.size = new Vector3(playerCollider.size.x, newHeight, playerCollider.size.z);

                Debug.Log($"Player height increased by {heightAdjustmentStep}. New collider height: {playerCollider.size.y}");
            }
            else
            {
                Debug.LogWarning($"Cannot increase height. Maximum height of {maxHeight} reached.");
            }
        }
        else
        {
            Debug.LogWarning("Increase Height failed: vrPlayer or playerCollider is not assigned.");
        }
    }

    /// <summary>
    /// Decreases the player's height by a predefined step, moving the collider up.
    /// </summary>
    public void DecreasePlayerHeight()
    {
        if (vrPlayer != null && playerCollider != null)
        {
            // Check if decreasing the height would drop below the minimum height
            if (playerCollider.size.y - heightAdjustmentStep >= minHeight)
            {
                // Move the collider up to decrease the apparent height
                playerCollider.center = new Vector3(playerCollider.center.x, playerCollider.center.y + heightAdjustmentStep, playerCollider.center.z);
                playerCollider.size = new Vector3(playerCollider.size.x, playerCollider.size.y - heightAdjustmentStep, playerCollider.size.z);

                Debug.Log($"Player height decreased by {heightAdjustmentStep}. New collider height: {playerCollider.size.y}");
            }
            else
            {
                Debug.LogWarning($"Cannot decrease height. Minimum height of {minHeight} reached.");
            }
        }
        else
        {
            Debug.LogWarning("Decrease Height failed: vrPlayer or playerCollider is not assigned.");
        }
    }

    /// <summary>
    /// Resets the player's collider position to default height.
    /// </summary>
    private void ResetColliderPosition()
    {
        // Reset the collider center to default height
        playerCollider.center = new Vector3(playerCollider.center.x, 0f, playerCollider.center.z);
        playerCollider.size = new Vector3(playerCollider.size.x, 1.8f, playerCollider.size.z); // Example: Default height of 1.8 units
    }
}
