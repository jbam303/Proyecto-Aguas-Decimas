using UnityEngine;
using UnityEngine.SceneManagement;

// Asegura que este objeto tenga un CharacterController
[RequireComponent(typeof(CharacterController))]
public class PCMovement : MonoBehaviour
{
    [Header("Referencias")]
    public Transform cameraTransform; // Arrastra la cámara hija aquí

    [Header("Configuración de Movimiento")]
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private Vector3 velocity;
    private string escena_inicial;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Esconder y bloquear el cursor para el modo PC
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraTransform == null)
        {
            Debug.LogError("¡No has asignado la cámara en el script PCMovement!");
        }

        escena_inicial = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        // --- VISTA CON MOUSE ---

        // Obtener movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotar el jugador (cuerpo) de izquierda a derecha
        transform.Rotate(Vector3.up * mouseX);

        // Rotar la cámara (cabeza) de arriba a abajo
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitar la vista
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // --- MOVIMIENTO WASD ---

        if (escena_inicial != "Inicio")
        {
            // Obtener movimiento del teclado
            float moveX = Input.GetAxis("Horizontal"); // A/D
            float moveZ = Input.GetAxis("Vertical"); // W/S

            // Calcular la dirección del movimiento basado en la rotación del jugador
            Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

            // Aplicar movimiento
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            // --- GRAVEDAD ---
            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Un pequeño valor para mantenerlo pegado al suelo
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
