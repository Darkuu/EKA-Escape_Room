using UnityEngine;
using UnityEngine.Events;

public class LightButton : MonoBehaviour
{
    public GameObject button;           // Reference to the button GameObject
    public UnityEvent onPress;          // Event triggered when the button is pressed
    public UnityEvent onRelease;        // Event triggered when the button is released
    public GameObject[] lights;         // Array of light GameObjects

    private GameObject presser;         // Object currently pressing the button
    private bool isPressed;             // Tracks whether the button is pressed

    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Click!");
        if (!isPressed && other.gameObject.layer == LayerMask.NameToLayer("Hands"))

        {
            presser = other.gameObject; // Record the pressing object
            onPress.Invoke();           // Trigger the press event
            ToggleLights();             // Toggle the lights
            isPressed = true;           // Mark button as pressed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && other.gameObject.layer == LayerMask.NameToLayer("Hands"))

        {
            onRelease.Invoke();         // Trigger the release event
            isPressed = false;          // Reset button press state
        }
    }

    public void ToggleLights()
    {
        // Toggle the state of each light
        foreach (GameObject light in lights)
        {
            if (light != null)
            {
                light.SetActive(!light.activeSelf); // Switch between on/off
            }
        }
    }
    
}