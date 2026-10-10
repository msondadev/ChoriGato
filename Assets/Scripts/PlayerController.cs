using UnityEngine;

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

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
}
