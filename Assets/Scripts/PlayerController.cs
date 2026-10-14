using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerController : MonoBehaviour
{
    public PlayerSounds playerSounds; // referencia al script de sonidos
    public Animator animator; // referencia al Animator
    public SpriteRenderer playerSpriteRenderer;
    public float speed = 5f;       // Velocidad horizontal
    public float jumpForce = 7f;   // Fuerza del salto
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private int vidas = 0;
    private int puntos = 0;
    public HUDController hud;
    public int puntosPorVida = 50; // Tope de puntos

    public GameObject textoGameOver;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hud.ActualizarVidas(vidas);
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Flip del sprite según dirección
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0) transform.localScale = new Vector3(-1, 1, 1);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Zarpar
        if (Input.GetMouseButtonDown(0)) // 0 = botón izquierdo
        {
            playerSounds.PlayZarpar();
            animator.SetTrigger("Zarpar");
        }

        // Gasear
        if (Input.GetMouseButtonDown(1)) // click derecho
        {
            playerSounds.PlayGasear();
            animator.SetTrigger("Gasear");
        }


        // Animaciones
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("isGrounded", isGrounded);
    }

    // Detectar suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }

    // Objetos recolectables [Pescado - Pollito - Leche - Queso]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pescado"))
        {
            Destroy(collision.gameObject);
            puntos += 15;
            RevisarVidas();
            hud.ActualizarPuntos(puntos);
            playerSounds.PlayRecolectable();
        }

        if (collision.CompareTag("Pollito"))
        {
            Destroy(collision.gameObject);
            puntos += 20; // ejemplo: pollito da más puntos
            RevisarVidas();
            hud.ActualizarPuntos(puntos);
            playerSounds.PlayRecolectable();
        }

        if (collision.CompareTag("Leche"))
        {
            Destroy(collision.gameObject);
            puntos += 10;
            RevisarVidas();
            hud.ActualizarPuntos(puntos);
            playerSounds.PlayRecolectable();
        }

        if (collision.CompareTag("Queso"))
        {
            Destroy(collision.gameObject);
            puntos += 25;
            RevisarVidas();
            hud.ActualizarPuntos(puntos);
            playerSounds.PlayRecolectable();
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Atacar(this);
        }
    }

    private void RevisarVidas()
    {
        // Calcula cuántas vidas corresponden según puntos acumulados
        int nuevasVidas = puntos / puntosPorVida;

        if (nuevasVidas > vidas)
        {
            vidas = nuevasVidas;
            hud.ActualizarVidas(vidas);
            playerSounds.PlayVida();
        }
    }

    public void RecibirDaño(int cantidad)
    {
        vidas = Mathf.Max(vidas - cantidad, 0);
        hud.ActualizarVidas(vidas);
        //playerSounds.PlayAccion(); // sonido de daño

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        textoGameOver.SetActive(true);
        Time.timeScale = 0f; // pausa el juego
    }

}
