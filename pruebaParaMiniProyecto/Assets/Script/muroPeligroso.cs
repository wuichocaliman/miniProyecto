using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class muroPeligroso : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 1.0f;
    public Vector2 direccion = Vector2.right; // hace que el movimeinto sea continuo
    public GameObject objetoASpawnear; // El prefab que vamos a spawnear
    public Transform puntoDeSpawneo;  // El lugar donde aparecerá el objeto
    public float tiempoEntreSpawns = 2f; // Tiempo entre spawns
    public LayerMask capaPersonaje; // La capa del personaje

    [Header("Ataque")]
    public Transform[] ArrayList;
    bool personajeDetectado;
    bool puedeSpawnear = true; // Controla el tiempo entre spawns

    private void Update()
    {
        movimiento();
        checkPlayerRange();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); // Destruye el objeto que choca contra el muro
    }

    void movimiento()
    {
        // movimiento del muro continuo
        transform.Translate(direccion * speed * Time.deltaTime);
    }

    public void checkPlayerRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 5, capaPersonaje);
        if (collision != null && puedeSpawnear)
        {
            StartCoroutine(SpawnConCooldown());
        }
    }

    IEnumerator SpawnConCooldown()
    {
        puedeSpawnear = false;
        var e = Random.Range(0, ArrayList.Length);
        Instantiate(objetoASpawnear, ArrayList[e].transform.position, Quaternion.identity);
        Debug.Log(e);
        yield return new WaitForSeconds(tiempoEntreSpawns);
        puedeSpawnear = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f); // Radio de detección
    }
}
