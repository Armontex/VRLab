using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScaleButton : MonoBehaviour
{
    public ScalePlatform scale;
    public TMP_Text resultText;
    [SerializeField] private InputActionReference takeActionReference;

    private void OnEnable()
    {
        if (takeActionReference != null && takeActionReference.action != null)
        {
            takeActionReference.action.Enable();
            takeActionReference.action.performed += OnControllerButtonPressed;
        }
    }

    private void OnDisable()
    {
        if (takeActionReference != null && takeActionReference.action != null)
        {
            takeActionReference.action.performed -= OnControllerButtonPressed;
            takeActionReference.action.Disable();
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
                resultText.text = $"{mass:F6} kg";
        }
        else
        {
            Debug.Log("Нет цилиндра");
            if (resultText != null) resultText.text = "Ошибка";
        }
    }
}