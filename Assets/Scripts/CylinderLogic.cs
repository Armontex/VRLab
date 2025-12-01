using System;
using UnityEngine;
using UnityEngine.Custom;


public class CylinderLogic : MonoBehaviour
{
    // Радиус
    [SerializeField] private double baseMinRadius = 5;
    [SerializeField] private double baseMaxRadius = 5;
    [SerializeField] private double baseRadiusError = 0.03;
    private double radius;

    // Длинна
    [SerializeField] private double baseMinLength = 10;
    [SerializeField] private double baseMaxLength = 15;
    [SerializeField] private double baseLengthError = 0.1;
    private double length;


    // Масса
    public CylinderMaterialType MaterialType { get; private set; }

    // Прочее
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
    }

    void Update()
    {

    }

    /// <summary>
    /// Получить радиус цилиндра (By Идея 2)
    /// </summary>
    /// <returns>Радиус цилиндра</returns>
    public double GetRadius()
    {
        double micro = (rnd.NextDouble() - rangeNumber) * baseRadiusError;
        return radius + micro;
    }

    /// <summary>
    /// Получить длинну цилиндра
    /// </summary>
    /// <returns>Длинна цилиндра</returns>
    public double GetLength()
    {
        double micro = (rnd.NextDouble() - rangeNumber) * baseLengthError;
        return length + micro;
    }

    /// <summary>
    /// Получить массу цилиндра
    /// </summary>
    /// <returns>Масса цилиндра</returns>
    public double GetMass()
    {
        return (Math.PI * radius * radius) * length * MaterialType.GetDensity();
    }
}
