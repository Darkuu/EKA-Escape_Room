using UnityEngine;
using System;

public class Plant : MonoBehaviour
{
    private bool hasBeenWatered = false;
    private float currentWaterLevel = 0f;
    public float requiredWaterAmount = 5f;

    public Action OnPlantWatered; // Event triggered when the plant is watered

    public void WaterPlant(float waterAmount)
    {
        if (hasBeenWatered) return;

        currentWaterLevel += waterAmount;
        Debug.Log($"Plant watered! Current water level: {currentWaterLevel}/{requiredWaterAmount}");

        if (currentWaterLevel >= requiredWaterAmount)
        {
            hasBeenWatered = true;
            Debug.Log("Plant has been fully watered!");

            // Trigger the event
            OnPlantWatered?.Invoke();
        }
    }

    public bool HasBeenWatered()
    {
        return hasBeenWatered;
    }

    public void SetInSocket(bool isInSocket)
    {
        // Logic for when the plant is placed in or removed from the socket
        Debug.Log($"Plant is {(isInSocket ? "in" : "out of")} the socket.");
    }
}