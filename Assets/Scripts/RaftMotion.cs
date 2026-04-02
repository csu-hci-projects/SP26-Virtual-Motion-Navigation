using UnityEngine;

public class RaftMotion : MonoBehaviour
{
    public float bobHeight = 0.5f;
    public float bobSpeed = 1.0f;

    public float tiltAmount = 5f;
    public float tiltSpeed = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        float tiltX = Mathf.Sin(Time.time * tiltSpeed) * tiltAmount;
        float tiltZ = Mathf.Cos(Time.time * tiltSpeed * 0.8f) * tiltAmount;

        transform.position = startPos + new Vector3(0, bob, 0);
        transform.rotation = Quaternion.Euler(tiltX, 0, tiltZ);
    }
}