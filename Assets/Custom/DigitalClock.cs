using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DigitalClock : MonoBehaviour
{
    
   [SerializeField] private TMP_Text displayTime;
   private string currentTime;
   

    void Update()
    {
        currentTime = DateTime.Now.ToString("HH:mm");
        displayTime.text = currentTime;
    }
}
