using System.Collections;
using UnityEngine;

public class reproducir : MonoBehaviour
{
    public AudioSource[] audio_sonando;
    public int segundos_sleep;
    public AudioSource primer_audio;
    private bool reproducir_audio = true;
    private IEnumerator PausarYEjecutar()
    {
        yield return new WaitForSeconds(segundos_sleep);
        if (reproducir_audio == true)
        {
            foreach (AudioSource audio in audio_sonando)
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }
            }

            primer_audio.Play();
            reproducir_audio = false;
        }
    }
    void Start()
    {
        StartCoroutine(PausarYEjecutar());
    }
}
