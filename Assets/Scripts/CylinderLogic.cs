using System;
using UnityEngine;
using UnityEngine.Custom;


public class CylinderLogic : MonoBehaviour
{
    // Radius
    [SerializeField] private double baseMinRadius = 0.01;
    [SerializeField] private double baseMaxRadius = 0.02;
    [SerializeField] private double baseRadiusError = 0.0015;
    private double radius;

    // Length
    [SerializeField] private double baseMinLength = 0.1;
    [SerializeField] private double baseMaxLength = 0.15;
    [SerializeField] private double baseLengthError = 0.005;
    private double length;


    // Material
    public CylinderMaterialType MaterialType { get; private set; }

    // Other
    private readonly System.Random rnd = new();
    private const double rangeNumber = 0.5;

    private void Awake()
    {
        var materialTypes = (CylinderMaterialType[])Enum.GetValues(typeof(CylinderMaterialType));
        MaterialType = rnd.RandomChoice(materialTypes);
    }

    void Start()
    {
        radius = UnityEngine.Random.Range((float)baseMinRadius, (float)baseMaxRadius);
        length = UnityEngine.Random.Range((float)baseMinLength, (float)baseMaxLength);
        Debug.Log($"Cylinder is created. Mass: {GetMass()} | Radius: {GetRadius()} | Length: {GetLength()} | MT: {MaterialType}");
    }

    public double GetRadius()
    {
        double micro = (rnd.NextDouble() - rangeNumber) * baseRadiusError;
        return radius + micro;
    }

    public double GetLength()
    {
        double micro = (rnd.NextDouble() - rangeNumber) * baseLengthError;
        return length + micro;
    }

    public double GetMass()
    {
        return (Math.PI * radius * radius) * length * MaterialType.GetDensity();
    }
}
