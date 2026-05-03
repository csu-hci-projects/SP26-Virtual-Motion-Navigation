using UnityEngine;

public class TrialManager : MonoBehaviour
{
    public IntensityUI intensityUI;
    public GameObject spherePrefab;
    public Transform raft;
    public float radius = 10f;
    public int totalTrials = 20;

    private int currentTrial = 0;
    private GameObject currentSphere;

    public void StartTrials()
    {
        intensityUI.ApplyIntensity();
        currentTrial = 0;
        SpawnSphere();
    }
    void Start()
    {
        //wait for menu
    }

    [Header("Spawn Settings")]
    public float minRadius = 5f;
    public float maxRadius = 15f;
    public float minHeight = 0.5f;
    public float maxHeight = 10f;

    void SpawnSphere()
    {
        if (currentTrial >= totalTrials)
        {
            Debug.Log("Trial complete!");
            return;
        }
        Debug.Log("Trial " + (currentTrial + 1) + " / " + totalTrials);

        if (currentTrial >= totalTrials)
        {
            Debug.Log("Trial complete!");
            return;
        }

        Vector3 randomPos;
        int attempts = 0;
        do
        {
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(minRadius, maxRadius);

            float x = raft.position.x + Mathf.Cos(angle) * distance;
            float z = raft.position.z + Mathf.Sin(angle) * distance;
            float y = raft.position.y + Random.Range(minHeight, maxHeight);

            randomPos = new Vector3(x, y, z);
            attempts++;
        } while (attempts < 10 && Vector3.Distance(randomPos, Camera.main.transform.position) < minRadius);

        currentSphere = Instantiate(spherePrefab, randomPos, Quaternion.identity);
        var targetScript = currentSphere.GetComponent<TargetSphere>();
        targetScript.onSelected = OnSphereSelected;
    }

    void OnSphereSelected()
    {
        Destroy(currentSphere);
        currentTrial++;
        SpawnSphere();
    }
}