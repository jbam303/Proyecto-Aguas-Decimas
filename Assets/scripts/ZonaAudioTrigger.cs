using UnityEngine;

public class ZoneAudioTrigger : MonoBehaviour
{
    [Header("Configuración")]
    public AudioSource audioSource;
    public bool detenerAlSalir = false; // ¿Quieres que se calle si el jugador se va?

    // Esta función se ejecuta automáticamente cuando algo entra en la esfera verde
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si lo que entró es el Jugador (y no un enemigo o una caja)
        if (other.CompareTag("Player"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    // Esta función se ejecuta cuando algo sale de la esfera
    private void OnTriggerExit(Collider other)
    {
        if (detenerAlSalir && other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}