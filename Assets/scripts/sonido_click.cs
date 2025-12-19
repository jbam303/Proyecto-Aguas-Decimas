using UnityEngine;

public class sonido_click : MonoBehaviour
{
    public AudioSource sonido_boton;

    public void Reproducir()
    {
        sonido_boton.Play();
    }
}