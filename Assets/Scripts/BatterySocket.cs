using UnityEngine;

public class BatterySocket : MonoBehaviour
{
    private bool isBatteryInPlace = false;
    private Battery currentBattery;
    private PlantSocket plantSocket;

    public Transform snapPoint;
    public float chargeCooldown = 2f;
    private float lastChargeTime = 0f;

    private void Start()
    {
        plantSocket = FindObjectOfType<PlantSocket>();
        if (plantSocket == null)
        {
            Debug.LogError("PlantSocket not found in the scene!");
            return;
        }

        // Listen for plant watering in the socket
        plantSocket.OnPlantWateredInSocket += HandlePlantWateredInSocket;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            Battery battery = other.GetComponent<Battery>();

            if (battery != null && !isBatteryInPlace)
            {
                currentBattery = battery;
                isBatteryInPlace = true;

                SnapBatteryIntoPlace(battery);
                Debug.Log("Battery snapped into socket.");

                // Check if plant is already watered
                if (plantSocket != null && IsPlantWatered() && Time.time - lastChargeTime >= chargeCooldown)
                {
                    ChargeBattery();
                    lastChargeTime = Time.time;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            isBatteryInPlace = false;
            currentBattery = null;
            Debug.Log("Battery removed from socket.");
        }
    }

    private void SnapBatteryIntoPlace(Battery battery)
    {
        if (snapPoint != null)
        {
            battery.transform.position = snapPoint.position;
            battery.transform.rotation = snapPoint.rotation;
        }
    }

    private void ChargeBattery()
    {
        if (currentBattery != null)
        {
            currentBattery.Charge();
            Debug.Log("Battery successfully charged!");
        }
    }

    private bool IsPlantWatered()
    {
        return plantSocket != null && plantSocket.currentPlant != null && plantSocket.currentPlant.HasBeenWatered();
    }

    private void HandlePlantWateredInSocket()
    {
        if (isBatteryInPlace && Time.time - lastChargeTime >= chargeCooldown)
        {
            ChargeBattery();
            lastChargeTime = Time.time;
            Debug.Log("Battery charged after plant was watered!");
        }
    }
}
