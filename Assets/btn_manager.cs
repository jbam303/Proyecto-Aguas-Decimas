using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_manager : MonoBehaviour
{
    public string escena_iniciar;
    public string escena_saltar;

    public void Iniciar()
    {
        SceneManager.LoadScene(escena_iniciar);
    }

    public void Saltar()
    {
        SceneManager.LoadScene(escena_saltar);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
