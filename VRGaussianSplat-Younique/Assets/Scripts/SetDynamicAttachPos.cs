using System.Reflection;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; // Ensure this using directive is correct for your project setup

public class SetDynamicAttachPos : XRGrabInteractable
{
    public bool UseDynamicAttach
    {
        get
        {
            // Use reflection to access the private field
            FieldInfo field = typeof(XRGrabInteractable).GetField("m_UseDynamicAttach", BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)field.GetValue(this);
        }
        set
        {
            // Use reflection to set the private field
            FieldInfo field = typeof(XRGrabInteractable).GetField("m_UseDynamicAttach", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(this, value);
        }
    }
}
