using UnityEngine;

public class detener_reanudar : MonoBehaviour
{
    public AudioSource sonido_cascada;
    public ParticleSystem gotas;
    public void reproducir()
    {
        if (sonido_cascada.isPlaying)
        {
            sonido_cascada.Stop();
            gotas.Stop();
        }
        else
        {
            sonido_cascada.Play();
            gotas.Play();
        }
    }
}
