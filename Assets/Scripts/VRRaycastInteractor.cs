using UnityEngine;
using UnityEngine.XR;

public class VRRaycastInteractor : MonoBehaviour
{
    [Header("Ray Settings")]
    public float rayLength = 10f;
    public LayerMask targetLayer;

    private TargetSphere currentHovered;

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
            .TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

        if (Physics.Raycast(ray, out hit, rayLength, targetLayer))
        {
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