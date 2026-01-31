using UnityEngine;

public class zona_audio : MonoBehaviour
{
    public AudioSource[] audio_sonando;
    public AudioSource nombre_audio;
    private bool reproducir = true;
    public void OnTriggerEnter(Collider collision)
    {
        if (reproducir == true)
       {
            foreach (AudioSource audio in audio_sonando)
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                nombre_audio.Play();
                reproducir = false;
            }
        }
    }
}