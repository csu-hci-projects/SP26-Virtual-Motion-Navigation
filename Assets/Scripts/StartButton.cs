using UnityEngine;

public class StartButton : MonoBehaviour
{
    public TrialManager trialManager;
    public IntensityUI intensityUI;
    public GameObject startCanvas;

    void Start()
    {
        startCanvas.SetActive(false);
    }

    public void OnStartPressed()
    {
        startCanvas.SetActive(false);
        trialManager.StartTrials();
    }

    public void Show()
    {
        startCanvas.SetActive(true);
    }
}