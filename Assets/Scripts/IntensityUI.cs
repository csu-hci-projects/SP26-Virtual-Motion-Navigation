using UnityEngine;

public class IntensityUI : MonoBehaviour
{
    public RaftMotion raftMotion;
    public StartButton startButton;
    public GameObject intensityPanel;

    private float selectedIntensity = 1.0f;

    public void SetLow()
    {
        selectedIntensity = 0.5f;
        startButton.Show();
    }

    public void SetMedium()
    {
        selectedIntensity = 1.0f;
        startButton.Show();
    }

    public void SetHigh()
    {
        selectedIntensity = 1.5f;
        startButton.Show();
    }

    public void SetExtreme()
    {
        selectedIntensity = 2.0f;
        startButton.Show();
    }

    public void ApplyIntensity()
    {
        raftMotion.SetIntensity(selectedIntensity);
        intensityPanel.SetActive(false);
    }
}