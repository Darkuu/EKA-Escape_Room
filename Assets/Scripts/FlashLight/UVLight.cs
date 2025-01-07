using System.Collections.Generic;
using UnityEngine;

public class UVLight : MonoBehaviour
{
    public List<GameObject> objectsToReveal; // List of objects to reveal

    private Dictionary<GameObject, Renderer> objectRenderers = new Dictionary<GameObject, Renderer>();
    private Dictionary<GameObject, UVObjectMaterial> objectMaterials = new Dictionary<GameObject, UVObjectMaterial>();

    private void Start()
    {
        // Cache the renderers and UVObjectMaterial of all objects
        foreach (GameObject obj in objectsToReveal)
        {
            if (obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                objectRenderers[obj] = renderer;

                // Get the UVObjectMaterial component attached to the object
                if (obj.TryGetComponent<UVObjectMaterial>(out UVObjectMaterial uvMaterial))
                {
                    objectMaterials[obj] = uvMaterial;

                    // Set the object to be initially invisible
                    renderer.material = uvMaterial.invisibleMaterial;
                }
                else
                {
                    Debug.LogWarning($"{obj.name} does not have a UVObjectMaterial component.");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (objectsToReveal.Contains(other.gameObject))
        {
            if (objectMaterials.TryGetValue(other.gameObject, out UVObjectMaterial uvMaterial))
            {
                if (objectRenderers.TryGetValue(other.gameObject, out Renderer renderer))
                {
                    // Make the object visible using its specified material
                    renderer.material = uvMaterial.visibleMaterial;
                    Debug.Log($"{other.gameObject.name} revealed under light!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsToReveal.Contains(other.gameObject))
        {
            if (objectMaterials.TryGetValue(other.gameObject, out UVObjectMaterial uvMaterial))
            {
                if (objectRenderers.TryGetValue(other.gameObject, out Renderer renderer))
                {
                    // Make the object invisible using its specified material
                    renderer.material = uvMaterial.invisibleMaterial;
                    Debug.Log($"{other.gameObject.name} hidden as it left the light!");
                }
            }
        }
    }
}
