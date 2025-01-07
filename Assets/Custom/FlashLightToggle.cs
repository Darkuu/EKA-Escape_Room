using System.Collections; 
using UnityEngine;

public class ToggleFlashLight : MonoBehaviour
{
    private bool isBatteryInserted = false;
    public GameObject flashlightLight;
    public Transform batterySocketArea; // The area that acts as the "socket" for detecting batteries.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery")) // Ensure only battery objects trigger this
        {
            Battery battery = other.GetComponent<Battery>();

            if (battery != null && battery.currentCharge >= 100f && !isBatteryInserted) // Only activate for fully charged batteries
            {
                flashlightLight.SetActive(true);
                isBatteryInserted = true;
                Debug.Log("Battery successfully inserted and fully charged.");

                // Start coroutine to destroy the battery after 2 seconds
                StartCoroutine(DestroyBatteryAfterTime(other.gameObject, 2f));
            }
            else
            {
                Debug.Log("Inserted battery is not fully charged.");
            }
        }
    }

    private IEnumerator DestroyBatteryAfterTime(GameObject batteryObject, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the battery
        if (batteryObject != null)
        {
            Destroy(batteryObject);
            Debug.Log("Battery destroyed after 2 seconds.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery") && isBatteryInserted)
        {
            Debug.Log("Battery removed, but flashlight remains on.");
            isBatteryInserted = false;
            // Note: flashlightLight remains ON, so we don't turn it off here.
        }
    }
}