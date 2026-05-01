using UnityEngine;

public class TrialManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform raft;
    public float radius = 5f;
    public int totalTrials = 10;

    private int currentTrial = 0;
    private GameObject currentSphere;

    void Start()
    {
        SpawnSphere();
    }

    void SpawnSphere()
    {
        if (currentTrial >= totalTrials)
        {
            Debug.Log("Trial complete!");
            return;
        }

        Vector3 randomPos = raft.position + Random.onUnitSphere * radius;
        randomPos.y = Mathf.Max(randomPos.y, raft.position.y); // keep above raft

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