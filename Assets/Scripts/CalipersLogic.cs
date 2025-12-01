using UnityEngine;

public class CalipersLogic : MonoBehaviour
{
    [SerializeField] private double measurementError = 0.00005;

    private void OnTriggerEnter(Collider other)
    {
        CylinderLogic cylinder = other.GetComponent<CylinderLogic>();
        if (cylinder != null)
        {
            double measuredLength = GetLength(cylinder);
            Debug.Log($"Измеренная длина: {measuredLength:F5}");
        }
    }

    public double GetLength(CylinderLogic cylinder)
    {
        double realLength = cylinder.GetLength();
        double noise = (Random.value * 2 - 1) * measurementError;
        return realLength + noise;
    }
}
