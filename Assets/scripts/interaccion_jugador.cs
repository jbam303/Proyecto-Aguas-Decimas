using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InteraccionJugador : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaBoton;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DispararRayo();
        }
    }

    void DispararRayo()
    {
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, distanciaInteraccion, capaBoton))
        {
            Button botonTocado = hit.collider.GetComponent<Button>();

            if (botonTocado != null)
            {
                botonTocado.onClick.Invoke();
            }
        }
    }
}