using UnityEngine;

public class IntensityUI : MonoBehaviour
{
    public RaftMotion raftMotion;

    public void SetLow()
    {
        raftMotion.SetIntensity(0.5f);
    }

    public void SetMedium()
    {
        raftMotion.SetIntensity(1.0f);
    }

    public void SetHigh()
    {
        raftMotion.SetIntensity(1.5f);
    }

    public void SetExtreme()
    {
        raftMotion.SetIntensity(2.0f);
    }
}