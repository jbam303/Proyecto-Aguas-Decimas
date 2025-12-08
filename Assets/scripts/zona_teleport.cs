using UnityEngine;
using UnityEngine.SceneManagement;

public class zona_teleport : MonoBehaviour
{
    public string escena_destino;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(escena_destino);
        }
    }
}