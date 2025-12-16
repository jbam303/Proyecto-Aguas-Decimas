using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompuertaMaestra : MonoBehaviour
{
    [Header("1. La Puerta Metálica")]
    public Transform puertaFisica;      // El objeto 3D de la compuerta
    public float distanciaBajada = 2.0f; // Cuánto baja en metros (Eje Y)

    [Header("2. El Agua (Arrastra los Pivotes)")]
    // Arrastra aquí el 'PivoteCascada' y el 'Rio' (si quieres que se seque)
    public List<Transform> aguasParaSecar; 

    [Header("3. La Espuma (Opcional)")]
    public ParticleSystem espumaCascada; // Arrastra tu sistema de partículas aquí

    [Header("Configuración")]
    public float velocidadAnimacion = 2.0f;
    private bool estaAbierta = true; // Asumimos que empieza abierta

    // Variables internas para recordar posiciones
    private Vector3 posInicialPuerta;
    private List<Vector3> escalasOriginales = new List<Vector3>();

    void Start()
    {
        // Guardamos dónde está la puerta al inicio
        posInicialPuerta = puertaFisica.localPosition;

        // Guardamos el tamaño original del agua
        foreach (Transform agua in aguasParaSecar)
        {
            escalasOriginales.Add(agua.localScale);
        }
    }

    // --- FUNCIÓN PARA EL BOTÓN ---
    public void Accionar()
    {
        estaAbierta = !estaAbierta; // Cambiamos estado (Abierto <-> Cerrado)
        StopAllCoroutines();        // Limpiamos animaciones previas
        StartCoroutine(AnimarTodo());
    }

    IEnumerator AnimarTodo()
    {
        float t = 0;
        
        // Calculamos destino de la puerta: Si cerramos, bajamos Y. Si abrimos, volvemos a origen.
        Vector3 metaPuerta = estaAbierta ? posInicialPuerta : posInicialPuerta - new Vector3(0, distanciaBajada, 0);
        Vector3 inicioPuerta = puertaFisica.localPosition;

        // Lógica de Espuma: Si cerramos, dejamos de emitir. Si abrimos, emitimos.
        if (espumaCascada != null)
        {
            if (estaAbierta) espumaCascada.Play();
            else espumaCascada.Stop(); // Stop deja que las partículas vivas mueran naturalmente
        }

        while (t < 1)
        {
            t += Time.deltaTime * velocidadAnimacion;

            // A) MOVER PUERTA
            puertaFisica.localPosition = Vector3.Lerp(inicioPuerta, metaPuerta, t);

            // B) ESCALAR AGUA (Secar o Llenar)
            for (int i = 0; i < aguasParaSecar.Count; i++)
            {
                // Si abrimos -> Escala Original. Si cerramos -> Cero.
                Vector3 metaAgua = estaAbierta ? escalasOriginales[i] : Vector3.zero;
                aguasParaSecar[i].localScale = Vector3.Lerp(aguasParaSecar[i].localScale, metaAgua, t);
            }

            yield return null;
        }
    }
}