using UnityEngine;
using UnityEngine.UI;

public class InteraccionJugador : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaBoton;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DispararRayo();
        }
    }

    void DispararRayo()
    {
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, distanciaInteraccion))
        {
            Button botonTocado = hit.collider.GetComponent<Button>();

            if (botonTocado != null)
            {
                botonTocado.onClick.Invoke();
            }
        }
    }
}