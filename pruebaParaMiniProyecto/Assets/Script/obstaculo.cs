using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.Tilemaps;
using Unity.VisualScripting;
using UnityEditor.EditorTools;

public class obstaculo : MonoBehaviour
{
    public LayerMask capaPersonaje; // La capa del personaje
    private Animator animator;

    [Header("Configuración de Rotura")]
    public float radioDeDeteccion = 2f;
    public int golpesParaRomper = 3; // Cantidad de golpes necesarios para destruirlo
    private int golpesRecibidos = 0; // Contador de golpes

    private float posicionInicialX;
    private float posicionInicialY = 2f;
    private float posicionFinalY;
    public float speed = 2F;
    bool jugadorCerca = false;

    private SpriteRenderer spriteRenderer; // Para cambiar el color
    private Color colorInicial; // Guarda el color original del objeto
    private float movimiento;

    void Start()
    {
        // Guarda la posición inicial en X para evitar desplazamientos laterales
        posicionInicialX = transform.position.x;
        posicionInicialY = transform.position.y;

        // Obtiene componentes necesarios
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Guarda el color inicial del objeto
        if (spriteRenderer != null)
        {
            colorInicial = spriteRenderer.color;
        }
    }

    void Update()
    {
        checkPlayerRange();
    }

    public void checkPlayerRange()
    {
        // Detección del jugador
        Collider2D collision = Physics2D.OverlapCircle(transform.position, radioDeDeteccion, capaPersonaje);

        if (collision != null)
        {
            jugadorCerca = true;
        }
        else
        {
            jugadorCerca = false;
        }

        if (jugadorCerca)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, posicionFinalY, speed * Time.deltaTime), transform.position.z);
        }
    
        
        
        
        
        
        
        
        
        /*if (collision != null)
        {

            // sen encarga de mantener la posición X fija para evitar desplazamientos 
            //transform.position = new Vector3(posicionInicialX, transform.position.y, transform.position.z);

            // Activa animación si el jugador está cerca
            //transform.Translate(Vector2.up * speed * Time.deltaTime);

            
            transform.position = new Vector3(transform.position.x, posicionInicialY, transform.position.z);
            float nuevaPosicionY = Mathf.Lerp(0, 2, posicionInicialY/posicionFinalY);
            transform.position = new Vector3(transform.position.x, nuevaPosicionY, transform.position.z);
        }*/
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeDeteccion); // Radio de detección
    }
}
