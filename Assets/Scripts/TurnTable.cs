using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurntableMusicPlayer : MonoBehaviour
{
    [Header("References")] public XRSocketInteractor socket; // XR Socket that holds the platter
    public AudioSource musicSource; // AudioSource for the music
    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnPlatterPlaced);
        socket.selectExited.AddListener(OnPlatterRemoved);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnPlatterPlaced);
        socket.selectExited.RemoveListener(OnPlatterRemoved);
    }

    private void OnPlatterPlaced(SelectEnterEventArgs args)
    {
        PlayMusic();
    }

    private void OnPlatterRemoved(SelectExitEventArgs args)
    {
        StopMusic();
    }

    private void PlayMusic()
    {
        if (musicSource && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    private void StopMusic()
    {
        if (musicSource && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}