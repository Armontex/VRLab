using UnityEngine;

public class ScalePlatform : MonoBehaviour
{
    private GameObject objectOnScale;

    public void ObjectPlaced(GameObject obj)
    {
        objectOnScale = obj;
        Debug.Log($"На весы поставлен: {obj.name}");
    }

    public void ObjectRemoved(GameObject obj)
    {
        if (obj == objectOnScale)
        {
            objectOnScale = null;
            Debug.Log($"С весов убран: {obj.name}");
        }
    }

    public GameObject GetObjectOnScale()
    {
        Debug.Log($"Запрос объекта: {(objectOnScale != null ? objectOnScale.name : "null")}");
        return objectOnScale;
    }
}