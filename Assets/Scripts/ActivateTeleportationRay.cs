using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;

    // InputActionProperty for activating teleportation
    public InputActionProperty leftActivate;

    void Update()
    {
        // Read the value as float and set the teleportation ray active
        float activateValue = leftActivate.action.ReadValue<float>();
        leftTeleportation.SetActive(activateValue > 0.5f); // Threshold for "pressed"
    }
}