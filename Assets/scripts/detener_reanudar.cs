using UnityEngine;

public class detener_reanudar : MonoBehaviour
{
    public AudioSource sonido_loop;
    public ParticleSystem gotas;
    public ParticleSystem espuma;
    public void Reproducir()
    {
        if (sonido_loop.isPlaying)
        {
            sonido_loop.Stop();
            gotas.Stop();
            espuma.Stop();
        }
        else
        {
            sonido_loop.Play();
            gotas.Play();
            espuma.Play();
        }
    }
}
