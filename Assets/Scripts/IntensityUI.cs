using UnityEngine;

public class IntensityUI : MonoBehaviour
{
    public RaftMotion raftMotion;
    public StartButton startButton;
    public GameObject intensityPanel;

    private float selectedIntensity = 1.0f;
    private bool trialStarted = false;

    public void SetLow()
    {
        if (trialStarted) return;
        selectedIntensity = 0.5f;
        startButton.Show();
    }

    public void SetMedium()
    {
        if (trialStarted) return;
        selectedIntensity = 1.0f;
        startButton.Show();
    }

    public void SetHigh()
    {
        if (trialStarted) return;
        selectedIntensity = 1.5f;
        startButton.Show();
    }

    public void SetExtreme()
    {
        if (trialStarted) return;
        selectedIntensity = 2.0f;
        startButton.Show();
    }

    public void ApplyIntensity()
    {
        trialStarted = true;
        raftMotion.SetIntensity(selectedIntensity);
        intensityPanel.SetActive(false);
    }

    public string GetCurrentIntensity()
    {
        if (selectedIntensity == 0.5f) return "Low";
        if (selectedIntensity == 1.0f) return "Medium";
        if (selectedIntensity == 1.5f) return "High";
        if (selectedIntensity == 2.0f) return "Extreme";
        return "Unknown";
    }
}