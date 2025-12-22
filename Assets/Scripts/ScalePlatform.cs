using UnityEngine;

public class ScalePlatform : MonoBehaviour
{
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
            // Debug.Log($"� ����� �����: {obj.name}");
        }
    }

    public GameObject GetObjectOnScale()
    {
        // Debug.Log($"������ �������: {(objectOnScale != null ? objectOnScale.name : "null")}");
        return objectOnScale;
    }
}