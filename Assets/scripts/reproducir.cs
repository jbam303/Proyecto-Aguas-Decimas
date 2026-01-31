using System.Collections;
using UnityEngine;

public class reproducir : MonoBehaviour
{
    public int segundos_sleep;
    public AudioSource primer_audio;
    private IEnumerator PausarYEjecutar()
    {
        yield return new WaitForSeconds(segundos_sleep);
        primer_audio.Play();
    }
    void Start()
    {
        StartCoroutine(PausarYEjecutar());
    }
}
