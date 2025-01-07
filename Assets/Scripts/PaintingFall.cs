using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowableObject : XRGrabInteractable
{
    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();

        // Ensure Rigidbody is kinematic initially
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Disable kinematic when grabbed
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Re-enable throwing functionality and physics
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}