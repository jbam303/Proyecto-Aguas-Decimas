using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement; 

public class ControladorVelocidad : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreEscenaBloqueada;
    
    [Header("Referencias")]
    public ContinuousMoveProvider sistemaMovimiento;

    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;

        if (escenaActual == nombreEscenaBloqueada)
        {
            if (sistemaMovimiento != null)
            {
                sistemaMovimiento.moveSpeed = 0f;
            }
        }
    }
}