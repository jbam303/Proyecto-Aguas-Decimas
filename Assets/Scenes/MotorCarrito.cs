using UnityEngine;
using Unity.Cinemachine; 

public class MotorCarrito : MonoBehaviour
{
    // Aquí arrastraremos el componente del carrito
    public CinemachineSplineCart carrito; 
    
    // Velocidad del viaje
    public float velocidad = 2f; 
    
    // Interruptor para encender/apagar
    public bool encendido = true; 

    void Update()
    {
        // Si el motor está encendido Y tenemos asignado el carrito...
        if (encendido && carrito != null)
        {
            // Movemos el carrito sumando posición constante
            // SplinePosition avanza en metros a lo largo de la línea
            carrito.SplinePosition += velocidad * Time.deltaTime;
        }
    }
}