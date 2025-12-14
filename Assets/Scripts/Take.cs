using UnityEngine;
using UnityEngine.Custom;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Take : MonoBehaviour, IHoverable
{
    public static Take CurrentEquipped { get; private set; }

    [SerializeField] private Transform rightHand;
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private InputActionReference takeActionReference;
    [SerializeField] private Vector3 positionOffset = new(3f, -4.5f, 1f);
    [SerializeField] private Vector3 rotationOffset = new(-30f, -80f, 75f);

    private Rigidbody rb;

    private bool isHovered = false;
    public bool IsEquipped {get; private set;} = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        takeActionReference.action.Enable();
        takeActionReference.action.performed += OnTakePerformed;
    }

    private void OnDisable()
    {
        takeActionReference.action.performed -= OnTakePerformed;
        takeActionReference.action.Disable();
    }

    public void OnHoverEnter(HoverEnterEventArgs args) => isHovered = true;
    public void OnHoverExit(HoverEnterEventArgs args) => isHovered = false;

    private void OnTakePerformed(InputAction.CallbackContext context)
    {
        if (!IsEquipped)
        {
            if (!isHovered) return;
            if (CurrentEquipped != null) return;
            
            float distance = Vector3.Distance(rightHand.position, transform.position);
            if (distance > maxDistance) return;

            TakeItem();
        }
        else DropItem();
    }

    private void TakeItem()
    {
        rb.isKinematic = true;
        transform.SetParent(rightHand);
        transform.SetLocalPositionAndRotation(positionOffset, Quaternion.Euler(rotationOffset));
        IsEquipped = true;
        CurrentEquipped = this;
    }

    private void DropItem()
    {
        rb.isKinematic = false;
        transform.SetParent(null);
        IsEquipped = false;
        if (CurrentEquipped == this)
            CurrentEquipped = null;
    }
}
