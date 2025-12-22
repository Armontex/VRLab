using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{
    private ScalePlatform parentScale;
    void Start()
    {
        parentScale = GetComponentInParent<ScalePlatform>();
        // if (parentScale == null)
        //     Debug.LogError("�� ������ ScalePlatform �� ��������!");
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"� ������� �����: {other.name}");

        if (parentScale != null && !other.CompareTag("IgnoreScale")) 
        /* FIXME: Что за тег IgnoreScale? Unity ошибку выдаёт: 

        Tag: IgnoreScale is not defined.
        UnityEngine.Component:CompareTag (string)
        ScaleTrigger:OnTriggerEnter (UnityEngine.Collider) (at Assets/Scripts/ScaleTrigger.cs:17)

        */
        {
            parentScale.ObjectPlaced(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Debug.Log($"�� �������� �����: {other.name}");

        if (parentScale != null)
        {
            parentScale.ObjectRemoved(other.gameObject);
        }
    }
}