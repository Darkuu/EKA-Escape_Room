using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectacleSpin : MonoBehaviour
{
    private int spinSpeed = 50;
    
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * spinSpeed, 0, Space.Self);
    }
}
