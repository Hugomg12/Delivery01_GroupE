using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    // Evento estático para notificar cuando se recoja una moneda
    public static event Action<int> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notifica a los suscriptores del evento
            OnCoinCollected?.Invoke(value);
            Destroy(gameObject);
        }
    }
}
