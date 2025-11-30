using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class EstacionTour : MonoBehaviour
{
    [Header("Referencias")]
    public MotorCarrito scriptDelMotor;  // Arrastra aquí el carrito (que tiene el script)
    public GameObject jugadorXR;         // Arrastra aquí tu XR Origin

    public GameObject jugadorPC;        // Arrastra aquí tu jugador PC (si aplica)
    public AudioSource narrador;         // El audio de esta zona

    [Header("Puntos Clave")]
    public Transform puntoDeBajada;      // Un objeto vacío en el suelo donde aparecerá el jugador
    public Transform asientoCarrito;     // El objeto vacío DENTRO del carrito (donde va sentado)

    [Header("Interfaz")]
    public GameObject botonContinuar;    // El botón para irse (lo activaremos al final del audio)

    // Detectamos cuando el carrito entra en la estación
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si lo que chocó es el carrito
        if (other.gameObject == scriptDelMotor.gameObject)
        {
            StartCoroutine(SecuenciaParada());
        }
    }

    IEnumerator SecuenciaParada()
    {
        // 1. APAGAR MOTOR
        scriptDelMotor.encendido = false; // Frenamos el carrito

        // 2. BAJAR AL JUGADOR (Despegarlo del carrito)
        jugadorXR.transform.SetParent(null); 
        jugadorPC.transform.SetParent(null);
        
        CharacterController charController = jugadorXR.GetComponent<CharacterController>();
        CharacterController charControllerPC = jugadorPC.GetComponent<CharacterController>();
        
        if (charController != null) charController.enabled = false;
        if (charControllerPC != null) charControllerPC.enabled = false;

        // Lo movemos al punto de suelo
        jugadorXR.transform.position = puntoDeBajada.position;
        jugadorXR.transform.rotation = puntoDeBajada.rotation;

        jugadorPC.transform.position = puntoDeBajada.position;
        jugadorPC.transform.rotation = puntoDeBajada.rotation;

        yield return null;

        if (charController != null) charController.enabled = true;
        if (charControllerPC != null) charControllerPC.enabled = true;

        // 3. REPRODUCIR AUDIO
        narrador.Play();

        // Esperamos lo que dure el audio
        yield return new WaitForSeconds(narrador.clip.length);

        // 4. HABILITAR EL BOTÓN DE "CONTINUAR"
        if(botonContinuar != null)
        {
            botonContinuar.SetActive(true);
        }
    }

    // Esta función la llamará el Botón 3D cuando el jugador lo presione
    public void SubirseYContinuar()
    {
        
        // 1. VOLVER AL ASIENTO
        jugadorXR.transform.position = asientoCarrito.position;
        jugadorXR.transform.rotation = asientoCarrito.rotation;

        jugadorPC.transform.position = asientoCarrito.position;
        jugadorPC.transform.rotation = asientoCarrito.rotation;
        
        // 2. PEGARLO AL CARRITO (Hacerlo hijo otra vez)
        jugadorXR.transform.SetParent(scriptDelMotor.transform);
        jugadorPC.transform.SetParent(scriptDelMotor.transform);
        narrador.Stop();

        // 3. OCULTAR BOTÓN
        if(botonContinuar != null) botonContinuar.SetActive(false);

        // 4. ARRANCAR MOTOR
        scriptDelMotor.encendido = true;
    }
}