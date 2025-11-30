using UnityEngine;
using Unity.Cinemachine;

public class AutoTourDriver : MonoBehaviour
{
    [Header("Configuración")]
    public CinemachineSplineCart cart; // Referencia al componente del carrito
    public float velocidad = 5f;       // Velocidad en metros por segundo
    public bool motorEncendido = true; // ¿Se está moviendo?

    private void Update()
    {
        // Si el motor está apagado (estamos en una estación), no hacemos nada
        if (!motorEncendido || cart == null) return;

        // Movemos el carrito avanzando su posición
        // Calculamos cuánto avanzar según la velocidad y el tiempo
        float distanciaAvanzada = velocidad * Time.deltaTime;

        // Le sumamos esa distancia a la posición actual del carrito
        cart.SplinePosition += distanciaAvanzada;
    }

    // Funciones para llamar desde las Estaciones
    public void Frenar()
    {
        motorEncendido = false;
    }

    public void Arrancar()
    {
        motorEncendido = true;
    }
}