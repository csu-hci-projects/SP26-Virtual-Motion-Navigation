using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class ExperimentCSVLogger : MonoBehaviour
{
    public string outputFileName = "MotionSickness_Output.csv";

    private string filePath;
    private StringBuilder csvBuilder = new StringBuilder();

    void Awake()
    {
        filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), outputFileName);
        csvBuilder.AppendLine("TrialNumber,Intensity,TimeTaken,TrialStartTimestamp,TrialEndTimestamp");
        Debug.Log("CSV will be saved to: " + filePath);
    }

    public void LogTrial(int trialNumber, string intensity, float timeTaken, string startTimestamp, string endTimestamp)
    {
        string row =
            $"{trialNumber}," +
            $"{intensity}," +
            $"{timeTaken.ToString("F4", CultureInfo.InvariantCulture)}," +
            $"{startTimestamp}," +
            $"{endTimestamp}";

        csvBuilder.AppendLine(row);
    }

    public void SaveToFile()
    {
        File.WriteAllText(filePath, csvBuilder.ToString());
        Debug.Log("CSV saved to: " + filePath);
    }

    public string GetTimestamp()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}