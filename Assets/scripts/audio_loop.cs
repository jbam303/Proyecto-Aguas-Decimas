using UnityEngine;

public class audio_loop : MonoBehaviour
{
    public AudioSource sonido_loop;
    public ParticleSystem[] particulas;
    public void Reproducir()
    {
        if (sonido_loop.isPlaying)
        {
            if (particulas != null)
            {
                foreach (ParticleSystem particula in particulas)
                {
                    particula.Stop();
                }
            }
            sonido_loop.Stop();
        }
        else
        {
            if (particulas != null)
            {
                foreach (ParticleSystem particula in particulas)
                {
                    particula.Play();
                }
            }
            sonido_loop.Play();
        }
    }
}

