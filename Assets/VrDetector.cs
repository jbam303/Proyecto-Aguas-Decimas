using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;
using System.Collections; // Necesario para las Corutinas

public class VRDetector : MonoBehaviour
{
    [Header("Controladores")]
    public GameObject vrController;
    public GameObject pcController;

    [Header("Configuración")]
    [Tooltip("Tiempo máximo en segundos para esperar la detección del HMD.")]
    public float maxWaitTime = 5.0f;

    void Start()
    {
        // Desactivar ambos al inicio para evitar un salto visual
        vrController.SetActive(false);
        pcController.SetActive(false);

        // Iniciar la rutina que buscará el visor
        StartCoroutine(CheckForVRDevice());
    }

    /// <summary>
    /// Corutina que revisa repetidamente si hay un HMD conectado
    /// durante un tiempo máximo.
    /// </summary>
    IEnumerator CheckForVRDevice()
    {
        float elapsedTime = 0f;

        Debug.Log("Buscando visor VR...");

        while (elapsedTime < maxWaitTime)
        {
            if (IsVRHeadsetConnected())
            {
                Debug.Log("Visor VR DETECTADO. Activando modo VR.");
                vrController.SetActive(true);
                yield break; // Termina la corutina exitosamente
            }

            // Si no se encuentra, espera al siguiente frame para volver a revisar
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        // Si el loop termina sin encontrar un HMD:
        Debug.LogFormat("No se detectó visor VR tras {0} segundos. Activando modo PC.", maxWaitTime);
        pcController.SetActive(true);
    }

    /// <summary>
    /// Revisa si hay algún dispositivo VR (HMD) conectado y activo.
    /// </summary>
    bool IsVRHeadsetConnected()
    {
        var hmds = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, hmds);
        return hmds.Count > 0;
    }
}