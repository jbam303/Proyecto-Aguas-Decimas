using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PCMovement : MonoBehaviour
{
    [Header("Referencias")]
    public Transform cameraTransform;

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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraTransform == null)
        {
            Debug.LogError("No has asignado la cámara en el script PCMovement");
        }

        escena_inicial = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            
            mouseX = mouseDelta.x * mouseSensitivity * 0.1f;
            mouseY = mouseDelta.y * mouseSensitivity * 0.1f;
        }
        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }

        if (escena_inicial != "Inicio")
        {
            float moveX = 0;
            float moveZ = 0;

            if (Keyboard.current != null)
            {
                if (Keyboard.current.wKey.isPressed) moveZ = 1f;
                if (Keyboard.current.sKey.isPressed) moveZ = -1f;
                if (Keyboard.current.dKey.isPressed) moveX = 1f;
                if (Keyboard.current.aKey.isPressed) moveX = -1f;
            }

            Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
            
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}