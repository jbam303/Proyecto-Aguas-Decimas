using UnityEngine;

public class activar_outline : MonoBehaviour
{
    public GameObject objetoConOutline;
    private Outline_script miOutline; 

    void Start()
    {
        if (objetoConOutline != null)
        {
            miOutline = objetoConOutline.GetComponent<Outline_script>();
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