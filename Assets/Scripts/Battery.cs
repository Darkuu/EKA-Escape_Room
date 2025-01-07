using UnityEngine;

public class Battery : MonoBehaviour
{
    public float maxCharge = 100f;        // Max charge value
    public float currentCharge = 0f;     // Current charge value
    public Material redMaterial;         // The initial red material
    public Material greenMaterial;       // The green material to switch to
    public int materialIndex = 0;        // The index of the material to change (0 for the first material)

    private Renderer batteryRenderer;    // Renderer of the battery

    private void Start()
    {
        // Get the Renderer component
        batteryRenderer = GetComponent<Renderer>();
        if (batteryRenderer == null)
        {
            Debug.LogError("Renderer not found on the battery object!");
        }
    }

    public void Charge()
    {
        // Clamp the value between 0 and the maximum charge
        currentCharge = Mathf.Clamp(maxCharge, 0, maxCharge);
        Debug.Log($"Battery charged to {currentCharge}!");

        // Start the process to change the material
        Invoke(nameof(ChangeToGreen), 3f); // Wait 3 seconds before changing the material
    }

    private void ChangeToGreen()
    {
        if (batteryRenderer == null || greenMaterial == null)
        {
            Debug.LogError("Cannot change material: Renderer or greenMaterial is missing.");
            return;
        }

        // Get the current materials
        Material[] materials = batteryRenderer.materials;

        // Replace the specified material with the green material
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            materials[materialIndex] = greenMaterial;
            batteryRenderer.materials = materials; // Apply the updated materials array
            Debug.Log("Battery material changed to green!");
        }
        else
        {
            Debug.LogError("Invalid material index specified!");
        }
    }
}