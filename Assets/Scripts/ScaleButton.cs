using TMPro;
using UnityEngine;
using UnityEngine.Custom;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScaleButton : MonoBehaviour, IHoverable
{
    [SerializeField] private ScalePlatform scale;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private InputActionReference pressBtnActionReference;

    private bool isHovered = false;

    private void OnEnable()
    {
        if (pressBtnActionReference != null && pressBtnActionReference.action != null)
        {
            pressBtnActionReference.action.Enable();
            pressBtnActionReference.action.performed += OnControllerButtonPressed;
        }
    }

    private void OnDisable()
    {
        if (pressBtnActionReference != null && pressBtnActionReference.action != null)
        {
            pressBtnActionReference.action.performed -= OnControllerButtonPressed;
            pressBtnActionReference.action.Disable();
        }
    }

    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();

        if (interactable == null)
        {
            return;
        }

        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnControllerButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isHovered) return;
            Weigh();
        }
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        Weigh();
    }

    void Weigh()
    {
        if (scale == null)
        {
            return;
        }

        GameObject obj = scale.GetObjectOnScale();
        if (obj == null)
        {
            if (resultText != null) resultText.text = "Пусто";
            return;
        }

        CylinderLogic cylinder = obj.GetComponent<CylinderLogic>();
        if (cylinder != null)
        {
            double mass = cylinder.GetMass();

            if (resultText != null)
                resultText.text = $"{mass:F6} кг";
        }
        else
        {
            Debug.Log("Нет цилиндра");
            if (resultText != null) resultText.text = "Ошибка";
        }
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        isHovered = true;
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        isHovered = false;
    }
}