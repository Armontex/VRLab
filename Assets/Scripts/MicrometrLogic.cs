using UnityEngine;
using UnityEngine.Custom;

public class MicrometrLogic : MonoBehaviour, ITool
{
    [SerializeField] private double measurementError = 1e-6;

    protected double GetRadius(CylinderLogic cylinder)
    {
        double realRadius = cylinder.GetRadius();
        double noise = (Random.value * 2 - 1) * measurementError;
        return realRadius + noise;
    }

    public double Use(CylinderLogic cylinderLogic)
    {
        double measuredRadius = GetRadius(cylinderLogic);
        Debug.Log($"Micrometr used: {measuredRadius}");
        return measuredRadius;
    }
}
