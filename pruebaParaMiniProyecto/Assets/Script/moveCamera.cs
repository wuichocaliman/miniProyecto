using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Vector3 desplazamiento; // Ajustes para la posicion de la camara
    public float smoothTime = 0.25f;
    public Transform objetivo; // el objeto que seguira la camara
    private Vector3 velocidad = Vector3.zero; // velocidad de la camara

    private void Update()
    {
        if (objetivo != null) // es para que cuando la camra pierda al personaje, o sea, Muera. No salte ningun error 
        {

            Vector3 targetpos = objetivo.position + desplazamiento;


            transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref velocidad, smoothTime);
        }
    }
}
