using UnityEngine;

public class fondoMenu : MonoBehaviour
{
    [SerializeField] private Vector2 velocidad = new Vector2(0.1f, 0); // Velocidad constante del fondo
    private Vector2 offset; // Almacena el desplazamiento aplicado a la textura.
    private Material material; // Referencia al material del SpriteRenderer del fondo.

    private void Awake()
    {
        // Obtiene el material del SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            material = sr.material;
        }
        else
        {
            Debug.LogError("No se encontr� SpriteRenderer en " + gameObject.name);
        }
    }

    private void Update()
    {
        // Movimiento continuo del fondo
        offset += velocidad * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
