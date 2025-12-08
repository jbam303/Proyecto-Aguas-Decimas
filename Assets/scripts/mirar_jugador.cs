using UnityEngine;
using UnityEngine.Animations;
using System.Collections.Generic;

[RequireComponent(typeof(LookAtConstraint))]
public class ConfigurarConstraint : MonoBehaviour
{
    void Update()
    {
        LookAtConstraint constraint = GetComponent<LookAtConstraint>();
        GameObject jugador = GameObject.FindGameObjectWithTag("MainCamera");

        if (jugador != null)
        {
            ConstraintSource fuente = new ConstraintSource();
            fuente.sourceTransform = jugador.transform;
            fuente.weight = 1f;
            List<ConstraintSource> nuevaListaDeFuentes = new List<ConstraintSource>
            {
                fuente
            };
            constraint.SetSources(nuevaListaDeFuentes);
            constraint.constraintActive = true;
        }
    }
}