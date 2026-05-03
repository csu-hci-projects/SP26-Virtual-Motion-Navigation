using UnityEngine;
using UnityEngine.XR;

public class VRRaycastInteractor : MonoBehaviour
{
    [Header("Ray Settings")]
    public float rayLength = 20f;
    public LayerMask targetLayer;

    private TargetSphere currentHovered;

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
            .TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed);

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
        Debug.DrawRay(transform.position, transform.up * rayLength, Color.green);
        Debug.DrawRay(transform.position, transform.right * rayLength, Color.blue);

        // Debug: hit anything regardless of layer
        if (Physics.Raycast(ray, out RaycastHit debugHit, rayLength))
        {
            Debug.Log("Hit something: " + debugHit.collider.gameObject.name + " layer: " + debugHit.collider.gameObject.layer);
        }

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, targetLayer))
        {
            StartButton startButton = hit.collider.GetComponent<StartButton>();
            if (startButton != null && triggerPressed)
            {
                startButton.OnStartPressed();
                return;
            }

            TargetSphere sphere = hit.collider.GetComponent<TargetSphere>();
            if (sphere != null)
            {
                if (sphere != currentHovered)
                {
                    ExitCurrentHover();
                    currentHovered = sphere;
                    currentHovered.OnHoverEnter();
                }

                if (triggerPressed)
                {
                    currentHovered.Select();
                }
            }
            else
            {
                ExitCurrentHover();
            }
        }
        else
        {
            ExitCurrentHover();
        }
    }

    void ExitCurrentHover()
    {
        if (currentHovered != null)
        {
            currentHovered.OnHoverExit();
            currentHovered = null;
        }
    }
}