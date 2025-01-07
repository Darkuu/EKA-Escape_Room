using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;



public class ShootWeapon : MonoBehaviour

{

    public GameObject bullet;
    public Transform spawnPoint;
    public AudioSource soundEffect; 
    public float fireSpeed = 20;




    void Start()

    {

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(FireBullet);

    }
    public void FireBullet(ActivateEventArgs arg)

    {

        GameObject spawnedBullet = Instantiate(bullet);
        soundEffect.Play();
        spawnedBullet.transform.position = spawnPoint.position;

        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;

        Destroy(spawnedBullet, 5);

    }

}