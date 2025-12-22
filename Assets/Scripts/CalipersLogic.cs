using UnityEngine;
using UnityEngine.Custom;

public class CalipersLogic : MonoBehaviour, ITool
{
    [SerializeField] private double measurementError = 0.00005;
    private const int SantiFactor = 100;
    public string MetricUnit {get;} = "см";

    protected double GetLength(CylinderLogic cylinder)
    {
        double realLength = cylinder.GetLength();
        double noise = (Random.value * 2 - 1) * measurementError;
        return realLength + noise;
    }

    public double Use(CylinderLogic cylinderLogic)
    {
        double measuredLength = GetLength(cylinderLogic);
        Debug.Log($"Calipers used: {measuredLength}");
        return measuredLength * SantiFactor;
    }
}
