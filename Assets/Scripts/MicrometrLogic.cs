using UnityEngine;
using UnityEngine.Custom;

public class MicrometrLogic : MonoBehaviour, ITool
{
    [SerializeField] private double measurementError = 1e-6;

    protected double GetDiameter(CylinderLogic cylinder)
    {
        double realRadius = cylinder.GetRadius();
        double noise = (Random.value * 2 - 1) * measurementError;
        return realRadius * 2 + noise;
    }

    public double Use(CylinderLogic cylinderLogic)
    {
        double measuredDiameter = GetDiameter(cylinderLogic);
        Debug.Log($"Micrometr used: {measuredDiameter}");
        return measuredDiameter;
    }
}
