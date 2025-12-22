using System;
using UnityEngine;
using UnityEngine.Custom;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ITool))]
[RequireComponent(typeof(Take))]
public class ToolUsage : MonoBehaviour, IHoverable
{
    [SerializeField] private Transform rightHand;
    [SerializeField] private TextDisplay textDisplay;
    [SerializeField] private float maxDistance = 3f;

    public double Value { get; private set; } = 0;
    private ITool tool;
    private Take take;

    void Start()
    {
        tool = GetComponent<ITool>();
        take = GetComponent<Take>();
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (take.IsEquipped)
        {
            Debug.Log($"Tool <{gameObject.name}> enter hover Cylinder");

            GameObject cylinder = args.interactableObject.transform.gameObject;
            CylinderLogic cylinderLogic = cylinder.GetComponent<CylinderLogic>();

            float distance = Vector3.Distance(rightHand.position, cylinder.transform.position);
            if (distance > maxDistance)
                return;

            Value = tool.Use(cylinderLogic);
            textDisplay.SetValue(Math.Round(Value, 6).ToString());
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        textDisplay.ResetValue();
    }
}