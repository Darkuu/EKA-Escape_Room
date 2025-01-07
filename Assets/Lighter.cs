using UnityEngine;

public class Lighter : MonoBehaviour
{
    public Light flameLight; 
    public ParticleSystem flameParticles; 
    public AudioSource lighterSound; 

    private bool isOn = false;

    void Start()
    {
        // Ensure the lighter is off when the scene starts
        if (flameLight != null)
            flameLight.enabled = false;

        if (flameParticles != null)
            flameParticles.Stop();
    }
    
    public void ToggleLighter()
    {
        isOn = !isOn;

        // Toggle light and particle effects
        if (flameLight != null)
            flameLight.enabled = isOn;

        if (flameParticles != null)
        {
            if (isOn)
                flameParticles.Play();
            else
                flameParticles.Stop();
        }
            lighterSound.Play();
    }

    void OnTriggerStay(Collider other)
    {
        if (isOn && other.CompareTag("Lantern"))
        {
            Lantern lantern = other.GetComponent<Lantern>();
            if (lantern != null && !lantern.IsLit)
            {
                lantern.Ignite();
            }
        }
    }
}