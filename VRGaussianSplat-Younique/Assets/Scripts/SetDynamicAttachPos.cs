using System.Reflection;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; 
public class SetDynamicAttachPos : XRGrabInteractable
{
    public bool UseDynamicAttach
    {
        get
        {
            FieldInfo field = typeof(XRGrabInteractable).GetField("m_UseDynamicAttach", BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)field.GetValue(this);
        }
        set
        {            FieldInfo field = typeof(XRGrabInteractable).GetField("m_UseDynamicAttach", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(this, value);
        }
    }
}
