using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.Tilemaps;
using Unity.VisualScripting;
using UnityEditor.EditorTools;


public class Playermove : MonoBehaviour
{
    public float speed; // control de la velocidad
    private Animator animator; // Activador de la animacion 
    private bool ArmaAfuera; // variable que detecta si el arma esta afuera
   
    public float jumpForce = 2f; // fuerza para el salto
    public float longitudrayCast = 1f; // medida del largo de la linea que detecta el suelo
    public LayerMask capaSuelo; // filtro que identifica si es suelo o no

    public bool enSuelo; // indica si el jugador esta en el suelo
    private Rigidbody2D rb; //Fisicas para el personaje
    private SpriteRenderer sprite;

    public Color colorDamage;
    private Color currentColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //referencia del rigidbody
        animator = GetComponent<Animator>(); //referencia del animator
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movimiento(); 
        jump();
        ataque();

    }

   public void Movimiento()
   {
    // Movimiento del personaje
    float inputMovimiento = Input.GetAxis("Horizontal");

    // Aplicar movimiento con Rigidbody2D
    rb.linearVelocity = new Vector2(inputMovimiento * speed, rb.linearVelocity.y);

    // Voltear personaje según la dirección
    if (inputMovimiento < 0)
    {
            transform.localScale = new Vector2(-1,1);
    }
    else if (inputMovimiento > 0)
    {
            transform.localScale = new Vector2(1, 1);
        }
    // encargado de hacer llamadoa las animaciones de Idle y caminar en el personaje
    animator.SetFloat("Blend", Mathf.Abs(inputMovimiento));

    // Si NO está sacando el arma, actualizar animación de movimiento
    if (!Input.GetKeyDown(KeyCode.E) && !ArmaAfuera)
    {
        animator.SetFloat("Blend", Mathf.Abs(inputMovimiento));
    }
    else 
    {
        
        ArmaAfuera = true;  // Bloqueamos cambios
        animator.SetBool("Sacar", true);
        ArmaAfuera = true;
        animator.SetFloat("Blend", Mathf.Abs(inputMovimiento));
    }

    // Si presionamos "Q" y el arma está sacada, la guardamos
    if (Input.GetKeyUp(KeyCode.Q) && ArmaAfuera)
    {
        animator.SetBool("Sacar", false);

        
        ArmaAfuera = false;  // 🔹 Aquí desbloqueamos cambios
        
    }
   
   }
    void jump()
    {
        // Raycast hacia el suelo 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudrayCast, capaSuelo);
        enSuelo = hit.collider != null; // si hay colision, esta en el suelo

        // si esta en el suelo y presiona la tecal "SPACE", salta
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // activador de animacion de salto, si esta fuera de colision de suelo se activa la animacion
        if (enSuelo == false)
        {
            // el animator para activarlo tienes que usar | animator.SetBool("nombre de la variante en el animator", "el valor de la variante que tiene que alcansar para activarlo") |
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    
    }
    public void ataque()
    {
         // hace el cambio de animacion al de el ataque mientras que registra si tiene el arma afuera 
         if (ArmaAfuera == true && Input.GetKeyUp(KeyCode.Mouse0))
         {
            animator.SetTrigger("Ataque");
            animator.SetBool("ArmaFuera", true);
         }
    }
    public void OnTriggerEnter2D (Collider2D other)
    {
        // Se encarga de detectar que el arma del Player colisione con el objeto con tag "Destruible" y lo destruye
        if (other.CompareTag("Destruible"))
        {
            Debug.Log("objeto destruido...");
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Destruible"))
        {
            speed = 4f;

        }

    }
    private void OnDrawGizmos()
    {
        //color del raycast
        Gizmos.color = Color.red;

        // posicion del raycast y direccion del mismo
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudrayCast);
    }

}