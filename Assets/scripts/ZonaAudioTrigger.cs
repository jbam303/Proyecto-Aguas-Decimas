using UnityEngine;

public class AudioZona : MonoBehaviour
{
    [Header("Configuración")]
    public AudioSource emisorAudio; // El parlante
    
    // ESTA ES LA CLAVE: Una variable privada que recuerda
    private bool yaSono = false; 

    private void OnTriggerEnter(Collider other)
    {
        // 1. Preguntamos: "¿Ya sonó antes?"
        // Si yaSono es verdadero, el "return" hace que el código se detenga aquí y no haga nada.
        if (yaSono == true) return;

        // 2. Filtro de seguridad:
        // Verificamos si lo que entró es el Jugador o el Carrito (para que no lo active una mosca)
        // Puedes ajustar este "if" según tus Tags, o quitarlo si tus capas de física ya están bien.
        if (other.CompareTag("Player") || other.GetComponent<MotorCarrito>()) 
        {
            // 3. Reproducir
            emisorAudio.Play();

            // 4. BLOQUEAR PARA SIEMPRE
            yaSono = true; 
        }
    }
}