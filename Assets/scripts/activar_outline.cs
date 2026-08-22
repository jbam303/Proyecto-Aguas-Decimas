using UnityEngine;

public class activar_outline : MonoBehaviour
{
    private Outline_script miOutline; 

    void Start()
    {
        miOutline = GetComponentInChildren<Outline_script>();

        if (miOutline == null)
        {
            Debug.LogWarning("No se encontró el Outline_script dentro de: " + gameObject.name);
        }
    }

    public void Activar()
    {
        if (miOutline != null)
        {
            miOutline.enabled = true;
        }
    }

    public void Desactivar()
    {
        if (miOutline != null)
        {
            miOutline.enabled = false;
        }
    }
}