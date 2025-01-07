using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public Transform spout;
    public GameObject waterPrefab;
    public float pourThreshold = 45f;
    public float spawnRate = 0.1f;
    public float waterAmountPerDrop = 10f;
    public float waterLifetime = 2f;

    private float nextSpawnTime = 0f;
    private bool isPouring = false;

    void Update()
    {
        Vector3 spoutDirection = spout.forward;
        float angle = Vector3.Angle(spoutDirection, Vector3.down);

        if (angle < pourThreshold)
        {
            StartPouring();
        }
        else
        {
            StopPouring();
        }

        if (isPouring && Time.time >= nextSpawnTime)
        {
            SpawnWater();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void StartPouring()
    {
        isPouring = true;
    }

    void StopPouring()
    {
        isPouring = false;
    }

    void SpawnWater()
    {
        // Spawn water object (if needed for visuals)
        GameObject water = Instantiate(waterPrefab, spout.position, Quaternion.identity);
        Rigidbody rb = water.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = spout.forward * 2f;
        }
        Destroy(water, waterLifetime);

        // Check if the watering can is over a plant
        RaycastHit hit;
        if (Physics.Raycast(spout.position, spout.forward, out hit, 2f)) // Adjust range as needed
        {
            Plant plant = hit.collider.GetComponent<Plant>();
            if (plant != null)
            {
                plant.WaterPlant(1f); // Water the plant (amount can vary)
            }
        }
    }

    
}
