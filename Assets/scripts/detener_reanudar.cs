using UnityEngine;

public class detener_reanudar : MonoBehaviour
{
    public AudioSource sonido_cascada;
    public GameObject[] aguas;
    public ParticleSystem[] particulas;

    public void reproducir()
    {
        if (sonido_cascada.isPlaying)
        {
            sonido_cascada.Stop();
            foreach (GameObject agua in aguas)
            {
                agua.SetActive(false);
            }

            foreach (ParticleSystem particula in particulas)
            {
                particula.Stop(true);
            }
        }
        else
        {
            sonido_cascada.Play();
            foreach (GameObject agua in aguas)
            {
                agua.SetActive(true);
            }

            foreach (ParticleSystem particula in particulas)
            {
                particula.Play(true);
            }
        }
    }
}
