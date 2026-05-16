using UnityEngine;
using UnityEngine.Events;

public class accionador_pc : MonoBehaviour
{
    public UnityEvent acciones_click = new UnityEvent();
    public UnityEvent acciones_hover_on = new UnityEvent();
    public UnityEvent acciones_hover_off = new UnityEvent();

    private void OnMouseDown()
    {
        acciones_click.Invoke();
    }

    private void OnMouseEnter()
    {
        acciones_hover_on.Invoke();
    }

    private void OnMouseExit()
    {
        acciones_hover_off.Invoke();
    }
}