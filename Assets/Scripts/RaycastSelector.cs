using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public float range = 100f;
    private TargetSphere currentTarget;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            TargetSphere target = hit.collider.GetComponent<TargetSphere>();

            if (target != currentTarget)
            {
                currentTarget?.OnHoverExit();
                currentTarget = target;
                currentTarget?.OnHoverEnter();
            }

            if (Input.GetMouseButtonDown(0)) // or VR trigger
            {
                currentTarget?.Select();
            }
        }
        else
        {
            currentTarget?.OnHoverExit();
            currentTarget = null;
        }
    }
}