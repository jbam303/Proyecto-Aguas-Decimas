using UnityEngine;

public class AguaMovil : MonoBehaviour
{
    [Header("Configuración del Flujo")]
    // Velocidad en X (Horizontal) y Y (Vertical)
    // Ajusta estos números para cambiar la dirección del agua
    public float velocidadX = 0f;
    public float velocidadY = 0.5f; 

    private Renderer miRender;

    void Start()
    {
        // Obtenemos el componente que dibuja el objeto
        miRender = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculamos cuánto se ha movido basado en el tiempo
        // Time.time es el tiempo en segundos desde que inició el juego
        float movimientoX = Time.time * velocidadX;
        float movimientoY = Time.time * velocidadY;

        // Aplicamos el desplazamiento (Offset) a la textura
        miRender.material.mainTextureOffset = new Vector2(movimientoX, movimientoY);
    }
}
