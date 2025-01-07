using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Light lanternLight; 
    public AudioSource ignitionSound; 

    public bool IsLit { get; private set; } = false;

    void Start()
    {
        if (lanternLight != null)
            lanternLight.enabled = false;
    }

    public void Ignite()
    {
        if (IsLit)
            return;
        IsLit = true;
        // Turn on the lantern light
            lanternLight.enabled = true;
        // Play ignition sound
            ignitionSound.Play();

        Debug.Log("Lantern is now lit!");
    }
}