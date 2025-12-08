using UnityEngine;

public class zona_audio : MonoBehaviour
{
    public AudioSource nombre_audio;
    private bool reproducir = true;
    public void OnTriggerEnter(Collider collision)
    {
        if (reproducir == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                nombre_audio.Play();
                reproducir = false;
            }
        }
    }
}