using UnityEngine;

public class sueloPeligroso : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject); // Destruye el objeto que choca contra el suelo
    }
}
