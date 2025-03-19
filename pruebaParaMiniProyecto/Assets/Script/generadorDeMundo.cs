using UnityEngine;

public class generadorDeMundo : MonoBehaviour
{
    public GameObject[] objetosSpawnear;
    public float distanciaMinima;
    public Transform puntoFinal;
    public int cantidadInicial;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        { 
            for (int i = 0; i < cantidadInicial; i++)
            {
                GenerarMasNivel();
            }
        }
        else
        {
            Debug.LogWarning("EL JUGADOR MURIO O NO SE ENCUENTRA EL JUGADOR EN LA PARTIDA");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador murió, salimos del Update
        if (player != null)
        {
            if(Vector2.Distance(player.position, puntoFinal.position) < distanciaMinima)
            {
                GenerarMasNivel();
            }
        }
            return;
        
       
        
    }

    void GenerarMasNivel()
    {
        int numeroAleatorio = Random.Range(0, objetosSpawnear.Length);
        GameObject nivel = Instantiate(objetosSpawnear[numeroAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");

    }

    private Transform BuscarPuntoFinal(GameObject objetosSpawnear, string etiqueta)
    {
        Transform punto = null;

        foreach (Transform ubicacion in objetosSpawnear.transform)
        {
            if (ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }

        return punto;

    }
}
