using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRGrabInteractable))]
public class gatillo_agarrar : MonoBehaviour
{
    [Header("Gatillo izquierdo")]
    public InputActionProperty botonGatilloIzq;

    [Header("Gatillo derecho")]
    public InputActionProperty botonGatilloDer;
    
    [Header("Clikear")]
    public UnityEngine.Events.UnityEvent AlClickear;

    private XRGrabInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (!interactable.isHovered) return;

        foreach (var interactor in interactable.interactorsHovering)
        {
            if (EsManoIzquierda(interactor))
            {
                if (botonGatilloIzq.action != null && botonGatilloIzq.action.WasPressedThisFrame())
                {
                    AlClickear.Invoke();
                    return;
                }
            }

            if (EsManoDerecha(interactor))
            {
                if (botonGatilloDer.action != null && botonGatilloDer.action.WasPressedThisFrame())
                {
                    AlClickear.Invoke();
                    return; 
                }
            }
        }
    }
    
    bool EsManoIzquierda(IXRHoverInteractor interactor)
    {
        if (interactor.transform.name.Contains("Left") || (interactor.transform.parent != null && interactor.transform.parent.name.Contains("Left")))
            return true;

        return false;
    }

    bool EsManoDerecha(IXRHoverInteractor interactor)
    {
        if (interactor.transform.name.Contains("Right") || (interactor.transform.parent != null && interactor.transform.parent.name.Contains("Right")))
            return true;

        return false;
    }
}