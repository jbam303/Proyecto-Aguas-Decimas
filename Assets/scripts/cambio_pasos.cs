using UnityEngine;

public class cambio_pasos : MonoBehaviour
{
    public AudioSource pasos;
    public AudioClip concreto;
    public AudioClip tierra;
    
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("concreto"))
        {
            if (pasos.clip != concreto)
            {
                pasos.clip = concreto;
                if (pasos.isPlaying) 
                {
                    pasos.Play(); 
                }
            }
        }

        if (collision.gameObject.CompareTag("tierra"))
        {
            if (pasos.clip != tierra)
            {
                pasos.clip = tierra;
                if (pasos.isPlaying) 
                {
                    pasos.Play(); 
                }
            }
        }
    }
}