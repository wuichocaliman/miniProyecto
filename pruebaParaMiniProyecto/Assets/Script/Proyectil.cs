using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 6f; // Velocidad del proyectil
    public Transform objetivo; // Referencia al jugador
    bool choco = false;
    [SerializeField] private AudioClip colector1;

    void Start()
    {
        // Buscar al jugador por su etiqueta "Player"
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            objetivo = jugador.transform;
        }
        else
        {
            Debug.LogWarning("Jugador no encontrado");
        }
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Direccion hacia el jugador
            Vector2 direccion = (objetivo.position - transform.position).normalized;

            // Movimiento hacia el jugador
            transform.position += (Vector3)direccion * velocidad * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Impacto con el jugador");
            choco = true;
            contorladorSonido.Instance.Ejecutarsonido(colector1);
        }
        if (choco == true)
        {
            Destroy(this.gameObject);
        }
        // Acceder al script del jugador
        Playermove player = other.GetComponent<Playermove>();

        if (player != null && player.speed >= 0.25f)
        {
            player.speed -= 0.50f; // Reducimos la velocidad del jugador
            Debug.Log("Velocidad del jugador reducida: " + player.speed);
        }
        
    }
}
