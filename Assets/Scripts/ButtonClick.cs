using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    private Keypad keypad;
    private string buttonValue;

    public void Initialize(Keypad keypadReference, string value)
    {
        keypad = keypadReference;
        buttonValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller")) // Only trigger when a controller touches the button
        {
            keypad.PressButton(buttonValue);
            Debug.Log($"Button {buttonValue} pressed!");
        }
    }
}