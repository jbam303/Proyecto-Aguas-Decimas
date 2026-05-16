using UnityEngine;

public class activar_objetos : MonoBehaviour
{
    public GameObject[] imagenes;
    public GameObject[] objetos;

    public GameObject texto_images;
    public GameObject texto_objetos;

    public void Mostrar()
    {
        if (texto_images.activeSelf)
        {
            foreach(GameObject img in imagenes)
            {
                img.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject img in imagenes)
            {
                if (img.activeSelf)
                {
                    img.SetActive(false);
                }
            }
        }

        if (texto_objetos.activeSelf)
        {
            foreach(GameObject obj in objetos)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject obj in objetos)
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
