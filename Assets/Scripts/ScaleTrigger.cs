using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{
    private ScalePlatform parentScale;
    void Start()
    {
        parentScale = GetComponentInParent<ScalePlatform>();
        if (parentScale == null)
            Debug.LogError("�� ������ ScalePlatform �� ��������!");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"� ������� �����: {other.name}");

        if (parentScale != null && !other.CompareTag("IgnoreScale"))
        {
            parentScale.ObjectPlaced(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"�� �������� �����: {other.name}");

        if (parentScale != null)
        {
            parentScale.ObjectRemoved(other.gameObject);
        }
    }
}