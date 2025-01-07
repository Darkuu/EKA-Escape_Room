using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light[] lights;        // Array of lights to toggle
    public AudioSource soundEffect;
    public float TimeBeforeShutOff;// Sound effect to play when the lights turn off

    private bool areLightsOn = true;   // Start with lights on
    private bool lightsLocked = false; // Prevent further toggling after lights are locked

    private void Start()
    {
        // Set all lights to be on initially
        foreach (var light in lights)
        {
            if (light != null)
            {
                light.enabled = areLightsOn;
            }
        }

        // Start the timer immediately to lock the lights after 20 seconds
        Invoke(nameof(LockLights), TimeBeforeShutOff);
    }

    public void ToggleLights()
    {
        if (lightsLocked) return; // Prevent toggling if lights are locked

        areLightsOn = !areLightsOn; // Toggle the state

        foreach (var light in lights)
        {
            if (light != null)
            {
                light.enabled = areLightsOn; // Set the light's enabled state
            }
        }
    }

    private void LockLights()
    {
        // Ensure all lights are turned off
        foreach (var light in lights)
        {
            if (light != null)
            {
                light.enabled = false;
            }
        }

        areLightsOn = false;
        lightsLocked = true; // Lock the lights to prevent further toggling

        // Play the sound effect (e.g., explosion sound)
        if (soundEffect != null)
        {
            soundEffect.Play();
        }

        Debug.Log("Lights exploded and cannot be turned on anymore!");
    }
}