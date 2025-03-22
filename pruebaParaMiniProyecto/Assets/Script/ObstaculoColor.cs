using UnityEngine;

public class ObstaculoColor : MonoBehaviour
{
    public int golpesParaRomper = 3; // Cantidad de golpes necesarios para destruirlo
    private int golpesRecibidos = 0; // Contador de golpes
    private SpriteRenderer spriteRenderer; // Para cambiar el color
    private Color colorInicial; // Guarda el color original del objeto
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Guarda el color inicial del objeto
        if (spriteRenderer != null)
        {
            colorInicial = spriteRenderer.color;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el trigger lo activa el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Golpeaste el obstáculo");

            // Aumenta el contador de golpes
            golpesRecibidos++;

            // Calcula cuánto ha sido dañado (como un porcentaje)
            float factor = (float)golpesRecibidos / golpesParaRomper;

            // Cambia el color progresivamente hasta negro
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.Lerp(colorInicial, Color.black, factor);
            }

            Debug.Log("Golpe recibido: " + golpesRecibidos);

            // Si el obstáculo ha recibido suficientes golpes, se destruye
            if (golpesRecibidos >= golpesParaRomper)
            {
                Destroy(gameObject);
            }
        }
    }
}
