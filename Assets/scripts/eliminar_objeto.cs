using UnityEngine;

public class eliminar_objeto : MonoBehaviour
{
    public GameObject objeto;

    public void Eliminar()
    {
        Destroy(objeto);
    }
}
