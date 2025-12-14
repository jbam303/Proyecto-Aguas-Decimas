using UnityEngine;

public class ControladorPasosUniversal : MonoBehaviour
{
    public AudioSource fuenteDeAudio;
    public float velocidadMinima = 0.05f; 
    private Vector3 posicionAnterior;
    private float velocidadCalculada;

    void Start()
    {
        posicionAnterior = transform.position;
    }

    void Update()
    {
        float distanciaRecorrida = Vector3.Distance(transform.position, posicionAnterior);
        velocidadCalculada = distanciaRecorrida / Time.deltaTime;
        posicionAnterior = transform.position;
        if (velocidadCalculada > velocidadMinima)
        {
            if (!fuenteDeAudio.isPlaying)
            {
                fuenteDeAudio.Play();
            }
        }
        else
        {
            if (fuenteDeAudio.isPlaying)
            {
                fuenteDeAudio.Pause();
            }
        }
    }
}