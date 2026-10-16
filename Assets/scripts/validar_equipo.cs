using UnityEngine;

public class validar_equipo : MonoBehaviour
{
    public int contador = 0;
    public GameObject boton_iniciar;
    public desactivar_cosas desactivar_cosas;

    public void Contar()
    {
        contador += 1;
    }

    void Update()
    {
        if(contador >= 4 && desactivar_cosas.contador >= 3)
        {
            boton_iniciar.SetActive(true);
        }
    }
}
