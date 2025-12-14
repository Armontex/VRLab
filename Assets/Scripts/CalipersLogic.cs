using UnityEngine;
using UnityEngine.Custom;

public class CalipersLogic : MonoBehaviour, ITool
{
    [SerializeField] private double measurementError = 0.00005;

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
        return measuredLength;
    }
}
