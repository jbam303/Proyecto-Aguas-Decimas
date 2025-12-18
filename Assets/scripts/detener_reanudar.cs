using UnityEngine;

public class detener_reanudar : MonoBehaviour
{
    public AudioSource sonido_cascada;
    public ParticleSystem gotas;
    public ParticleSystem espuma;
    public void reproducir()
    {
        if (sonido_cascada.isPlaying)
        {
            sonido_cascada.Stop();
            gotas.Stop();
            espuma.Stop();
        }
        else
        {
            sonido_cascada.Play();
            gotas.Play();
            espuma.Play();
        }
    }
}
