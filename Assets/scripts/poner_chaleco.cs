using UnityEngine;

public class CambiarPadre : MonoBehaviour
{
    public GameObject objetoHijo;
    public GameObject objetoPadre;

    public void Equipar()
    {
        objetoHijo.transform.SetParent(objetoPadre.transform);
        objetoHijo.transform.localPosition = new Vector3(0f, 2f, 0f);
    }
}