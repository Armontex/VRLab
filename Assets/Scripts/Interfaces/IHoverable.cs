using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.Custom
{
    public interface IHoverable
    {
        void OnHoverEnter(HoverEnterEventArgs args);

        void OnHoverExit(HoverEnterEventArgs args);
    }
}