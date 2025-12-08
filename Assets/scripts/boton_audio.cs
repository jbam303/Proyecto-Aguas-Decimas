using UnityEngine;

public class boton_audio : MonoBehaviour
{
    public AudioSource audio_estructura;

    public void Reproducir()
    {
        audio_estructura.Play();
    }
}
