using UnityEngine;
using System; // Add this to use the Action delegate

public class PlantSocket : MonoBehaviour
{
    public Plant currentPlant { get; private set; }
    private bool isPlantInPlace = false;

    public Action OnPlantWateredInSocket; // Notify when the plant in the socket is watered

    void OnTriggerEnter(Collider other)
    {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null && !isPlantInPlace)
        {
            currentPlant = plant;
            isPlantInPlace = true;

            currentPlant.SetInSocket(true);
            currentPlant.OnPlantWatered += HandlePlantWatered; // Subscribe to the watering event
            Debug.Log("Plant placed in the socket.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Plant plant = other.GetComponent<Plant>();
        if (plant != null && isPlantInPlace)
        {
            isPlantInPlace = false;
            currentPlant.SetInSocket(false);
            currentPlant.OnPlantWatered -= HandlePlantWatered; // Unsubscribe from the event
            currentPlant = null;
            Debug.Log("Plant removed from the socket.");
        }
    }

    private void HandlePlantWatered()
    {
        Debug.Log("Plant watered while in the socket.");
        OnPlantWateredInSocket?.Invoke(); // Notify listeners (e.g., BatterySocket)
    }
}