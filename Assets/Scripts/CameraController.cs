using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform jugador;
    public float limiteXMin;
    public float limiteXMax;
    public float limiteYMin;
    public float limiteYMax;

    void Start()
    {
        // Encontrar automáticamente los límites basados en colliders
        EncontrarLimites();
    }

    void EncontrarLimites()
    {
        // Encuentra todos los colliders en la capa "LimitesCamara"
        Collider2D[] colliders = Physics2D.OverlapBoxAll(Vector2.zero, new Vector2(1000f, 1000f), 0f, LayerMask.GetMask("LimitesCamara"));

        if (colliders.Length > 0)
        {
            limiteXMin = limiteXMax = colliders[0].transform.position.x;
            limiteYMin = limiteYMax = colliders[0].transform.position.y;

            foreach (Collider2D collider in colliders)
            {
                limiteXMin = Mathf.Min(limiteXMin, collider.bounds.min.x);
                limiteXMax = Mathf.Max(limiteXMax, collider.bounds.max.x);
                limiteYMin = Mathf.Min(limiteYMin, collider.bounds.min.y);
                limiteYMax = Mathf.Max(limiteYMax, collider.bounds.max.y);
            }
        }
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
            // Ajusta la posición de la cámara para seguir al jugador dentro de los límites
            float posicionX = Mathf.Clamp(jugador.position.x, limiteXMin, limiteXMax);
            float posicionY = Mathf.Clamp(jugador.position.y, limiteYMin, limiteYMax);

            transform.position = new Vector3(posicionX, posicionY, transform.position.z);
        }
    }
}



