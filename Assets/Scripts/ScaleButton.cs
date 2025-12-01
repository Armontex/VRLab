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
            Debug.LogError("Нет XRSimpleInteractable на кнопке!");
            return;
        }

        interactable.selectEntered.AddListener(OnButtonPressed);
        Debug.Log("Кнопка готова к работе в VR");
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Кнопка нажата в VR!");
        Weigh();
    }

    void Weigh()
    {
        if (scale == null)
        {
            Debug.LogError("Не назначены весы!");
            return;
        }

        GameObject obj = scale.GetObjectOnScale();
        if (obj == null)
        {
            Debug.Log("На весах ничего нет");
            if (resultText != null) resultText.text = "Пусто";
            return;
        }

        CylinderLogic cylinder = obj.GetComponent<CylinderLogic>();
        if (cylinder != null)
        {
            double mass = cylinder.GetMass();
            Debug.Log($"Масса: {mass:F4} кг");

            if (resultText != null)
                resultText.text = $"{mass:F4} кг";
        }
        else
        {
            Debug.Log("Не цилиндр");
            if (resultText != null) resultText.text = "Ошибка";
        }
    }
}