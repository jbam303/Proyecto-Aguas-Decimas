using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_manager : MonoBehaviour
{
    public string escena_iniciar;
    public string escena_saltar;
    public GameObject canva_menu;
    public GameObject canva_creditos;

    public void Iniciar()
    {
        SceneManager.LoadScene(escena_iniciar);
    }

    public void Saltar()
    {
        SceneManager.LoadScene(escena_saltar);
    }

    public void Creditos()
    {
        canva_menu.SetActive(false);
        canva_creditos.SetActive(true);
    }

    public void Volver()
    {
        canva_creditos.SetActive(false);
        canva_menu.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
