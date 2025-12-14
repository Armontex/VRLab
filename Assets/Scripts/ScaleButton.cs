using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using TMPro;

public class ScaleButton : MonoBehaviour
{
    public ScalePlatform scale;
    public TMP_Text resultText;
    
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();

        if (interactable == null)
        {
            Debug.LogError("��� XRSimpleInteractable �� ������!");
            return;
        }

        interactable.selectEntered.AddListener(OnButtonPressed);
        Debug.Log("������ ������ � ������ � VR");
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("������ ������ � VR!");
        Weigh();
    }

    void Weigh()
    {
        if (scale == null)
        {
            Debug.LogError("�� ��������� ����!");
            return;
        }

        GameObject obj = scale.GetObjectOnScale();
        if (obj == null)
        {
            Debug.Log("�� ����� ������ ���");
            if (resultText != null) resultText.text = "�����";
            return;
        }

        CylinderLogic cylinder = obj.GetComponent<CylinderLogic>();
        if (cylinder != null)
        {
            double mass = cylinder.GetMass();
            Debug.Log($"�����: {mass:F4} ��");

            if (resultText != null)
                resultText.text = $"{mass:F4} ��";
        }
        else
        {
            Debug.Log("�� �������");
            if (resultText != null) resultText.text = "������";
        }
    }
}