using UnityEngine;
using UnityEngine.InputSystem;

public class Take : MonoBehaviour
{
    [SerializeField] private Transform rightHand;
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private InputActionReference takeActionReference;
    [SerializeField] private Vector3 positionOffset = new(3f, -4.5f, 1f);
    [SerializeField] private Vector3 rotationOffset = new(-30f, -80f, 75f);

    private Rigidbody rb;

    private bool isHovered = false;
    private bool isEquipped = false;

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

    public void OnHoverEnter() => isHovered = true;
    public void OnHoverExit() => isHovered = false;

    private void OnTakePerformed(InputAction.CallbackContext context)
    {
        if (!isEquipped)
        {
            if (!isHovered) return;
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
        isEquipped = true;
    }

    private void DropItem()
    {
        rb.isKinematic = false;
        transform.SetParent(null);
        isEquipped = false;
    }
}
