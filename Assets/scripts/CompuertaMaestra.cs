using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompuertaMaestra : MonoBehaviour
{
    [Header("1. La Puerta Metálica")]
    public Transform puertaFisica;
    public float distanciaBajada = 2.0f;

    [Header("2. El Agua (Arrastra los Pivotes)")]
    public List<Transform> aguasParaSecar;

    [Header("Configuración")]
    public float velocidadAnimacion = 2.0f;

    // Hacemos pública esta variable para ver en el Inspector si cambia
    public bool estaAbierta = true;

    private Vector3 posInicialPuerta;
    private List<Vector3> escalasOriginales = new List<Vector3>();

    void Start()
    {
        if (puertaFisica != null)
            posInicialPuerta = puertaFisica.localPosition;

        // Guardamos el tamaño MÁXIMO original del agua
        foreach (Transform agua in aguasParaSecar)
        {
            escalasOriginales.Add(agua.localScale);
        }
    }

    // --- FUNCIÓN PARA EL BOTÓN ---
    [ContextMenu("Probar Compuerta")] // TRUCO: Esto añade un botón en el menú del script en Unity
    public void Accionar()
    {
        estaAbierta = !estaAbierta;
        StopAllCoroutines();
        StartCoroutine(AnimarTodo());
    }

    IEnumerator AnimarTodo()
    {
        float t = 0;

        // 1. Calculamos metas
        Vector3 metaPuerta = estaAbierta ? posInicialPuerta : posInicialPuerta - new Vector3(0, distanciaBajada, 0);

        // 2. Guardamos desde DÓNDE partimos en ESTE momento específico
        Vector3 inicioPuerta = puertaFisica.localPosition;

        // CORRECCIÓN: Guardamos el estado actual de cada trozo de agua antes de empezar el bucle
        List<Vector3> iniciosAgua = new List<Vector3>();
        foreach (Transform agua in aguasParaSecar)
        {
            iniciosAgua.Add(agua.localScale);
        }

        while (t < 1)
        {
            t += Time.deltaTime * velocidadAnimacion;

            // A) MOVER PUERTA (Lerp entre inicio fijo y meta fija)
            if (puertaFisica != null)
                puertaFisica.localPosition = Vector3.Lerp(inicioPuerta, metaPuerta, t);

            // B) ESCALAR AGUA (Corregido)
            for (int i = 0; i < aguasParaSecar.Count; i++)
            {
                // Meta: Si está abierta, volvemos al tamaño original. Si cerrada, a cero.
                Vector3 metaAgua = estaAbierta ? escalasOriginales[i] : Vector3.zero;

                // Usamos la lista 'iniciosAgua' que capturamos antes del while
                aguasParaSecar[i].localScale = Vector3.Lerp(iniciosAgua[i], metaAgua, t);
            }

            yield return null;
        }
    }
}