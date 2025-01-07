using UnityEngine;

public class Water : MonoBehaviour
{
    public float waterAmount = 1f; // Amount of water provided by this droplet

    void OnCollisionEnter(Collision collision)
    {
        Plant plant = collision.collider.GetComponent<Plant>();
        if (plant != null)
        {
            // Water the plant on collision
            plant.WaterPlant(waterAmount);

            // Destroy the water object
            Destroy(gameObject);
        }
    }
}