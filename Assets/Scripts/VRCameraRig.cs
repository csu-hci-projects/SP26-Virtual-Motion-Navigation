using UnityEngine;

public class VRCameraRig : MonoBehaviour
{
    [Header("Raft Reference")]
    public Transform raft;

    [Header("Offset from Raft Center")]
    public Vector3 positionOffset = new Vector3(0f, 1.6f, 0f); // standing height

    void LateUpdate()
    {
        if (raft == null) return;

        // Follow raft position + offset
        transform.position = raft.position + raft.rotation * positionOffset;

        // Match raft rotation (bob/tilt carries through)
        transform.rotation = raft.rotation;
    }
}