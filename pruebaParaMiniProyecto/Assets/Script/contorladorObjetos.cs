using UnityEngine;

public class contorladorObjetos : MonoBehaviour
{
    public GameObject[] objetos;
    public Transform[] Spawners;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            int numeroaAleatorioItems = Random.Range(0, objetos.Length);
            int numeroAleatorioSpawners= Random.Range(0, Spawners.Length);


        }
        

        
    }
}
