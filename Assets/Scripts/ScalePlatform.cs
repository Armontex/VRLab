using TMPro;
using UnityEngine;

public class ScalePlatform : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    private GameObject objectOnScale;

    public void ObjectPlaced(GameObject obj)
    {
        objectOnScale = obj;
        // Debug.Log($"�� ���� ���������: {obj.name}");
    }

    public void ObjectRemoved(GameObject obj)
    {
        if (obj == objectOnScale)
        {
            objectOnScale = null;
            resultText.text = "0.000 кг";
            // Debug.Log($"� ����� �����: {obj.name}");
        }
    }

    public GameObject GetObjectOnScale()
    {
        // Debug.Log($"������ �������: {(objectOnScale != null ? objectOnScale.name : "null")}");
        return objectOnScale;
    }
}