using UnityEngine;
using System.Collections.Generic;

public class OutlineGrupal : MonoBehaviour
{
    [Header("Configuración del Borde")]
    public Color colorBorde = Color.yellow;
    [Range(0, 10)] public float grosor = 4f;

    private List<Outline> bordesHijos = new List<Outline>();

    void Start()
    {
        Renderer[] todasLasPiezas = GetComponentsInChildren<Renderer>();

        foreach (Renderer pieza in todasLasPiezas)
        {
            Outline borde = pieza.gameObject.GetComponent<Outline>();
            if (borde == null)
            {
                borde = pieza.gameObject.AddComponent<Outline>();
            }

            borde.OutlineColor = colorBorde;
            borde.OutlineWidth = grosor;
            borde.OutlineMode = Outline.Mode.OutlineAll;
            borde.enabled = false;

            bordesHijos.Add(borde);
        }
    }

    public void Encender()
    {
        foreach (var borde in bordesHijos)
        {
            if (borde != null) borde.enabled = true;
        }
    }

    public void Apagar()
    {
        foreach (var borde in bordesHijos)
        {
            if (borde != null) borde.enabled = false;
        }
    }
}