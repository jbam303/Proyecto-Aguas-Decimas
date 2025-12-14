using UnityEngine;

public class boton_audio : MonoBehaviour
{
    public AudioSource[] audio_sonando;
    public AudioSource audio_estructura;
    private bool sonando = false;

    public void Reproducir()
    {
        sonando = false;
        foreach (AudioSource audio in audio_sonando)
        {
            if (audio.isPlaying)
            {
                sonando = true;
            }
        }

        if (sonando == false)
        {
            audio_estructura.Play();
        }
    }
}