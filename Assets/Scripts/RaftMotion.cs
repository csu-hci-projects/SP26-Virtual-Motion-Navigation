using UnityEngine;

public class RaftMotion : MonoBehaviour
{
    [Header("Base Values")]
    public float baseBobHeight = 0.5f;
    public float baseBobSpeed = 1.0f;
    public float baseTiltAmount = 5f;
    public float baseTiltSpeed = 0.5f;

    [Header("Current Intensity Multiplier")]
    public float intensity = 1.0f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float bob = Mathf.Sin(Time.time * baseBobSpeed * intensity) * baseBobHeight * intensity;

        float tiltX = Mathf.Sin(Time.time * baseTiltSpeed * intensity) * baseTiltAmount * intensity;
        float tiltZ = Mathf.Cos(Time.time * baseTiltSpeed * 0.8f * intensity) * baseTiltAmount * intensity;

        transform.position = startPos + new Vector3(0, bob, 0);
        transform.rotation = Quaternion.Euler(tiltX, 0, tiltZ);
    }

    public void SetIntensity(float newIntensity)
    {
        intensity = newIntensity;
    }
}