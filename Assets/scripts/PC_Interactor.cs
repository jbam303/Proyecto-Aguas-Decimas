using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PC_Interactor : MonoBehaviour
{
    public float distancia = 20f; // Aumentamos la distancia por defecto

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        PointerEventData puntero = new PointerEventData(EventSystem.current);
        puntero.position = new Vector2(Screen.width / 2, Screen.height / 2);

        List<RaycastResult> resultados = new List<RaycastResult>();
        EventSystem.current.RaycastAll(puntero, resultados);

        // --- DEBUG: Ver si el rayo sale ---
        if (resultados.Count == 0) 
        {
            Debug.Log("Hice click, pero el rayo no tocó NADA de UI.");
        }

        foreach (RaycastResult resultado in resultados)
        {
            // --- DEBUG: Ver qué tocamos ---
            Debug.Log("El rayo tocó: " + resultado.gameObject.name);

            Button boton = resultado.gameObject.GetComponentInParent<Button>();
            if (boton != null && boton.interactable)
            {
                boton.onClick.Invoke();
                Debug.Log("¡CLICK EXITOSO EN BOTÓN!");
                return;
            }
        }
    }
}