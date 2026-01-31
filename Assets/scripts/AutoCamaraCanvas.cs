using UnityEngine;

public class AutoCamaraCanvas : MonoBehaviour
{
    void OnEnable() // Se ejecuta cada vez que el Canvas se activa
    {
        Canvas miCanvas = GetComponent<Canvas>();
        
        // Busca cualquier cámara que esté activa y etiquetada como "MainCamera"
        if (Camera.main != null)
        {
            miCanvas.worldCamera = Camera.main;
        }
    }

    void Update()
    {
        // OPCIONAL: Si cambias de cámara EN VIVO sin recargar escena
        // Forzamos a que busque la cámara activa si perdió la referencia
        Canvas miCanvas = GetComponent<Canvas>();
        if (miCanvas.worldCamera == null || !miCanvas.worldCamera.gameObject.activeInHierarchy)
        {
             if (Camera.main != null) miCanvas.worldCamera = Camera.main;
        }
    }
}