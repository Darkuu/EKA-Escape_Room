using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public string correctCode = "2244";
    private string enteredCode = "";

    [Header("References")]
    public GameObject safeDoor;        // The door to open
    public TMP_Text displayText;       // The TextMeshPro text for displaying input
    public GameObject[] keypadButtons; // The keypad buttons
    public GameObject explosiveObject; // The explosive object to activate
    
    [Header("Audio")]
     public AudioSource ButtonSound;
    public AudioSource PositiveSound; 
    public AudioSource NegativeSound; 

    private void Start()
    {
        // Initialize keypad buttons
        for (int i = 0; i < keypadButtons.Length; i++)
        {
            int buttonValue = i + 1;
            var button = keypadButtons[i];

            ButtonInteraction buttonInteraction = button.AddComponent<ButtonInteraction>();
            buttonInteraction.Initialize(this, buttonValue.ToString());
        }

        UpdateDisplay();

        // Ensure explosive is inactive at the start
        if (explosiveObject != null)
        {
            explosiveObject.SetActive(false);
        }
    }

    public void PressButton(string buttonValue)
    {
        enteredCode += buttonValue;
        UpdateDisplay();
        ButtonSound.Play();

        if (enteredCode.Length >= correctCode.Length)
        {
            if (enteredCode == correctCode)
            {
                UnlockSafe();
                PositiveSound.Play();
                
            }
            else
            {
                enteredCode = "";
                UpdateDisplay();
                NegativeSound.Play();
            }
        }
    }

    private void UnlockSafe()
    {
        displayText.text = "UNLOCKED!";
        safeDoor.transform.Rotate(0, 0, 90); // Opens the door

        // Activate the explosive object
        if (explosiveObject != null)
        {
            explosiveObject.SetActive(true);
        }
    }

    private void UpdateDisplay()
    {
        // Update the TMP_Text with the current entered code
        displayText.text = enteredCode;
    }
}