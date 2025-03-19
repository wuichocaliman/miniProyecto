using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class movimientoFondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidad; // control de la velocidad de los fondos
    private Vector2 offset; //Almacena el desplazamiento aplicado a la textura.
    private Material material; //Guarda la referencia al material del SpriteRenderer del fondo.
    [SerializeField]
    private Rigidbody2D playerRb; //Referencia al Rigidbody2D del jugador, usado para obtener su velocidad y aplicarla al fondo.

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        /* Obtiene el material del SpriteRenderer en el GameObject del fondo.
         * 
           Esto permite modificar su propiedad mainTextureOffset, que es la clave para el efecto de desplazamiento.
         */

    }

    private void Update()
    {
        if (playerRb != null)
        {
            offset = (playerRb.linearVelocity.x * 0.1f) * velocidad * Time.deltaTime;
            material.mainTextureOffset += offset;
        }
    }
}
